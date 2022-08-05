using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class AchterHetToegangspoortje : IRoom
    {
        public static int ID = 8;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(Lift.ID),
                RoomProvider.GetRoom(Trap.ID),
            };
        }

        public string GetName()
        {
            return "Achter het toegangspoortje";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {

            };
        }

        public string GetRoomDescription()
        {
            return @"
                Je moet naar de vijfde verdieping. Ga je als een giga-chad met de trap, of als die vieze maagd dat je bent met de lift?";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}