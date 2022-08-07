using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class StaterLobby : RoomBase
    {
        public static bool HasCompletedWork = false;
        public static int ID = 3;

        public StaterLobby()
            : base(ID, "Stater Lobby")
        {

        }

        public override IRoom[] GetExits(IRoomProvider provider)
        {
            return new IRoom[]
            {
                provider.GetRoom(VoorToeganspoortje.ID),
                provider.GetRoom(BoulderhalStronk.ID)
            };
        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(Tjeerdje.ID)
            };
        }

        public override string GetRoomDescription()
        {
            if(HasCompletedWork == false)
            {
                return @"
                    Je loopt het gebouw binnen en ziet een groot spandoek hangen.

                    ""Stater bestaat 25 jaar! Dat moet groots geviert worden! Haal nu je sleutelhanger op en geniet van één gratis muffin!""
                ";
            }
            else
            {
                return @"
                    Je komt uitgeput beneden aan. Wie dat 'werken' ooit verzonnen heeft moeten ze echt een kappersklappie geven. Dat doen we dus nooit meer.
                ";
            }
        }
    }
}