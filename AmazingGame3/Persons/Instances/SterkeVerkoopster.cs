using AmazingGame3.Dialogs;
using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Boulderhal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class SterkeVerkoopster : IPerson
    {
        public static int ID = 2;
        public int GetId() => ID;

        public string GetDescription()
        {
            return "Een prima wijfie.";
        }


        public string GetName()
        {
            return "Sterke Verkoopster";
        }

        public DialogSegment GetDialog(GameState state)
        {
            DialogBuilder builder = new DialogBuilder("Hallo! Wil jij een kaartje kopen?")
                .AddResponse("Nee, ga weg.");

            if(state.Inventory.HasItem(GoudenMuntje.ID))
            {
                builder.AddResponse("Nou, dat lijkt mij wel wat! Lekker klimmen en klauteren.", "Leuk! Ik zie echter wel dat je wat gladde handjes hebt. Wil je ook wat magnesium kopen?", continuation => 
                {
                    continuation.AddResponse("Ja", "Dat is dan één gouden muntje voor de entré, en één gouden muntje voor het magnesium! Kom maar in me. Ik bedoel binnen.", onChosen: state => 
                    {
                        state.Inventory.RemoveFirstOfType<GoudenMuntje>();
                        state.Inventory.RemoveFirstOfType<GoudenMuntje>();

                        state.Inventory.Add(new Magnesium());
                        state.CurrentRoom = RoomProvider.GetRoom(KlimGedeelte.ID);
                    });

                    continuation.AddResponse("Nee", "Doe toch maar rotjoch.", continuation => 
                    {
                        continuation.AddResponse("Okee.", "Dat is dan één gouden muntje voor de entré, en één gouden muntje voor het magnesium! Kom maar in me. Ik bedoel binnen.", onChosen: state =>
                        {
                            state.Inventory.RemoveFirstOfType<GoudenMuntje>();
                            state.Inventory.RemoveFirstOfType<GoudenMuntje>();

                            state.Inventory.Add(new Magnesium());
                            state.CurrentRoom = RoomProvider.GetRoom(KlimGedeelte.ID);
                        });
                    });
                });
            }
            else
            {
                builder.AddResponse("Nou, dat lijkt mij wel wat! Lekker klimmen en klauteren.", "Huh maar je hebt geen munt dom joch.");
            }

            return builder.Build();
        }
    }
}
