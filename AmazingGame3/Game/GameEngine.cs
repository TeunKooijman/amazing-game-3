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
        private const string CHEAT_GO_TO_ROOM = "CHEAT GO TO ROOM";

        public static readonly Regex COLOR_REGEX = new Regex("{{#([0-9A-F]{6}|[0-9a-f]{6})}}([^{]*){{\\/#([0-9A-F]{6}|[0-9a-f]{6})\\/}}");

        public const string COLOR_ROOM = "#A52A2A";
        public const string COLOR_PERSON = "#488214";
        public const string COLOR_ITEM = "#79CDCD";
        public const string COLOR_ERROR = "#FF0000";
        public const string COLOR_THEIR_TEXT = "#FFA500";
        public const string COLOR_INTERMEDIATE_TEXT = "#F37970";

        public async Task RunAsync()
        {
            await RenderAsciiArtAsync();
            await Console.WriteLineAsync("Welkom bij AmazingGame3. Like en subscribe en forward deze e-mail naar 15 mensen, anders heb je 20 jaar pech en krijg je een SOA.");
            await Console.WriteLineAsync("AmazingGame3 is een hypermodern, state-of-the-fart game. Gebruik je inteligentie om deze virtuele game wereld te beïnvloeden.");
            await Console.WriteLineAsync("");
            await RenderInstructionsAsync();
            await Console.WriteLineAsync("");
            await Console.WriteLineAsync("Joe.");
            await Console.WriteLineAsync("Druk die entertje om te continuen.");

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



            string dickbut = @"______________________________________JasperTeu_________________________________________
__________________________________nKelvinOlivierRob_____________________________________
______________________________bertKelvinJasperTeunKelv__________________________________
______________________inOlivierRobber___________tKelvinJ________________________________
___________________asperTeunKelv__________________inOlivi_______________________________
_________________erRobbertKelvin___________________Jasper_______________________________
_________________TeunKelvinOlivie___________________rRobb_______________________________
_________________ertKelvinJa_sperTe____unKelvinOli__vierR_______________________________
_________________obbertKelvinJasperT_eunKelvinOlivie_rRob_______________________________
_________________bertKelvinJasperT__eunKelvinOlivierRobbe_______________________________
________________rtKel__vinJasperTe__unKelvinOlivierRobber_______________________________
_______________tKelvinJasperTeunKel_vinOlivierR_obbertKel_______________________________
______________vinJasperTeunKelvin___OlivierRobbertKelvinJ_______________________________
_____________asperTeunKelvinOlivierRobbertKelvinJ__asper________________________________
____________TeunK__________elvinOlivierRobber_____tKelvi________________________________
___________nJasp______________________erTeunK_____elvinO________________________________
__________livier_________________________________Robber_________________________________
_________tKelvi_________________________________nJaspe__________________________________
________rTeunK__________________________________elvinO__________________________________
________livie______________________rRob________bertKe___________________________________
________lvin______________________Jaspe_rTe___unKelv____________________________________
________inOl______________________ivierRobbe__rtKel_________________________vinJasper___
_______TeunK______________________elvinOliv__ierRo________________________bbertKelvinJ__
_______asper_____________________TeunKelvin_Olivi_______________________erRobb____ertK__
_______elvin_____________________JasperTeu__nKelv_____________________inOlivi____erRob__
_______bertK____________________elvinJasp__erTeun___________________KelvinO_____livie___
_______rRobb____________________ertKelvi___nJasperTeunKelvinOli___vierRob_____bertK_____
________elvi___________________nJasperT____eunKelvinOlivierRobbertKelvi______nJasp______
________erTe___________________unKelvi_____nOliv___ierRo___bbertKelvi______nJaspe_______
________rTeu__________________nKelvinO______liv___ierRobbertKelvinJ______asperT_________
________eunKe_______________lvinO_livie_________rRobbertKelvinJasp_____erTeunK__________
_________elvi_____________nOliv__ierRobb_________ertKelvinJasperTeun___KelvinOl_________
_________ivier____________RobbertKelvinJ_____________________asperTeu____nKelvinOl______
__________ivier____________RobbertKelvi______________nJas_______perTeu__nKel_vinOl______
__________ivierR______________obbe___________________rtKe________lvinJa__sperTeun_______
___________Kelvin________________________________Oli______________vierR____obbe_________
____________rtKelvin____________________________Jasp______________erTeu_____nKel________
_______________vinOliv__________________________ierR______________obbertKelvinJa________
_____spe________rTeunKelvi_______________________nOli___________vierRobbertKelv_________
____inJaspe____rTeunKelvinOlivie__________________rRo_________bbertKe____l______________
____vinJasperTeunK_elvinOlivierRobbertKe___________lvin____JasperT______________________
____eunK_elvinOlivierRo____bbertKelvinJasp_erTeunKelvinOlivierRo________________________
_____bber__tKelvinJas_________perTeunKelv_inOlivierRobbertKel___________________________
______vinJ___asperT_________eunKelvinOli_vierR_obbertKelvi______________________________
_______nJasperTeu___________nKelvinOliv__ierR___________________________________________
________obbertK______________elvinJas___perT____________________________________________
__________eun________________Kelvin____Oliv_____________________________________________
______________________________ierRob__bert______________________________________________
_______________________________KelvinJasp_______________________________________________
_________________________________erTeunK________________________________________________
___________________________________elv__________________________________________________
________________________________________________________________________________________";



            await Console.WriteLineAsync(dickbut);
            await Console.WriteLineAsync("Press Piemelkont to restart.");
            await Console.ReadLineAsync();
            await Console.ClearAsync();
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
                if (split.Length < 1)
                {
                    await Console.WriteLineAsync("Die cheat ken ik niet".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    if (target.Equals("GoudenMuntje"))
                    {
                        await State.Inventory.AddAsync(new GoudenMuntje(), Console);
                    }
                    else
                    {
                        await Console.WriteLineAsync($"Item '{target}' ken ik niet.".Pastel(COLOR_ERROR));
                    }
                }
            }
            else if (input!.StartsWith(CHEAT_GO_TO_ROOM))
            {
                string[] split = input.Split(CHEAT_GO_TO_ROOM);
                if (split.Length < 1)
                {
                    await Console.WriteLineAsync("Die cheat ken ik niet".Pastel(COLOR_ERROR));
                }
                else
                {
                    string target = split[1].Trim();
                    IRoom? room = RoomProvider.GetRoom(target);
                    if (room == null)
                    {
                        await Console.WriteLineAsync($"Room '{target}' ken ik niet.".Pastel(COLOR_ERROR));
                    }
                    else
                    {
                        State.CurrentRoom = room;
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
                        //foreach(string line in .Split(Environment.NewLine))
                        //{
                        //    await Console.WriteLineAsync(line);
                        //}
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

        private async Task RenderAsciiArtAsync()
        {
            const string madeByDeksletjes = @"_______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
____________________________________________________________dddddddd___________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
MMMMMMMM_______________MMMMMMMM_____________________________d::::::d_________________________BBBBBBBBBBBBBBBBB_________________________________DDDDDDDDDDDDD___________________________kkkkkkkk__________________________lllllll______________________________tttt___________jjjj______________________________________
M:::::::M_____________M:::::::M_____________________________d::::::d_________________________B::::::::::::::::B________________________________D::::::::::::DDD________________________k::::::k__________________________l:::::l___________________________ttt:::t__________j::::j_____________________________________
M::::::::M___________M::::::::M_____________________________d::::::d_________________________B::::::BBBBBB:::::B_______________________________D:::::::::::::::DD______________________k::::::k__________________________l:::::l___________________________t:::::t___________jjjj______________________________________
M:::::::::M_________M:::::::::M_____________________________d:::::d__________________________BB:::::B_____B:::::B______________________________DDD:::::DDDDD:::::D_____________________k::::::k__________________________l:::::l___________________________t:::::t_____________________________________________________
M::::::::::M_______M::::::::::M__aaaaaaaaaaaaa______ddddddddd:::::d_____eeeeeeeeeeee___________B::::B_____B:::::Byyyyyyy___________yyyyyyy_______D:::::D____D:::::D_____eeeeeeeeeeee____k:::::k____kkkkkkk__ssssssssss____l::::l_____eeeeeeeeeeee____ttttttt:::::ttttttt___jjjjjjj____eeeeeeeeeeee________ssssssssss___
M:::::::::::M_____M:::::::::::M__a::::::::::::a___dd::::::::::::::d___ee::::::::::::ee_________B::::B_____B:::::B_y:::::y_________y:::::y________D:::::D_____D:::::D__ee::::::::::::ee__k:::::k___k:::::k_ss::::::::::s___l::::l___ee::::::::::::ee__t:::::::::::::::::t___j:::::j__ee::::::::::::ee____ss::::::::::s__
M:::::::M::::M___M::::M:::::::M__aaaaaaaaa:::::a_d::::::::::::::::d__e::::::eeeee:::::ee_______B::::BBBBBB:::::B___y:::::y_______y:::::y_________D:::::D_____D:::::D_e::::::eeeee:::::eek:::::k__k:::::kss:::::::::::::s__l::::l__e::::::eeeee:::::eet:::::::::::::::::t____j::::j_e::::::eeeee:::::eess:::::::::::::s_
M::::::M_M::::M_M::::M_M::::::M___________a::::ad:::::::ddddd:::::d_e::::::e_____e:::::e_______B:::::::::::::BB_____y:::::y_____y:::::y__________D:::::D_____D:::::De::::::e_____e:::::ek:::::k_k:::::k_s::::::ssss:::::s_l::::l_e::::::e_____e:::::etttttt:::::::tttttt____j::::je::::::e_____e:::::es::::::ssss:::::s
M::::::M__M::::M::::M__M::::::M____aaaaaaa:::::ad::::::d____d:::::d_e:::::::eeeee::::::e_______B::::BBBBBB:::::B_____y:::::y___y:::::y___________D:::::D_____D:::::De:::::::eeeee::::::ek::::::k:::::k___s:::::s__ssssss__l::::l_e:::::::eeeee::::::e______t:::::t__________j::::je:::::::eeeee::::::e_s:::::s__ssssss_
M::::::M___M:::::::M___M::::::M__aa::::::::::::ad:::::d_____d:::::d_e:::::::::::::::::e________B::::B_____B:::::B_____y:::::y_y:::::y____________D:::::D_____D:::::De:::::::::::::::::e_k:::::::::::k______s::::::s_______l::::l_e:::::::::::::::::e_______t:::::t__________j::::je:::::::::::::::::e____s::::::s______
M::::::M____M:::::M____M::::::M_a::::aaaa::::::ad:::::d_____d:::::d_e::::::eeeeeeeeeee_________B::::B_____B:::::B______y:::::y:::::y_____________D:::::D_____D:::::De::::::eeeeeeeeeee__k:::::::::::k_________s::::::s____l::::l_e::::::eeeeeeeeeee________t:::::t__________j::::je::::::eeeeeeeeeee________s::::::s___
M::::::M_____MMMMM_____M::::::Ma::::a____a:::::ad:::::d_____d:::::d_e:::::::e__________________B::::B_____B:::::B_______y:::::::::y______________D:::::D____D:::::D_e:::::::e___________k::::::k:::::k__ssssss___s:::::s__l::::l_e:::::::e_________________t:::::t____ttttttj::::je:::::::e___________ssssss___s:::::s_
M::::::M_______________M::::::Ma::::a____a:::::ad::::::ddddd::::::dde::::::::e_______________BB:::::BBBBBB::::::B________y:::::::y_____________DDD:::::DDDDD:::::D__e::::::::e_________k::::::k_k:::::k_s:::::ssss::::::sl::::::le::::::::e________________t::::::tttt:::::tj::::je::::::::e__________s:::::ssss::::::s
M::::::M_______________M::::::Ma:::::aaaa::::::a_d:::::::::::::::::d_e::::::::eeeeeeee_______B:::::::::::::::::B__________y:::::y______________D:::::::::::::::DD____e::::::::eeeeeeee_k::::::k__k:::::ks::::::::::::::s_l::::::l_e::::::::eeeeeeee________tt::::::::::::::tj::::j_e::::::::eeeeeeee__s::::::::::::::s_
M::::::M_______________M::::::M_a::::::::::aa:::a_d:::::::::ddd::::d__ee:::::::::::::e_______B::::::::::::::::B__________y:::::y_______________D::::::::::::DDD_______ee:::::::::::::e_k::::::k___k:::::ks:::::::::::ss__l::::::l__ee:::::::::::::e__________tt:::::::::::ttj::::j__ee:::::::::::::e___s:::::::::::ss__
MMMMMMMM_______________MMMMMMMM__aaaaaaaaaa__aaaa__ddddddddd___ddddd____eeeeeeeeeeeeee_______BBBBBBBBBBBBBBBBB__________y:::::y________________DDDDDDDDDDDDD____________eeeeeeeeeeeeee_kkkkkkkk____kkkkkkksssssssssss____llllllll____eeeeeeeeeeeeee____________ttttttttttt__j::::j____eeeeeeeeeeeeee____sssssssssss____
_______________________________________________________________________________________________________________________y:::::y______________________________________________________________________________________________________________________________________________j::::j_____________________________________
______________________________________________________________________________________________________________________y:::::y_____________________________________________________________________________________________________________________________________jjjj______j::::j_____________________________________
_____________________________________________________________________________________________________________________y:::::y_____________________________________________________________________________________________________________________________________j::::jj___j:::::j_____________________________________
____________________________________________________________________________________________________________________y:::::y______________________________________________________________________________________________________________________________________j::::::jjj::::::j_____________________________________
___________________________________________________________________________________________________________________yyyyyyy________________________________________________________________________________________________________________________________________jj::::::::::::j______________________________________
____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________jjj::::::jjj_______________________________________
_______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________jjjjjj__________________________________________

";



            const string amazingGame3 = @"_▄▄▄▄▄▄▄▄▄▄▄__▄▄_______▄▄__▄▄▄▄▄▄▄▄▄▄▄__▄▄▄▄▄▄▄▄▄▄▄__▄▄▄▄▄▄▄▄▄▄▄__▄▄________▄__▄▄▄▄▄▄▄▄▄▄▄_______▄▄▄▄▄▄▄▄▄▄▄__▄▄▄▄▄▄▄▄▄▄▄__▄▄_______▄▄__▄▄▄▄▄▄▄▄▄▄▄_______▄▄▄▄▄▄▄▄▄▄▄_
▐░░░░░░░░░░░▌▐░░▌_____▐░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌______▐░▌▐░░░░░░░░░░░▌_____▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌_____▐░░▌▐░░░░░░░░░░░▌_____▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌___▐░▐░▌▐░█▀▀▀▀▀▀▀█░▌_▀▀▀▀▀▀▀▀▀█░▌_▀▀▀▀█░█▀▀▀▀_▐░▌░▌_____▐░▌▐░█▀▀▀▀▀▀▀▀▀______▐░█▀▀▀▀▀▀▀▀▀_▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌___▐░▐░▌▐░█▀▀▀▀▀▀▀▀▀_______▀▀▀▀▀▀▀▀▀█░▌
▐░▌_______▐░▌▐░▌▐░▌_▐░▌▐░▌▐░▌_______▐░▌__________▐░▌_____▐░▌_____▐░▌▐░▌____▐░▌▐░▌_______________▐░▌__________▐░▌_______▐░▌▐░▌▐░▌_▐░▌▐░▌▐░▌_________________________▐░▌
▐░█▄▄▄▄▄▄▄█░▌▐░▌_▐░▐░▌_▐░▌▐░█▄▄▄▄▄▄▄█░▌_▄▄▄▄▄▄▄▄▄█░▌_____▐░▌_____▐░▌_▐░▌___▐░▌▐░▌_▄▄▄▄▄▄▄▄______▐░▌_▄▄▄▄▄▄▄▄_▐░█▄▄▄▄▄▄▄█░▌▐░▌_▐░▐░▌_▐░▌▐░█▄▄▄▄▄▄▄▄▄_______▄▄▄▄▄▄▄▄▄█░▌
▐░░░░░░░░░░░▌▐░▌__▐░▌__▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌_____▐░▌_____▐░▌__▐░▌__▐░▌▐░▌▐░░░░░░░░▌_____▐░▌▐░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌__▐░▌__▐░▌▐░░░░░░░░░░░▌_____▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀█░▌▐░▌___▀___▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀______▐░▌_____▐░▌___▐░▌_▐░▌▐░▌_▀▀▀▀▀▀█░▌_____▐░▌_▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌___▀___▐░▌▐░█▀▀▀▀▀▀▀▀▀_______▀▀▀▀▀▀▀▀▀█░▌
▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_______________▐░▌_____▐░▌____▐░▌▐░▌▐░▌_______▐░▌_____▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_________________________▐░▌
▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░█▄▄▄▄▄▄▄▄▄__▄▄▄▄█░█▄▄▄▄_▐░▌_____▐░▐░▌▐░█▄▄▄▄▄▄▄█░▌_____▐░█▄▄▄▄▄▄▄█░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░█▄▄▄▄▄▄▄▄▄_______▄▄▄▄▄▄▄▄▄█░▌
▐░▌_______▐░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌______▐░░▌▐░░░░░░░░░░░▌_____▐░░░░░░░░░░░▌▐░▌_______▐░▌▐░▌_______▐░▌▐░░░░░░░░░░░▌_____▐░░░░░░░░░░░▌
_▀_________▀__▀_________▀__▀_________▀__▀▀▀▀▀▀▀▀▀▀▀__▀▀▀▀▀▀▀▀▀▀▀__▀________▀▀__▀▀▀▀▀▀▀▀▀▀▀_______▀▀▀▀▀▀▀▀▀▀▀__▀_________▀__▀_________▀__▀▀▀▀▀▀▀▀▀▀▀_______▀▀▀▀▀▀▀▀▀▀▀_
______________________________________________________________________________________________________________________________________________________________________

";
            await Console.WriteLineAsync(amazingGame3);
            await Console.WriteLineAsync("Press enter to continue.");
            await Console.ReadLineAsync();
            await Console.ClearAsync();

            await Console.WriteLineAsync(madeByDeksletjes);
            await Console.WriteLineAsync("Press enter to continue.");
            await Console.ReadLineAsync();
            await Console.ClearAsync();
        }
    }
}