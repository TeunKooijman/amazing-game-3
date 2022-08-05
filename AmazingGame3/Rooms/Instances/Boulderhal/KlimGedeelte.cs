using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class KlimGedeelte : IRoom
    {
        public static int ID = 4;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(Easy7A.ID)
            };
        }

        public string GetName()
        {
            return "Klimgedeelte";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {

            };
        }

        public string GetRoomDescription()
        {
            return @"
                Je loopt de hal binnen. Je ziet meerdere bolders die voor jou te min zijn. In de hoek zie je een kalende man struggelen op een 2B voor kinderen. Het lijkt ook alsof hij schoenen heeft gekocht die eigenlijk voor kinderen bedoeld zijn; maatje 22.

                Je ziet hem hangen aan wat underclings. 
                Je hoort hem mompelen dat boulders eigenlijk een soort kubernetes clusters zijn van backend frameworks die aan elkaar gekoppeld zijn door API’s met verschillende abstractie lagen.
                Je kan maar beter uit de buurt blijven. ";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}