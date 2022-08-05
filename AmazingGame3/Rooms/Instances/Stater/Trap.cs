using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class Trap : IRoom
    {
        public static int ID = 141541;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(Werkplek.ID)
            };
        }

        public string GetName()
        {
            return "Trap";
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
                Als een echte man, huppel je de trap op naar boven. Jezus wat ben jij toch gaaf. Je handen worden knuistjes. Wat gaaf!";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}