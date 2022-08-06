using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Extensions
{
    internal static class StringExtensions
    {
        internal static string Pastel(this string self, string colorHex)
        {
            return "{{" + colorHex + "}}" + self + "{{/" + colorHex + "/}}";
        }
    }
}
