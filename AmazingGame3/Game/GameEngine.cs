using AmazingGame3.Dialogs;
using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items;
using AmazingGame3.Items.Instances;
using AmazingGame3.Persons;
using AmazingGame3.Rooms;
using System.Text.RegularExpressions;

namespace AmazingGame3
{
    public class GameEngine
    {
        private GameState State { get; }
        private IRemoteConsole Console { get; }
        private IRoomProvider RoomProvider { get; }
        private IPersonProvider PersonProvider { get; }

        public GameEngine(GameState state, IRemoteConsole console, IRoomProvider roomProvider, IPersonProvider personProvider)
        {
            State = state;
            Console = console;
            RoomProvider = roomProvider;
            PersonProvider = personProvider;
        }

        private const string ACTION_PREFIX_LOOK_AT = "Kijk naar";
        private const string ACTION_PREFIX_GO_TO = "Ga naar";
        private const string ACTION_PREFIX_USE = "Misbruik";
        private const string ACTION_PREFIX_TALK_TO = "Babbel met";
        private const string ACTION_PREFIX_INSPECT_INVENTORY = "Wat zit er eigenlijk allemaal in mijn zakje?";
        private const string CHEAT_GIVE_ITEM = "CHEAT GIVE ITEM";

        public static readonly Regex COLOR_REGEX = new Regex("{{#([0-9A-F]{6}|[0-9a-f]{6})}}([^{{/]*){{\\/#([0-9A-F]{6}|[0-9a-f]{6})\\/}}");

        public const string COLOR_ROOM = "#A52A2A";
        public const string COLOR_PERSON = "#488214";
        public const string COLOR_ITEM = "#79CDCD";
        public const string COLOR_ERROR = "#FF0000";
        public const string COLOR_THEIR_TEXT = "#FFA500";
        public const string COLOR_INTERMEDIATE_TEXT = "#F37970";

        public async Task RunAsync()
        {
            await Console.WriteLineAsync("Welkom bij AmazingGame3. Like en subscribe en forward deze e-mail naar 15 mensen, anders heb je 20 jaar pech en krijg je een SOA.");
            await Console.WriteLineAsync("AmazingGame3 is een hypermodern, state-of-the-fart game. Gebruik je inteligentie om deze virtuele game wereld te beïnvloeden.");
            await Console.WriteLineAsync("");
            await RenderInstructionsAsync();
            await Console.WriteLineAsync("");
            await Console.WriteLineAsync("Joe.");
            await Console.WriteLineAsync("Submit any domme key om te continuen.");

            await Console.ReadLineAsync();
            await Console.ClearAsync();

            await RenderInstructionsAsync();

            while (State.IsGameFinished == false)
            {
                await RenderCurrentRoomAsync();
                await Console.WriteLineAsync("");
                await ProcessInputAsync(await Console.ReadLineAsync());
            }

            await Console.WriteLineAsync("Gewonnen!");
        }

        public async Task RenderInstructionsAsync()
        {
            await Console.WriteLineAsync($"Zeg '{ACTION_PREFIX_LOOK_AT} {{{"object".Pastel(COLOR_ITEM)}/{"locatie".Pastel(COLOR_ROOM)}}}' om te kijken naar een object of persoon.");
            await Console.WriteLineAsync($"Zeg '{ACTION_PREFIX_GO_TO} {{{"locatie".Pastel(COLOR_ROOM)}}}' om je door deze wereld te begeven.");
            await Console.WriteLineAsync($"Zeg '{ACTION_PREFIX_USE} {{{"object".Pastel(COLOR_ITEM)}}}' om objecten in deze wereld te misbruiken.");
            await Console.WriteLineAsync($"Zeg '{ACTION_PREFIX_TALK_TO} {{{"persoon".Pastel(COLOR_PERSON)}}}' om met individueen te praten.");
            await Console.WriteLineAsync($"Zeg '{ACTION_PREFIX_INSPECT_INVENTORY}' om je inventory te bekijken.");
        }

        public async Task RenderCurrentRoomAsync()
        {
            await RenderRoomAsync(State.CurrentRoom);
        }

