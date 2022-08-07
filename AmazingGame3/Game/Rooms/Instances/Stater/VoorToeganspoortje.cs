using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Items.Instances;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class VoorToeganspoortje : RoomBase
    {
        public static int ID = 5;

        public VoorToeganspoortje()
            : base(ID, "Toegangspoortje")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(AchterHetToegangspoortje.ID),
                provider.GetRoom(StaterLobby.ID),
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je staat voor het toegangspoortje. Spannend.";
        }

        public override async Task<bool> CanExitRoomToAsync(GameState state, IRoom exit, IRemoteConsole console)
        {
            if(exit is AchterHetToegangspoortje && state.Inventory.HasItem(Toegangspasje.ID) == false)
            {
                await console.WriteLineAsync(@"
                    Je gaat in de rij staan voor de draaideur naar binnen. Op het moment dat je aan de beurt bent, kom je tot de conclusie dat je je pasje helemaal niet bij je hebt. Shit! Iedereen kijkt afwachtend naar wat je gaat doen. Ze zien allemaal dat je je pasje vergeten bent! Wat een kluns! Echt heel dom. Je hoort ze tegen elkaar mompelen ""wat een kanker sukkel"". 

                    Shit man, je moet een dagpas halen bij Tjeerd!.
                ".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));

                Tjeerdje.HasBeenAtToeganspoortjes = true;
                return false;
            }
            else if (exit is AchterHetToegangspoortje)
            {
                await console.WriteLineAsync("Als een glibberige aal wurm je je zo dat toegangspoortje door. Wat een mannetje.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return true;
            }

            return true;
        }
    }
}