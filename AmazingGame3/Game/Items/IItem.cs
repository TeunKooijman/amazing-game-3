using AmazingGame3.Infrastructure;

namespace AmazingGame3.Items
{
    public interface IItem
    {
        public int GetId();
        public string GetName();
        public string GetDescription();
        public Task OnUseAsync(GameState state, IRemoteConsole console);
    }
}