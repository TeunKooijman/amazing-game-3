using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazingGame3.Infrastructure
{
    public interface IColorParser
    {
        public string Parse(string line, Func<string, string, string, string, string> replaceFunc);
    }

    public class ColorParser : IColorParser
    {
        public string Parse(string line, Func<string, string, string, string, string> replaceFunc)
        {
            while (true)
            {
                Match match = GameEngine.COLOR_REGEX.Match(line);
                if (match.Success == false)
                {
                    break;
                }

                Group[] groups = match.Groups.Values.ToArray();
                Group wholeMatch = groups[0];
                Group openingBracket = groups[1];
                Group text = groups[2];
                Group closingBracket = groups[3];

                line = replaceFunc.Invoke(line, wholeMatch.Value, text.Value, "#" + openingBracket);
            }

            return line;
        }
    }
}
