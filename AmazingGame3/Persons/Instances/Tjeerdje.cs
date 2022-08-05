using AmazingGame3.Dialogs;
using AmazingGame3.Items.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class Tjeerdje : IPerson
    {
        public static bool HasBeenAtToeganspoortjes = false;

        public static int ID = 84124;
        public int GetId() => ID;

        public string GetName()
        {
            return "Tjeerdje";
        }

        public string GetDescription()
        {
            return "Je Tjeerdje.";
        }

        public DialogSegment GetDialog(GameState state)
        {
            DialogBuilder builder = new DialogBuilder("Hallo Jasper Maurice Van Noordenburg. Wat kan ik voor je doen?");

            if(HasBeenAtToeganspoortjes == false)
            {
                return builder
                    .AddResponse("Ja ik weet eigenlijk ook niet zo goed waarom ik hier naartoe kwam. De ballen.", "De ballen 2.")
                    .Build();
            }
            else
            {
                return builder
                    .AddResponse("Ik ben echt zo knettertje dom Tjeerd, ik ben alweer mijn pasje vergeten! Kan ik een dagpas krijgen?", "Ja whatever.", continuation =>
                    {
                        Action<GameState> onChosen = (state) => 
                        {
                            state.Inventory.Add(new Toegangspasje());
                        };
                        continuation.AddResponse("Bedankt makker maat.", onChosen);
                        continuation.AddResponse("Bedankt lekkertje.", onChosen);
                    })
                    .Build();
            }
        }
    }
}
