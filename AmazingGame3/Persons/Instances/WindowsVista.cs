using AmazingGame3.Dialogs;
using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Stater;
using Pastel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class WindowsVista : IPerson
    {
        public static bool HasBeenAtToeganspoortjes = false;

        public static int ID = 172324;
        public int GetId() => ID;

        public string GetName()
        {
            return "Windows Vista";
        }

        public string GetDescription()
        {
            return "Je Windows Vista omgeving op een tering slome VDI.";
        }

        public DialogSegment GetDialog(GameState state)
        {
            return new DialogBuilder("Wat ga je typen?")
                .AddResponse("using System;\r\n\r\nnamespace Gemboxx.HypothekenBox\r\n{\r\n\tpublic static void Main()\r\n\t{\r\n\t\tConsole.WriteLine(\"Hello world!\");\r\n\t}\r\n}\r\n", onChosen: state => 
                {
                    Console.WriteLine("\"In één keer goed! Wat een ventje.\" zegt Visual Studio".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                    Console.WriteLine("");
                    Console.WriteLine("In luttele uren schrijf je 84 story points weg. Fantastisch! Je checkt in, en kijkt niet eens of de CI pipeline wel goed gaat. ".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                    Console.WriteLine("Je ontvangt twee Gouden Muntjes voor je werkzaamheden.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                    Console.WriteLine("Je ziet dat Teun ook één checkin heeft gedaan. Hij ontvangt 20 Gouden Muntjes.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                    Console.WriteLine("");
                    state.Inventory.Add(new GoudenMuntje());
                    state.Inventory.Add(new GoudenMuntje());
                    Console.WriteLine("");
                    Console.WriteLine("Je wacht tot Emile naar de WC gaat zodat je geen gedag hoeft te zeggen, en rent vervolgens naar beneden.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                    Console.WriteLine("");
                    state.CurrentRoom = RoomProvider.GetRoom(StaterLobby.ID);
                })
                .Build();
        }
    }
}
