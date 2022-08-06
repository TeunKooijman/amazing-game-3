using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class Werkplek : RoomBase
    {
        public static int ID = 144323;

        public Werkplek()
            : base(ID, "Werkplek")
        {

        }
        
        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(Emile.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je komt aan op je werkplek, en ziet dat Emile op de plek naast je is gaan zitten. Je zucht diep, en zegt toch maar goedemorgen.";
        }
    }
}