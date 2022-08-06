using AmazingGame3.Dialogs;
using AmazingGame3.Infrastructure;
using AmazingGame3.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class Deksletten : PersonBase
    {
        public static int ID = 81;

        public Deksletten()
            : base(ID, name: "De Deksletten", description: "Je Deksletten.")
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            return new DialogBuilder("Hee Jasper! We wachten al vet lang allemaal in je favoriete bar")
                .AddResponse("Snap ik.", "Omdat je jarig bent geweest en wij je zo'n malse makker vinden, willen wij je een cadeautje geven.", continuation =>
                {
                    continuation.AddResponse("Dat mag.", "Je hebt in je avontuur vandaag al veel clues gevonden over wat het zou kunnen zijn.", continuation => 
                    {
                        continuation.AddResponse("Ohh?", "Ga het maar snel uitpakken knaapje. Ga naar deze link: https://bit.ly/3JCsSd1", onChosenAsync: state => 
                        {
                            state.IsGameFinished = true;
                            return Task.CompletedTask;
                        });
                    });
                })
                .Build();
        }
    }
}
