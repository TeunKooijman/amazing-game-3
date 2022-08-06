using AmazingGame3.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace AmazingGame3.Host.Communication
{
    public interface ISignalRConsoleAdapterFactory
    {
        public SignalRConsoleAdapter Create(string connectionId);
    }

    public class SignalRConsoleAdapterFactory : ISignalRConsoleAdapterFactory
    {
        private IServiceProvider ServiceProvider { get; }
        private GameHubState State { get; }
        private IColorParser ColorParser { get; }

        public SignalRConsoleAdapterFactory(IServiceProvider serviceProvider, GameHubState state, IColorParser colorParser)
        {
            ServiceProvider = serviceProvider;
            State = state;
            ColorParser = colorParser;
        }

        public SignalRConsoleAdapter Create(string connectionId)
        {
            return new SignalRConsoleAdapter(connectionId, State, ServiceProvider, ColorParser);
        }
    }

    public class SignalRConsoleAdapter : IRemoteConsole
    {
        private string ConnectionId { get; }
        private GameHubState State { get; }
        private IServiceProvider ServiceProvider { get; }
        private IColorParser ColorParser { get; }

        public SignalRConsoleAdapter(string connectionId, GameHubState state, IServiceProvider serviceProvider, IColorParser colorParser)
        {
            ConnectionId = connectionId;
            State = state;
            ServiceProvider = serviceProvider;
            ColorParser = colorParser;
        }

        public async Task ClearAsync()
        {
            await GetHub().Clients.Client(ConnectionId).SendAsync("clear");
        }

        public async Task WriteLineAsync(string line)
        {
            line = ColorParser.Parse(line, (line, match, text, color) => line.Replace(match, "<span style=\"color: " + color + "\">" + text + "</span>"));
            await GetHub().Clients.Client(ConnectionId).SendAsync("write", line);
        }

        public async Task<string?> ReadLineAsync()
        {
            TaskCompletionSource<string?> taskCompletionSource = new();
            State.WaitingReadLines.TryAdd(ConnectionId, taskCompletionSource);

            await GetHub().Clients.Client(ConnectionId).SendAsync("read");
            return await taskCompletionSource.Task;
        }

        private IHubContext<GameHub> GetHub()
        {
            return ServiceProvider.GetRequiredService<IHubContext<GameHub>>();
        }
    }

    public class GameHubState
    {
        public ConcurrentDictionary<string, IServiceProvider> GameInstances { get; }
        public ConcurrentDictionary<string, TaskCompletionSource<string?>> WaitingReadLines { get; }

        public GameHubState()
        {
            GameInstances = new ConcurrentDictionary<string, IServiceProvider>();
            WaitingReadLines = new ConcurrentDictionary<string, TaskCompletionSource<string?>>();
        }
    }

    public class GameHub : Hub
    {
        private GameHubState State { get; }
        private ISignalRConsoleAdapterFactory SignalrConsoleAdapterFactory { get; }

        public GameHub(GameHubState state, ISignalRConsoleAdapterFactory signalrConsoleAdapterFactory)
        {
            State = state;
            SignalrConsoleAdapterFactory = signalrConsoleAdapterFactory;
        }

        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            IServiceProvider game = GameFactory
                .CreateInstance(SignalrConsoleAdapterFactory.Create(Context.ConnectionId));

            if(State.GameInstances.TryAdd(Context.ConnectionId, game) == false)
            {
                throw new InvalidOperationException("Something went wrong when trying to create a Game connection. Please try again later.");
            }

            _ = game
                .GetRequiredService<GameEngine>()
                .RunAsync();
        }

        [HubMethodName("ReceiveReadLine")]
        public void ReceiveReadLine(string line)
        {
            if(State.WaitingReadLines.TryRemove(Context.ConnectionId, out TaskCompletionSource<string?>? applicableWaitingTask) == false)
            {
                throw new InvalidOperationException("Something went wrong while marshalling the request. Please try again.");
            }

            applicableWaitingTask.TrySetResult(line);
        }
    }
}
