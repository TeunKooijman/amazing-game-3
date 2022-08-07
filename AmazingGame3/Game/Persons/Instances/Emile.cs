using AmazingGame3.Dialogs;
using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Stater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class Emile : PersonBase
    {
        public static bool HasBeenAtToeganspoortjes = false;
        public static int ID = 9317;

        public const string DESCRIPTION = @"....,⠀⠀⠀⠀⠀⠀⠀,....
.'⠀,,,⠀'.⠀⠀⠀.'⠀,,,⠀'.
⠀.`⠀⠀⠀`.⠀⠀⠀⠀⠀.`⠀⠀⠀`.
:⠀.....⠀:⠀⠀⠀:⠀.....⠀:
:`~'-'⠀-`:⠀⠀⠀:`-'-'~`:
⠀`.~-`.'⠀⠀⠀⠀⠀`.~`'.'
⠀⠀⠀```⠀⠀⠀___⠀⠀⠀```
⠀⠀⠀⠀⠀⠀⠀(⠀.⠀.⠀).._..
⠀⠀⠀⠀⠀⠀.'⠀⠀⠀⠀⠀'.
⠀⠀⠀⠀⠀`.~~~~~~~.`
⠀⠀⠀⠀⠀⠀⠀`-...-`";

        public Emile() 
            : base(ID, name: "Emile", description: DESCRIPTION)
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            return new DialogBuilder("Hee Jasper! Is je ZZP werk voor mijn bedrijf al klaar? Ik had je gisteren en vanochtend en op de wc en van het weekend en tijdens de seks er nog over gebeld, maar je nam steeds niet op! Waren vast die 5G zendmasten die je tijdelijk gehypnotiseerd hadden.")
                .AddResponse("Ja vast", "Anyway, hier is een video van ik die een vies wijf aan het neuken ben. Dat daar is mijn piemel. En dat is die van haar geloof ik. Ik zal je de video even door appen.", continuation =>
                {
                    continuation.AddResponse("Nee doe maar n...", "Zijn Ljüna en jij nog steeds monogaam trouwens of kan ik ondertussen al een keertje? Monogaam zijn is toch ouderwets, is bedacht door de middeleeuwse elite om onze vrijheden in te perken en de macht aan vrouwen over te dragen. Vieze sletten.", continuation =>
                    {
                        continuation.AddResponse("Ahh ja", "Wat kom je eigenlijk nog doen hier? Moet jij nog werken voor je gouden munten? Ik heb al lang 10 goud. En een tering snelle auto. Daar heb ik trouwens Princess Peach nog in geneukt laatst toen ik aan het wachten was op mijn vrouw die ik net had afgezet bij Donkey Kong. Okee het was Birdo, niet Princess Peach. Ik app je de video.", continuation =>
                        {
                            continuation.AddResponse("Nee! Hoeft n...", "Heb trouwens een tering grote geluidsinstallatie weer gekocht. Die van vorige maand was ondertussen wel wat verouderd. Heb die maar weer verkocht, was maar een verlies van 60%.", continuation =>
                            {
                                continuation.AddResponse("Ohh ja..", "Kon 'm opzich ook in mijn tering snelle waggie installeren, maar daar zat al een geluidsinstallatie in van heb ik jou daar. Subwoofer van twee terawatt. Vinden de wijven echt super, die worden daar botertje geil van. Ik app je wel even een video door.", continuation => 
                                {
                                    continuation.AddResponse("...", "Over die middeleeuwse elite trouwens hè, die staan regelrecht in verbinding met George Soros en Bill Gates, allemaal met als doel om ...", onChosenAsync: async state =>
                                    {
                                        await console.WriteLineAsync("Emile dwaalt af in de zoveelste tirade over verkiezingsfraude en microchips. Langzaam maar zeker draai je je hoofd richting je beeldscherm, en begint te werken.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                                        state.CurrentRoom = roomProvider.GetRoom(BeeldschermRoom.ID);
                                    });
                                });
                            });
                        });
                    });
                })
                .Build();
        }
    }
}
