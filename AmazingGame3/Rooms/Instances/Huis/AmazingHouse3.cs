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
    public class AmazingHuis3 : IRoom
    {
        public static int ID = 1;
        public int GetId() => ID;

        public string GetRoomDescription()
        {
            return @"
                AmazingHuis3 is een dikke osso met nooit zon. Er loopt soms ook een domme kat rond. Maar die is er nu even niet ofzo.";
        }

        public string GetName()
        {
            return "AmazingHuis3";
        }

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(BoulderhalStronk.ID),
            };
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(LunaHuis.ID)
            };
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}
