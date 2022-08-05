using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Boulderhal.Move1
{
    public class ForseHold1 : IRoom
    {
        public static int ID = 984831;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {

            };
        }

        public string GetName()
        {
            return "Forse Hold";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {

            };
        }

        public string GetRoomDescription()
        {
            //Hier kan je nooit komen geloof ik.
            return @"";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}