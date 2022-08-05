using AmazingGame3.Items;
using AmazingGame3.Items.Instances;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using Pastel;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class VoorToeganspoortje : IRoom
    {
        public static int ID = 5;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(AchterHetToegangspoortje.ID),
                RoomProvider.GetRoom(StaterLobby.ID),
            };
        }

        public string GetName()
        {
            return "Toegangspoortje";
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
                Je staat voor het toegangspoortje. Spannend.";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            if(exit is AchterHetToegangspoortje && state.Inventory.HasItem(Toegangspasje.ID) == false)
            {
                Console.WriteLine(@"
                    Je gaat in de rij staan voor de draaideur naar binnen. Op het moment dat je aan de beurt bent, kom je tot de conclusie dat je je pasje helemaal niet bij je hebt. Shit! Iedereen kijkt afwachtend naar wat je gaat doen. Ze zien allemaal dat je je pasje vergeten bent! Wat een kluns! Echt heel dom. Je hoort ze tegen elkaar mompelen ""wat een kanker sukkel"". 

                    Shit man, je moet een dagpas halen bij Tjeerd!.
                ".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));

                Tjeerdje.HasBeenAtToeganspoortjes = true;
                return false;
            }

            return true;
        }
    }
}