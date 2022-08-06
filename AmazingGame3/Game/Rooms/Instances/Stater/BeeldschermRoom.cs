using AmazingGame3.Items;
using AmazingGame3.Persons;
using AmazingGame3.Persons.Instances;

namespace AmazingGame3.Rooms.Instances.Stater
{
    public class BeeldschermRoom : RoomBase
    {
        public static int ID = 48323;

        public BeeldschermRoom()
            : base(ID, "Je Beeldscherm")
        {

        }

        public override IPerson[] GetPersons(IPersonProvider provider)
        {
            return new IPerson[]
            {
                provider.GetPerson(WindowsVista.ID)
            };
        }

        public override string GetRoomDescription()
        {
            return @"
                Er staat één verse user story op je naam. Hij is netjes ingeschat op 84 story points, en je manager heeft je zojuist een mailtje gestuurd dat het nog voor de lunch af moet.

	                Title: *As a Jasper, I would like to be able to run a program that greets the world with a hearty hello, so that I can prove once and for all that I _am_ a real software developer.*
	                Story Points: 84
	                Description: Write a complete, synchronous ""Hello World!"" program in C#, in the namespace ""Gemboxx.HypothekenBox"", taking string args from the command line.
            ";
        }
    }
}