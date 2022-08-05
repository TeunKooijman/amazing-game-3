using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Items.Instances
{
    public class MegaBonk : IItem
    {
        public static int ID = 1;
        public int GetId() => ID;

        public string GetName()
        {
            return "Megabonk";
        }

        public string GetDescription()
        {
            return "Huh, is dat zo'n Megabonk?";
        }

        public void OnUse(GameState state)
        {

        }
    }
}
