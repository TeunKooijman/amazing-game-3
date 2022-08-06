using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Huis;
using AmazingGame3.Rooms.Instances.Stater;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class BoulderhalStronk : RoomBase
    {
        public static int ID = 2;

        public BoulderhalStronk()
            : base(ID, "Boulderhal Stronk")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(AmazingHuis3.ID),
                provider.GetRoom(StaterLobby.ID)
            };
        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(SterkeVerkoopster.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Dit is boulderhal Stronk. Echt stronk.";
        }
    }
}