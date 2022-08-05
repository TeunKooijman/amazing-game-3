using AmazingGame3.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class Deksletten : IPerson
    {
        public static int ID = 81;
        public int GetId() => ID;

        public string GetName()
        {
            return "De Deksletten";
        }

        public string GetDescription()
        {
            return "Je deksletten.";
        }

        public DialogSegment GetDialog(GameState state)
        {
            return new DialogBuilder("Hee Jasper! We wachten al vet lang allemaal in je favoriete bar")
                .AddResponse("Snap ik.", "Omdat je jarig bent geweest en wij je zo'n malse makker vinden, willen wij je een cadeautje geven.", continuation =>
                {
                    continuation.AddResponse("Dat mag.", "Je hebt in je avontuur vandaag al veel clues gevonden over wat het zou kunnen zijn.", continuation => 
                    {
                        continuation.AddResponse("Ohh?", "Ga het maar snel uitpakken knaapje. Ga naar deze link: https://bit.ly/3JCsSd1", onChosen: state => 
                        {
                            state.IsGameFinished = true;
                        });
                    });
                })
                .Build();
        }
    }
}
