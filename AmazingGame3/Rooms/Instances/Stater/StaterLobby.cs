using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class StaterLobby : IRoom
    {
        public static int ID = 3;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(VoorToeganspoortje.ID),
                RoomProvider.GetRoom(BoulderhalStronk.ID)
            };
        }

        public string GetName()
        {
            return "Stater Lobby";
        }

        public IPerson[] GetPersons()
        {
            return new IPerson[]
            {
                PersonProvider.GetPerson(Tjeerdje.ID)
            };
        }

        public string GetRoomDescription()
        {
            return @"
                Je loopt het gebouw binnen en ziet een groot spandoek hangen.

                ""Stater bestaat 25 jaar! Dat moet groots geviert worden! Haal nu je sleutelhanger op en geniet van één gratis muffin!""
            ";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            return true;
        }
    }
}