using AmazingGame3.Dialogs;
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
        public DialogSegment GetDialog(GameState state);
    }
}
