using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class Werkplek : IRoom
    {
        public static int ID = 144323;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {

            };
        }

        public string GetName()
        {
            return "Werkplek";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(Emile.ID)
            };
        }

        public string GetRoomDescription()
        {
            return @"
                Je komt aan op je werkplek, en ziet dat Emile op de plek naast je is gaan zitten. Je zucht diep, en zegt toch maar goedemorgen.";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}