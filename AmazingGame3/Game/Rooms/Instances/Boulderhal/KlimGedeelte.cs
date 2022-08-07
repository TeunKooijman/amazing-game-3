using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class KlimGedeelte : RoomBase
    {
        public static int ID = 4;

        public KlimGedeelte()
            : base(ID, "Klim Gedeelte")
        {

        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(KalendeMan.ID)
            };
        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(Easy7A.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Je loopt de hal binnen. Je ziet meerdere bolders die voor jou te min zijn. In de hoek zie je een kalende man struggelen op een 2B voor kinderen. Het lijkt ook alsof hij schoenen heeft gekocht die eigenlijk voor kinderen bedoeld zijn; maatje 22.

                Je ziet hem hangen aan wat underclings. 
                Je hoort hem mompelen dat boulders eigenlijk een soort kubernetes clusters zijn van backend frameworks die aan elkaar gekoppeld zijn door API’s met verschillende abstractie lagen.
                Je kan maar beter uit de buurt blijven. ";
        }
    }
}