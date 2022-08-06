using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class AchterHetToegangspoortje : RoomBase
    {
        public static int ID = 8;

        public AchterHetToegangspoortje()
            : base(ID, "Achter het toegangspoortje")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(Lift.ID),
                provider.GetRoom(Trap.ID),
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je moet naar de vijfde verdieping. Ga je als een giga-chad met de trap, of als die vieze maagd dat je bent met de lift?";
        }
    }
}