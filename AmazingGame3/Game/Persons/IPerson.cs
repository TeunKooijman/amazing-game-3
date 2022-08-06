using AmazingGame3.Dialogs;
using AmazingGame3.Infrastructure;
using AmazingGame3.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons
{
    public interface IPerson
    {
        public string GetDescription();
        public int GetId();
        public string GetName();
        public DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console);
    }

    public abstract class PersonBase : IPerson
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        protected PersonBase(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int GetId() => Id;
        public string GetName() => Name;
        public string GetDescription() => Description;

        public abstract DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console);

    }
}
