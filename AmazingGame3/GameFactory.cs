using AmazingGame3.Infrastructure;
using AmazingGame3.Items.Instances;
using AmazingGame3.Persons;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Huis;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingGame3
{
    public static class GameFactory
    {
        public static IServiceProvider CreateInstance(IRemoteConsole consoleInstance)
        {
            IServiceCollection collection = new ServiceCollection();

            collection
                .AddSingleton<IPersonProvider, PersonProvider>()
                .AddSingleton<IRoomProvider, RoomProvider>();

            collection
                .AddSingleton<GameState>()
                .AddSingleton<GameEngine>();

            collection
                .AddSingleton<IRemoteConsole>(consoleInstance);

            return collection.BuildServiceProvider();
        }
    }
}