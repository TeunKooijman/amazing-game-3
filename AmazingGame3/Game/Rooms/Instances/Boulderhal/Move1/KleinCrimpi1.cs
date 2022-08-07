using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move2;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class KleinCrimpi1 : RoomBase
    {
        public static int ID = 931231;

        public KleinCrimpi1()
            : base(ID, "Klein Crimpi")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(MegaSloper2.ID),
                provider.GetRoom(FlinkeJug2.ID),
                provider.GetRoom(ForseHold2.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"Je pakt het crimpi vast met je duim en je pink. Werkt prima.";
        }

        public override async Task<bool> CanExitRoomToAsync(GameState state, IRoom exit, IRemoteConsole console)
        {
            if(exit is FlinkeJug2)
            {
                await console.WriteLineAsync("Je had op een jug pils gehoopt hè?. Je moet klimmen mannetje.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            if(exit is MegaSloper2)
            {
                await console.WriteLineAsync("Deze sloper is bijna net zo mega als Jeroen z’n moeder. Te groot om vast te pakken dus.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            await console.WriteLineAsync("Met alle wilskracht die je op kan roepen doe je een sicke dyno om de forse hold vast te pakken. Nat van het angstzweet mompel je \"...gemakkelijke klap\".".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT));
            return true;
        }
    }
}
