using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Rooms.Instances.Boulderhal;
using AmazingGame3.Rooms.Instances.Boulderhal.Move2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Items.Instances
{
    public class Magnesium : IItem
    {
        public static int ID = 81;
        public int GetId() => ID;

        public string GetName()
        {
            return "Magnesium";
        }

        public string GetDescription()
        {
            return "Wit poeder.";
        }

        public async Task OnUseAsync(GameState state, IRemoteConsole console)
        {
            await console.WriteLineAsync("Je pakt je sleutels uit je zak en je neemt een lijntje. Was dit de bedoeling ja? Terwijl je twijfelt over je levenskeuzes stop je ook maar je vuistjes in de magnesium zak".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
            Easy7A.HasUsedMagnesium = true;
        }
    }
}
