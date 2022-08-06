using AmazingGame3.Persons;
using AmazingGame3.Rooms.Instances;
using AmazingGame3.Rooms.Instances.Bar;
using AmazingGame3.Rooms.Instances.Boulderhal;
using AmazingGame3.Rooms.Instances.Boulderhal.Move1;
using AmazingGame3.Rooms.Instances.Boulderhal.Move2;
using AmazingGame3.Rooms.Instances.Huis;
using AmazingGame3.Rooms.Instances.Stater;

namespace AmazingGame3.Rooms
{
    public interface IRoomProvider
    {
        public IRoom GetRoom(int id);
        public IRoom? GetRoom(string name);
    }

    public class RoomProvider : IRoomProvider
    {
        private List<IRoom> Rooms { get; }

        public RoomProvider()
        {
            Rooms = new List<IRoom>
            {
                new AmazingHuis3(),
                new BoulderhalStronk(),
                new StaterLobby(),
                new VoorToeganspoortje(),
                new AchterHetToegangspoortje(),
                new Trap(),
                new Lift(),
                new Werkplek(),
                new BeeldschermRoom(),
                new KlimGedeelte(),
                new Easy7A(),
                new FlinkeJug1(),
                new ForseHold1(),
                new KleinCrimpi1(),
                new FlinkeJug2(),
                new ForseHold2(),
                new MegaSloper2(),
                new Boven(),
                new Jansbar()
            };
        }

        public IRoom GetRoom(int id)
        {
            return Rooms.First(e => e.GetId() == id);
        }

        public IRoom? GetRoom(string name)
        {
            return Rooms.FirstOrDefault(e => e.GetName().Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}