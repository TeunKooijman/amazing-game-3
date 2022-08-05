using AmazingGame3.Dialogs;
using AmazingGame3.Items;
using AmazingGame3.Items.Instances;
using AmazingGame3.Persons;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Huis;
using Pastel;

namespace AmazingGame3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameState initialState = new GameState(RoomProvider.GetRoom(AmazingHuis3.ID));
            initialState.Inventory.Items.Add(new MegaBonk());

            Engine engine = new Engine(initialState);
            engine.Start();
            Console.WriteLine("Press any domme key om te continuen.");
            Console.ReadLine();
            Console.Clear();
            Engine.RenderInstructions();

            while (engine.State.IsGameFinished == false)
            {
                engine.RenderCurrentRoom();
                Console.WriteLine("");
                engine.ProcessInput(Console.ReadLine());
            }

            Console.WriteLine("Gewonnen!");
        }
    }

    public class Engine
    {
        public GameState State { get; }

        public Engine(GameState initialState)
        {
            State = initialState;
        }

        private const string ACTION_PREFIX_LOOK_AT = "Kijk naar";
        private const string ACTION_PREFIX_GO_TO = "Ga naar";
        private const string ACTION_PREFIX_USE = "Misbruik";
        private const string ACTION_PREFIX_TALK_TO = "Babbel met";
        private const string ACTION_PREFIX_INSPECT_INVENTORY = "Wat zit er eigenlijk allemaal in mijn zakje?";
        private const string CHEAT_GIVE_ITEM = "CHEAT GIVE ITEM";

        public const string COLOR_ROOM = "#A52A2A";
        public const string COLOR_PERSON = "#488214";
        public const string COLOR_ITEM = "#79CDCD";
        public const string COLOR_ERROR = "#FF0000";
        public const string COLOR_THEIR_TEXT = "#FFA500";
        public const string COLOR_INTERMEDIATE_TEXT = "#F37970";

        public void Start()
        {
            Console.WriteLine("Welkom bij AmazingGame3. Like en subscribe en forward deze e-mail naar 15 mensen, anders heb je 20 jaar pech en krijg je een SOA.");
            Console.WriteLine("AmazingGame3 is een hypermodern, state-of-the-fart game. Gebruik je inteligentie om deze virtuele game wereld te beïnvloeden.");
            Console.WriteLine("");
            RenderInstructions();
            Console.WriteLine("");
            Console.WriteLine("Joe.");
        }

        public static void RenderInstructions()
        {
            Console.WriteLine($"Zeg '{ACTION_PREFIX_LOOK_AT} {{{"object".Pastel(COLOR_ITEM)}/{"locatie".Pastel(COLOR_ROOM)}}}' om te kijken naar een object of persoon.");
            Console.WriteLine($"Zeg '{ACTION_PREFIX_GO_TO} {{{"locatie".Pastel(COLOR_ROOM)}}}' om je door deze wereld te begeven.");
            Console.WriteLine($"Zeg '{ACTION_PREFIX_USE} {{{"object".Pastel(COLOR_ITEM)}}}' om objecten in deze wereld te misbruiken.");
            Console.WriteLine($"Zeg '{ACTION_PREFIX_TALK_TO} {{{"persoon".Pastel(COLOR_PERSON)}}}' om met individueen te praten.");
            Console.WriteLine($"Zeg '{ACTION_PREFIX_INSPECT_INVENTORY}' om je inventory te bekijken.");
        }

        public void RenderCurrentRoom()
        {
            RenderRoom(State.CurrentRoom);
        }

        private void RenderRoom(IRoom targetRoom)
        {
            Console.WriteLine("");
            Console.WriteLine($"Je bent in '{targetRoom.GetName().Pastel(COLOR_ROOM)}'");
            Console.WriteLine(targetRoom.GetRoomDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
            Console.WriteLine("");
            RenderPersons(targetRoom.GetPersons());
            RenderExits(targetRoom.GetExits());

        }

        private void RenderExits(IRoom[] exitRooms)
        {
            if(exitRooms.Length == 0)
            {
                return;
            }

            Console.WriteLine("Je ziet " + string.Join(", ", exitRooms.Select(exit => exit.GetName().Pastel(COLOR_ROOM))));
        }

        private void RenderPersons(IPerson[] persons)
        {
            if (persons.Length == 0)
            {
                return;
            }

            Console.WriteLine("Je ziet " + string.Join(", ", persons.Select(person => person.GetName().Pastel(COLOR_PERSON))));
        }

        public void ProcessInput(string? input)
        {
            Console.Clear();
            Engine.RenderInstructions();
            Console.WriteLine("");

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Je moet wel wat zeggen Pietertje.".Pastel(COLOR_ERROR));
            }

            if (input!.StartsWith(ACTION_PREFIX_INSPECT_INVENTORY))
            {
                Console.WriteLine("Je broekzakje zit vol met: ");
                foreach(IItem item in State.Inventory.Items)
                {
                    Console.WriteLine("\t- " + item.GetName().Pastel(COLOR_ITEM));
                }
            }
            else if (input!.StartsWith(CHEAT_GIVE_ITEM))
            {
                string[] split = input.Split(CHEAT_GIVE_ITEM);
                if(split.Length < 1)
                {
                    Console.WriteLine("Die cheat ken ik niet".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    if(target.Equals("GoudenMuntje"))
                    {
                        State.Inventory.Add(new GoudenMuntje());
                    }
                    else
                    {
                        Console.WriteLine($"Item '{target}' ken ik niet.".Pastel(COLOR_ERROR));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_LOOK_AT))
            {
                string[] split = input.Split(ACTION_PREFIX_LOOK_AT);
                if(split.Length < 1)
                {
                    Console.WriteLine($"Je doet je ogen dicht een beeld je een '{input}' in. Er is in ieder geval geen echte '{input}' te bekennen hier.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IPerson? foundPerson = State.CurrentRoom.GetPersons().FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundPerson == null)
                    {
                        IItem? foundItem = State.Inventory.Items.FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                        if(foundItem == null)
                        {
                            IRoom? foundExit = State.CurrentRoom.GetExits().FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                            if (foundExit == null)
                            {
                                Console.WriteLine($"Kweenie man. Er is hier geen '{target}'.".Pastel(COLOR_ERROR));
                            }
                            else
                            {
                                Console.WriteLine("Je kijkt naar " + target + " en je ziet:");
                                Console.WriteLine(foundExit.GetName().Pastel(COLOR_INTERMEDIATE_TEXT));
                                Console.WriteLine("Ik weet niet wat je hiervan had verwacht.".Pastel(COLOR_INTERMEDIATE_TEXT));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Je kijkt naar " + target + " en je ziet:");
                            Console.WriteLine(foundItem.GetDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Je kijkt naar " + target + " en je ziet:");
                        Console.WriteLine(foundPerson.GetDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_USE))
            {
                string[] split = input.Split(ACTION_PREFIX_USE);
                if (split.Length < 1)
                {
                    Console.WriteLine("Dit snap ik echt niet hoor.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IItem? foundItem = State.Inventory.Items.FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if (foundItem == null)
                    {
                        IPerson? person = State.CurrentRoom.GetPersons().FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                        if(person == null)
                        {
                            Console.WriteLine($"Je hebt helemaal geen '{target}' in je inventory, dom joch.".Pastel(COLOR_ERROR));
                        }
                        else
                        {
                            Console.WriteLine("Geen mensen misbruiken alsjeblieft. Dit spel is PG8.".Pastel(COLOR_INTERMEDIATE_TEXT));
                        }
                    }
                    else
                    {
                        foundItem.OnUse(State);
                    }
                }
            }
            else if(input!.StartsWith(ACTION_PREFIX_TALK_TO))
            {
                string[] split = input.Split(ACTION_PREFIX_TALK_TO);
                if(split.Length < 1)
                {
                    Console.WriteLine("Je praat wat in jezelf. Ik begreep in ieder geval niet wat je wel wilde.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IPerson? foundPerson = State.CurrentRoom.GetPersons().FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundPerson == null)
                    {
                        Console.WriteLine($"Ik weet niet wie '{target}' is.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        EnterDialog(foundPerson.GetDialog(State));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_GO_TO))
            {
                string[] split = input.Split(ACTION_PREFIX_GO_TO);
                if(split.Length < 1)
                {
                    Console.WriteLine("Ja blijft staan waar je staat. Ik heb namelijk echt geen idee wat je van me wil.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IRoom? foundRoom = State.CurrentRoom.GetExits().FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundRoom == null)
                    {
                        Console.WriteLine($"Zie jij spoken ofzo? Ik zie in ieder geval geen '{target}'.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        if(State.CurrentRoom.CanExitRoomTo(State, foundRoom))
                        {
                            State.CurrentRoom = foundRoom;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Maat, wat doe je.".Pastel(COLOR_ERROR));
            }
        }

        private void EnterDialog(DialogSegment dialog)
        {
            DialogSegment? currentSegment = dialog;
            while(currentSegment != null)
            {
                Console.WriteLine($"\"{currentSegment.Text}\"".Pastel(COLOR_THEIR_TEXT));
                if(currentSegment.Responses.Count == 0)
                {
                    break;
                }
                Console.WriteLine("");

                for(int i = 0; i < currentSegment.Responses.Count; i ++)
                {
                    string response = currentSegment.Responses[i].Response;
                    Console.WriteLine($"[{i}] - {response}");
                }

                while(true)
                {
                    string? input = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine($"Zeg gewoon.".Pastel(COLOR_ERROR));
                    }
                    else if(int.TryParse(input, out int responseIndex) == false)
                    {
                        Console.WriteLine($"Zeg gewoon. Aan '{input}' heb ik niets.".Pastel(COLOR_ERROR));
                    }
                    else if(responseIndex < 0)
                    {
                        Console.WriteLine("Jij denkt slim te zijn hè. Jammer joh.".Pastel(COLOR_ERROR));
                    }
                    else if(responseIndex >= currentSegment.Responses.Count)
                    {
                        Console.WriteLine("Je hebt de geheime optie gevonden! Nee joh geintje, je bent gewoon een kut joch dat probeert vals te spelen.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        DialogResponse selectedResponse = currentSegment.Responses[responseIndex];
                        selectedResponse.OnChosen(State);
                        currentSegment = selectedResponse.NextSegment;
                        break;
                    }

                    Console.WriteLine("Nou probeer nog maar een keer stinkventje.".Pastel(COLOR_ERROR));
                }
            }
        }
    }

    public record GameState
    {
        public IRoom CurrentRoom { get; set; }
        public Inventory Inventory { get; }
        public bool IsGameFinished { get; set; }

        public GameState(IRoom initialRoom)
        {
            CurrentRoom = initialRoom;
            Inventory = new Inventory();
        }
    }

    public class Inventory
    {
        public List<IItem> Items { get; }

        public Inventory()
        {
            Items = new List<IItem>();
        }

        public bool HasItem(int itemId)
        {
            return Items.Any(item => item.GetId() == itemId);
        }

        internal void Add(IItem itemToAdd)
        {
            Items.Add(itemToAdd);
            Console.WriteLine($"Je stopt een  '{itemToAdd.GetName().Pastel(Engine.COLOR_ITEM)}' in dat krappe broekzakkie van je.");
        }

        internal bool RemoveFirstOfType<TItem>()
            where TItem : IItem
        {
            TItem? item = Items.OfType<TItem>().FirstOrDefault();
            if(item == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Daar gaat je '{item.GetName().Pastel(Engine.COLOR_ITEM)}'. Jammer joh.");
                Items.Remove(item);
                return true;
            }
        }
    }
}