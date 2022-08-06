using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Persons;
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
        public IRoom[] GetExits(IRoomProvider provider);
        public IPerson[] GetPersons(IPersonProvider provider);
        public Task<bool> CanExitRoomToAsync(GameState state, IRoom exit, IRemoteConsole console);
    }

    public abstract class RoomBase : IRoom
    {
        private int Id { get; }
        private string Name { get; }

        public RoomBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public virtual Task<bool> CanExitRoomToAsync(GameState state, IRoom exit, IRemoteConsole console)
        {
            return Task.FromResult(true);
        }

        public virtual IRoom[] GetExits(IRoomProvider provider)
        {
            return Array.Empty<IRoom>();
        }

        public virtual IPerson[] GetPersons(IPersonProvider provider)
        {
            return Array.Empty<IPerson>();
        }

        public abstract string GetRoomDescription();
    }
}
