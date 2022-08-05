using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move2;
using Pastel;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class KleinCrimpi1 : IRoom
    {
        public static int ID = 931231;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(MegaSloper2.ID),
                RoomProvider.GetRoom(FlinkeJug2.ID),
                RoomProvider.GetRoom(ForseHold2.ID)
            };
        }

        public string GetName()
        {
            return "Klein Crimpi";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {

            };
        }

        public string GetRoomDescription()
        {
            return @"";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            if(exit is FlinkeJug2)
            {
                Console.WriteLine("Je had op een jug pils gehoopt hè?. Je moet klimmen mannetje.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            if(exit is MegaSloper2)
            {
                Console.WriteLine("Deze sloper is bijna net zo mega als Jeroen z’n moeder. Te groot om vast te pakken dus.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            Console.WriteLine("Met alle wilskracht die je op kan roepen doe je een sicke dyno om de forse hold vast te pakken. Nat van het angstzweet mompel je \"...gemakkelijke klap\".".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
            return true;
        }
    }
}