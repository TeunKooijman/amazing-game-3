using AmazingGame3.Rooms;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Items.Instances
{
    public class Toegangspasje : IItem
    {
        public static int ID = 2;
        public int GetId() => ID;

        public string GetName()
        {
            return "Stater Toeganspasje";
        }

        public string GetDescription()
        {
            return "Het toeganspasje van Stater!";
        }

        public void OnUse(GameState state)
        {
            Console.WriteLine("Hoe wil je een pasje 'gebruiken'? Stap gewoon door de fucking poortjes.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
        }
    }
}
