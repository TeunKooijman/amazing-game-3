namespace AmazingGame3.Infrastructure
{
    public interface IRemoteConsole
    {
        public Task ClearAsync();
        public Task<string?> ReadLineAsync();
        public Task WriteLineAsync(string line);
    }
}