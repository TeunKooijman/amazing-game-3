using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Rooms.Instances.Huis
{
    public class AmazingHuis3 : RoomBase
    {
        public static int ID = 1;

        public AmazingHuis3()
            : base(ID, "AmazingHuis3")
        {

        }

        public override string GetRoomDescription()
        {
            return @"
                AmazingHuis3 is een dikke osso met nooit zon. Er loopt soms ook een domme kat rond. Maar die is er nu even niet ofzo.";
        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(BoulderhalStronk.ID),
            };
        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(LunaHuis.ID)
            };
        }
    }
}
