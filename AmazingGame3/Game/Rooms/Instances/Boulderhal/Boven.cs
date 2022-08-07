using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move1;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class Boven : RoomBase
    {
        public static int ID = 73163;

        public Boven()
            : base(ID, "Boven")
        {

        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(LunaBoulder.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Eenmaal naar boven geklommen zie je een angstige Lœna vastgebonden liggen. Je doet een klein knikje haar kant op, roept ""ik ben hier"".
                
                Je pakt je mobiel uit je broekzakje en registreert je flash op toplogger.
            ";
        }

    }
}
