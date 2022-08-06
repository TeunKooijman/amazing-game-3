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
    public class WindowsVista : PersonBase
    {
        public static bool HasBeenAtToeganspoortjes = false;

        public static int ID = 172324;

        public WindowsVista()
            : base(ID, name: "Windows Vista", description: "Je Windows Vista omgeving op een tering slome VDI.")
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            return new DialogBuilder("Wat ga je typen?")
                .AddResponse("using System;\r\n\r\nnamespace Gemboxx.HypothekenBox\r\n{\r\n\tpublic static void Main()\r\n\t{\r\n\t\tConsole.WriteLine(\"Hello world!\");\r\n\t}\r\n}\r\n", onChosenAsync: async state => 
                {
                    await console.WriteLineAsync("\"In één keer goed! Wat een ventje.\" zegt Visual Studio".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                    await console.WriteLineAsync("");
                    await console.WriteLineAsync("In luttele uren schrijf je 84 story points weg. Fantastisch! Je checkt in, en kijkt niet eens of de CI pipeline wel goed gaat. ".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                    await console.WriteLineAsync("Je ontvangt twee Gouden Muntjes voor je werkzaamheden.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                    await console.WriteLineAsync("Je ziet dat Teun ook één checkin heeft gedaan. Hij ontvangt 20 Gouden Muntjes.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                    await console.WriteLineAsync("");
                    await state.Inventory.AddAsync(new GoudenMuntje(), console);
                    await state.Inventory.AddAsync(new GoudenMuntje(), console);
                    await console.WriteLineAsync("");
                    await console.WriteLineAsync("Je wacht tot Emile naar de WC gaat zodat je geen gedag hoeft te zeggen, en rent vervolgens naar beneden.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                    await console.WriteLineAsync("");
                    state.CurrentRoom = roomProvider.GetRoom(StaterLobby.ID);
                })
                .Build();
        }
    }
}
