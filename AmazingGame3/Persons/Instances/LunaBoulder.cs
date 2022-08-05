using AmazingGame3.Dialogs;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Bar;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class LunaBoulder : IPerson
    {
        public static int ID = 22;
        public int GetId() => ID;

        public string GetName()
        {
            return "Maantje";
        }

        public string GetDescription()
        {
            return "Je vastgebonden wijf.";
        }

        public DialogSegment GetDialog(GameState state)
        {
            return new DialogBuilder("Jasper wat fijn dat je me hebt gered. Bedankt en tot ziens.")
                .AddResponse("Wat? Gaan we niet eens neuken?", "Ohh ja", onChosen: state => { Console.WriteLine("Je trekt je broekie in één vloeiende beweging uit en gaat er in.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT)); }, buildAction: continuation =>
                {
                    continuation.AddResponse("Stoot 1", "Ooh", continuation => 
                    {
                        continuation.AddResponse("Stoot 2", "Aah", onChosen: state => { Console.WriteLine("Je bent klaar.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT)); }, buildAction: continuation => 
                        {
                            continuation.AddResponse("Laten we naar de Jans Bar gaan om te vieren. Eén biertje.", onChosen: state => 
                            {
                                state.CurrentRoom = RoomProvider.GetRoom(Jansbar.ID);
                            });
                        });
                    });
                })
                .Build();
        }
    }
}
