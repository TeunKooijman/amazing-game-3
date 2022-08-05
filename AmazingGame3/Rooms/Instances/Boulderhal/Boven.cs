using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move1;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class Boven : IRoom
    {
        public static int ID = 73163;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
               
            };
        }

        public string GetName()
        {
            return "Boven";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(LunaBoulder.ID)
            };
        }

        public string GetRoomDescription()
        {
            return @"
                Eenmaal naar boven geklommen zie je een angstige Lœna vastgebonden liggen. Je doet een klein knikje haar kant op, roept ""ik ben hier"".
            ";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}