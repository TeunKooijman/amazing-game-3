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
    public class LunaHuis : PersonBase
    {
        public static int ID = 1;

        public LunaHuis()
            : base(ID, name: "Ljuna", description: "Je wijf.")
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
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
