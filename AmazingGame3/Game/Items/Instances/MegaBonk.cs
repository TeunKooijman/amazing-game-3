using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Items.Instances
{
    public class MegaBonk : IItem
    {
        public static int ID = 1;
        public int GetId() => ID;

        public string GetName()
        {
            return "Megabonk";
        }

        public string GetDescription()
        {
            return "Huh, is dat zo'n Megabonk?";
        }

        public async Task OnUseAsync(GameState state, IRemoteConsole console)
        {
            await console.WriteLineAsync("Je gaat op je knietjes zitten, pakt de MegaBonk in de hand en begint fervent te knikkeren. Je bent helemaal in je nopjes.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
        }
    }
}
