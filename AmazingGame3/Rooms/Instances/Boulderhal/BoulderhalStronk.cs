using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Huis;
using AmazingGame3.Rooms.Instances.Stater;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class BoulderhalStronk : IRoom
    {
        public static int ID = 2;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(AmazingHuis3.ID),
                RoomProvider.GetRoom(StaterLobby.ID)
            };
        }

        public string GetName()
        {
            return "Boulderhal Stronk";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(SterkeVerkoopster.ID)
            };
        }

        public string GetRoomDescription()
        {
            return @"
                Dit is boulderhal Stronk. Echt stronk.";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}