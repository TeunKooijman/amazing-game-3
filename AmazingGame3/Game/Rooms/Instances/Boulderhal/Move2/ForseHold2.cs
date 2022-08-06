using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Boulderhal.Move2
{
    public class ForseHold2 : RoomBase
    {
        public static int ID = 76541;

        public ForseHold2()
            : base(ID, "Forse Hold")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(Boven.ID)
            };
        }

        public override string GetRoomDescription()
        {
            //Hier kom je nooit geloof ik.
            return @"";
        }
    }
}