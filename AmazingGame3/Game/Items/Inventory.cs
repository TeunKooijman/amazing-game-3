using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Items.Instances;

namespace AmazingGame3
{
    public class Inventory
    {
        public List<IItem> Items { get; }

        public Inventory()
        {
            Items = new List<IItem>()
            {
                new MegaBonk()
            };
        }

        public bool HasItem(int itemId)
        {
            return Items.Any(item => item.GetId() == itemId);
        }

        internal async Task AddAsync(IItem itemToAdd, IRemoteConsole console)
        {
            Items.Add(itemToAdd);
            await console.WriteLineAsync($"Je stopt een  '{itemToAdd.GetName().Pastel(GameEngine.COLOR_ITEM)}' in dat krappe broekzakkie van je.");
        }

        internal async Task<bool> RemoveFirstOfTypeAsync<TItem>(IRemoteConsole console)
            where TItem : IItem
        {
            TItem? item = Items.OfType<TItem>().FirstOrDefault();
            if(item == null)
            {
                return false;
            }
            else
            {
                await console.WriteLineAsync($"Daar gaat je '{item.GetName().Pastel(GameEngine.COLOR_ITEM)}'. Jammer joh.");
                Items.Remove(item);
                return true;
            }
        }
    }
}