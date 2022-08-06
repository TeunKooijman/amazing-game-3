using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Huis;

namespace AmazingGame3
{
    public record GameState
    {
        public IRoom CurrentRoom { get; set; }
        public Inventory Inventory { get; }
        public bool IsGameFinished { get; set; }

        public GameState(IRoomProvider roomProvider)
        {
            CurrentRoom = roomProvider.GetRoom(AmazingHuis3.ID);
            Inventory = new Inventory();
        }
    }
}