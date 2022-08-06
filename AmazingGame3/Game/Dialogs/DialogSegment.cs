using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Dialogs
{
    public class DialogSegment
    {
        public string Text { get; }
        public List<DialogResponse> Responses { get; }

        public DialogSegment(string text, List<DialogResponse> responses)
        {
            Text = text;
            Responses = responses;
        }
    }
}
