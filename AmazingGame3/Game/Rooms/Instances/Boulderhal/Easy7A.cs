using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move1;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class Easy7A : RoomBase
    {
        public static bool HasUsedMagnesium = false;
        public static int MoveAttempts = 0;

        public static int ID = 931;

        public Easy7A()
            : base(ID, "Easy 7A")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(KleinCrimpi1.ID),
                provider.GetRoom(FlinkeJug1.ID),
                provider.GetRoom(ForseHold1.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je loopt naar de easy 7a. Terwijl je er op af loopt heb je in je hoofd al uitgevogeld hoe je deze gaat flashen.

                Als je omhoog kijkt zie je opeens Lüna vastgebonden bovenop de muur. Je moet haar redden!

                Uit woede maak je een koprol richting de muur. Klaar om dit varkentje te wassen.
            ";
        }

        public override async Task<bool> CanExitRoomToAsync(GameState state, IRoom exit, IRemoteConsole console)
        {
            if(HasUsedMagnesium == false)
            {
                await console.WriteLineAsync("Hoe denk je dit te kunnen doen met die glibberige slijmerige handjes van je?".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            MoveAttempts += 1;

            if(exit is FlinkeJug1)
            {
                await console.WriteLineAsync("Jij dacht zeker aan een ander soort ‘flinke jug’? Je probeert de hold vast te pakken maar je hebt niet de focus om hem vast te houden.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }
            
            if(exit is ForseHold1)
            {
                await console.WriteLineAsync("Prima hold, maar net te ver om vast te pakken.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            if(MoveAttempts == 1)
            {
                await console.WriteLineAsync("Raad dat mannetje gewoon in één keer de goede hold joh.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
            }

            return true;
        }
    }
}