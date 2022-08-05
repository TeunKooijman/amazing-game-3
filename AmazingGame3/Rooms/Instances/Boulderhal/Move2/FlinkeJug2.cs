using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Boulderhal.Move2
{
    public class FlinkeJug2 : IRoom
    {
        public static int ID = 17141;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {

            };
        }

        public string GetName()
        {
            return "Flinke Jug";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {

            };
        }

        public string GetRoomDescription()
        {
            //Hier kom je nooit geloof ik.
            return @"";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}