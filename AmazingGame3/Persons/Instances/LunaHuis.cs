using AmazingGame3.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class LunaHuis : IPerson
    {
        public static int ID = 1;
        public int GetId() => ID;

        public string GetName()
        {
            return "Ljuna";
        }

        public string GetDescription()
        {
            return "Je wijf.";
        }

        public DialogSegment GetDialog(GameState state)
        {
            return new DialogBuilder("Ohh Jasper wat ben je toch groot en sterk. Alleen jammer van je kleine piemel.")
                .AddResponse("Dat klopt.", "Ik laat helemaal een slakkenspoor achter.", continuation =>
                {
                    continuation.AddResponse("Iel");
                    continuation.AddResponse("Lekker");
                })
                .AddResponse("Dat klopt zeker.", "Ik laat helemaal een slakkenspoor achter.", continuation =>
                {
                    continuation.AddResponse("Iel");
                    continuation.AddResponse("Lekker");
                })
                .Build();
        }
    }
}
