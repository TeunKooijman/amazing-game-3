using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Rooms.Instances.Bar
{
    public class Jansbar : IRoom
    {
        public static int ID = -7;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {

            };
        }

        public string GetName()
        {
            return "De glorieuze Jansbar";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(Deksletten.ID)
            };
        }

        public string GetRoomDescription()
        {
            return @"
                Het is de beste bar van Utrecht, waar je met je getrouwe Deksletten de beste avonden van je leven hebt geleefd.";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}
