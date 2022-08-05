using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances.Boulderhal.Move1;
using Pastel;

namespace AmazingGame3.Rooms.Instances.Boulderhal
{
    public class Easy7A : IRoom
    {
        public static bool HasUsedMagnesium = false;
        public static int MoveAttempts = 0;

        public static int ID = 931;
        public int GetId() => ID;

        public IRoom[] GetExits()
        {
            return new IRoom[]
            {
                RoomProvider.GetRoom(KleinCrimpi1.ID),
                RoomProvider.GetRoom(FlinkeJug1.ID),
                RoomProvider.GetRoom(ForseHold1.ID)
            };
        }

        public string GetName()
        {
            return "Easy 7A";
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
                Je loopt naar de easy 7a. Terwijl je er op af loopt heb je in je hoofd al uitgevogeld hoe je deze gaat flashen.

                Als je omhoog kijkt zie je opeens Lüna vastgebonden bovenop de muur. Je moet haar redden!

                Uit woede maak je een koprol richting de muur. Klaar om dit varkentje te wassen.
            ";
        }

        public bool CanExitRoomTo(GameState state, IRoom exit)
        {
            if(HasUsedMagnesium == false)
            {
                Console.WriteLine("Hoe denk je dit te kunnen doen met die glibberige slijmerige handjes van je?".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            MoveAttempts += 1;

            if(exit is FlinkeJug1)
            {
                Console.WriteLine("Jij dacht zeker aan een ander soort ‘flinke jug’? Je probeert de hold vast te pakken maar je hebt niet de focus om hem vast te houden.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }
            
            if(exit is ForseHold1)
            {
                Console.WriteLine("Prima hold, maar net te ver om vast te pakken.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
                return false;
            }

            if(MoveAttempts == 1)
            {
                Console.WriteLine("Raad dat mannetje gewoon in één keer de goede hold joh.".Pastel(Engine.COLOR_INTERMEDIATE_TEXT));
            }

            return true;
        }
    }
}