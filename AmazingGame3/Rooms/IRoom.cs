using AmazingGame3.Items;
using AmazingGame3.Persons;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Rooms
{
    public interface IRoom
    {
        public int GetId();
        public string GetName();
        public string GetRoomDescription();
        public IRoom[] GetExits();
        public IPerson[] GetPersons();
        public bool CanExitRoomTo(GameState state, IRoom exit);
    }
}