        private async Task RenderRoomAsync(IRoom targetRoom)
        {
            await Console.WriteLineAsync("");
            await Console.WriteLineAsync($"Je bent in '{targetRoom.GetName().Pastel(COLOR_ROOM)}'");
            await Console.WriteLineAsync(targetRoom.GetRoomDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
            await Console.WriteLineAsync("");
            await RenderPersonsAsync(targetRoom.GetPersons(PersonProvider));
            await RenderExitsAsync(targetRoom.GetExits(RoomProvider));
        }

        private async Task RenderExitsAsync(IRoom[] exitRooms)
        {
            if(exitRooms.Length == 0)
            {
                return;
            }

            await Console.WriteLineAsync("Je ziet " + string.Join(", ", exitRooms.Select(exit => exit.GetName().Pastel(COLOR_ROOM))));
        }

        private async Task RenderPersonsAsync(IPerson[] persons)
        {
            if (persons.Length == 0)
            {
                return;
            }

            await Console.WriteLineAsync("Je ziet " + string.Join(", ", persons.Select(person => person.GetName().Pastel(COLOR_PERSON))));
        }

        public async Task ProcessInputAsync(string? input)
        {
            await Console.ClearAsync();
            await RenderInstructionsAsync();
            await Console.WriteLineAsync("");

            if (string.IsNullOrWhiteSpace(input))
            {
                await Console.WriteLineAsync("Je moet wel wat zeggen Pietertje.".Pastel(COLOR_ERROR));
            }

            if (input!.StartsWith(ACTION_PREFIX_INSPECT_INVENTORY))
            {
                await Console.WriteLineAsync("Je broekzakje zit vol met: ");
                foreach(IItem item in State.Inventory.Items)
                {
                    await Console.WriteLineAsync("\t- " + item.GetName().Pastel(COLOR_ITEM));
                }
            }
            else if (input!.StartsWith(CHEAT_GIVE_ITEM))
            {
                string[] split = input.Split(CHEAT_GIVE_ITEM);
                if(split.Length < 1)
                {
                    await Console.WriteLineAsync("Die cheat ken ik niet".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    if(target.Equals("GoudenMuntje"))
                    {
                        await State.Inventory.AddAsync(new GoudenMuntje(), Console);
                    }
                    else
                    {
                        await Console.WriteLineAsync($"Item '{target}' ken ik niet.".Pastel(COLOR_ERROR));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_LOOK_AT))
            {
                string[] split = input.Split(ACTION_PREFIX_LOOK_AT);
                if(split.Length < 1)
                {
                    await Console.WriteLineAsync($"Je doet je ogen dicht een beeld je een '{input}' in. Er is in ieder geval geen echte '{input}' te bekennen hier.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IPerson? foundPerson = State.CurrentRoom.GetPersons(PersonProvider).FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundPerson == null)
                    {
                        IItem? foundItem = State.Inventory.Items.FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                        if(foundItem == null)
                        {
                            IRoom? foundExit = State.CurrentRoom.GetExits(RoomProvider).FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                            if (foundExit == null)
                            {
                                await Console.WriteLineAsync($"Kweenie man. Er is hier geen '{target}'.".Pastel(COLOR_ERROR));
                            }
                            else
                            {
                                await Console.WriteLineAsync("Je kijkt naar " + target + " en je ziet:");
                                await Console.WriteLineAsync(foundExit.GetName().Pastel(COLOR_INTERMEDIATE_TEXT));
                                await Console.WriteLineAsync("Ik weet niet wat je hiervan had verwacht.".Pastel(COLOR_INTERMEDIATE_TEXT));
                            }
                        }
                        else
                        {
                            await Console.WriteLineAsync("Je kijkt naar " + target + " en je ziet:");
                            await Console.WriteLineAsync(foundItem.GetDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
                        }
                    }
                    else
                    {
                        await Console.WriteLineAsync("Je kijkt naar " + target + " en je ziet:");
                        await Console.WriteLineAsync(foundPerson.GetDescription().Pastel(COLOR_INTERMEDIATE_TEXT));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_USE))
            {
                string[] split = input.Split(ACTION_PREFIX_USE);
                if (split.Length < 1)
                {
                    await Console.WriteLineAsync("Dit snap ik echt niet hoor.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IItem? foundItem = State.Inventory.Items.FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if (foundItem == null)
                    {
                        IPerson? person = State.CurrentRoom.GetPersons(PersonProvider).FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                        if(person == null)
                        {
                            await Console.WriteLineAsync($"Je hebt helemaal geen '{target}' in je inventory, dom joch.".Pastel(COLOR_ERROR));
                        }
                        else
                        {
                            await Console.WriteLineAsync("Geen mensen misbruiken alsjeblieft. Dit spel is PG8.".Pastel(COLOR_INTERMEDIATE_TEXT));
                        }
                    }
                    else
                    {
                        await foundItem.OnUseAsync(State, Console);
                    }
                }
            }
            else if(input!.StartsWith(ACTION_PREFIX_TALK_TO))
            {
                string[] split = input.Split(ACTION_PREFIX_TALK_TO);
                if(split.Length < 1)
                {
                    await Console.WriteLineAsync("Je praat wat in jezelf. Ik begreep in ieder geval niet wat je wel wilde.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IPerson? foundPerson = State.CurrentRoom.GetPersons(PersonProvider).FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundPerson == null)
                    {
                        await Console.WriteLineAsync($"Ik weet niet wie '{target}' is.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        await EnterDialogAsync(foundPerson.GetDialog(State, RoomProvider, Console));
                    }
                }
            }
            else if (input!.StartsWith(ACTION_PREFIX_GO_TO))
            {
                string[] split = input.Split(ACTION_PREFIX_GO_TO);
                if(split.Length < 1)
                {
                    await Console.WriteLineAsync("Ja blijft staan waar je staat. Ik heb namelijk echt geen idee wat je van me wil.".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IRoom? foundRoom = State.CurrentRoom.GetExits(RoomProvider).FirstOrDefault(e => e.GetName().Equals(target, StringComparison.InvariantCultureIgnoreCase));
                    if(foundRoom == null)
                    {
                        await Console.WriteLineAsync($"Zie jij spoken ofzo? Ik zie in ieder geval geen '{target}'.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        if(await State.CurrentRoom.CanExitRoomToAsync(State, foundRoom, Console))
                        {
                            State.CurrentRoom = foundRoom;
                        }
                    }
                }
            }
            else
            {
                await Console.WriteLineAsync("Maat, wat doe je.".Pastel(COLOR_ERROR));
            }
        }

        private async Task EnterDialogAsync(DialogSegment dialog)
        {
            DialogSegment? currentSegment = dialog;
            while(currentSegment != null)
            {
                await Console.WriteLineAsync($"\"{currentSegment.Text}\"".Pastel(COLOR_THEIR_TEXT));
                if(currentSegment.Responses.Count == 0)
                {
                    break;
                }
                await Console.WriteLineAsync("");

                for(int i = 0; i < currentSegment.Responses.Count; i ++)
                {
                    string response = currentSegment.Responses[i].Response;
                    await Console.WriteLineAsync($"[{i}] - {response}");
                }

                while(true)
                {
                    string? input = await Console.ReadLineAsync();
                    if(string.IsNullOrWhiteSpace(input))
                    {
                        await Console.WriteLineAsync($"Zeg gewoon.".Pastel(COLOR_ERROR));
                    }
                    else if(int.TryParse(input, out int responseIndex) == false)
                    {
                        await Console.WriteLineAsync($"Zeg gewoon. Aan '{input}' heb ik niets.".Pastel(COLOR_ERROR));
                    }
                    else if(responseIndex < 0)
                    {
                        await Console.WriteLineAsync("Jij denkt slim te zijn hè. Jammer joh.".Pastel(COLOR_ERROR));
                    }
                    else if(responseIndex >= currentSegment.Responses.Count)
                    {
                        await Console.WriteLineAsync("Je hebt de geheime optie gevonden! Nee joh geintje, je bent gewoon een kut joch dat probeert vals te spelen.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        DialogResponse selectedResponse = currentSegment.Responses[responseIndex];
                        await selectedResponse.OnChosenAsync(State);
                        currentSegment = selectedResponse.NextSegment;
                        break;
                    }

                    await Console.WriteLineAsync("Nou probeer nog maar een keer stinkventje.".Pastel(COLOR_ERROR));
                }
            }
        }
    }
}