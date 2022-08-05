using AmazingGame3.Rooms;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Items.Instances
{
    public class GoudenMuntje : IItem
    {
        public static int ID = 3;
        public int GetId() => ID;

        public string GetName()
        {
            return "Gouden Muntje";
        }

        public string GetDescription()
        {
            return "Als ik er hier tien van verzamel ga ik denk ik wel snel.";
        }

        public void OnUse(GameState state)
        {
            Console.WriteLine("Weenie man. Doet niet zo veel.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
        }
    }
}
