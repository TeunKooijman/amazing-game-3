using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class Trap : RoomBase
    {
        public static int ID = 141541;

        public Trap()
            : base(ID, "Trap")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(Werkplek.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Als een echte man, huppel je de trap op naar boven. Jezus wat ben jij toch gaaf. Je handen worden knuistjes. Wat gaaf!";
        }
    }
}