using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class Lift : RoomBase
    {
        public static int ID = 841566;

        public Lift()
            : base(ID, "Lift")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(Werkplek.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je staat als een misselijkmakend zwak ventje te wachten tot de lift je naar boven heeft gebracht. Zwakke lul.";
        }
    }
}