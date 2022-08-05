namespace AmazingGame3.Items
{
    public interface IItem
    {
        public int GetId();
        public string GetName();
        public string GetDescription();
        public void OnUse(GameState state);
    }
}