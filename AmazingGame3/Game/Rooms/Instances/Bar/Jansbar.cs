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
    public class Jansbar : RoomBase
    {
        public static int ID = -7;

        public Jansbar()
            : base(ID, "De Glorieuze Jansbar")
        {

        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(Deksletten.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Het is de beste bar van Utrecht, waar je met je getrouwe Deksletten de beste avonden van je leven hebt geleefd.";
        }
    }
}
