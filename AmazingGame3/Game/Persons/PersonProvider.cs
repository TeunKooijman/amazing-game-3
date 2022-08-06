using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances;

namespace AmazingGame3.Persons
{
    public interface IPersonProvider
    {
        public IPerson GetPerson(int id);
        public IPerson? GetPerson(string name);
    }

    public class PersonProvider : IPersonProvider
    {
        private List<IPerson> Persons { get; }

        public PersonProvider()
        {
            Persons = new List<IPerson>
            {
                new LunaHuis(),
                new SterkeVerkoopster(),
                new Tjeerdje(),
                new Emile(),
                new WindowsVista(),
                new LunaBoulder(),
                new Deksletten()
            };
        }

        public IPerson GetPerson(int id)
        {
            return Persons.First(e => e.GetId() == id);
        }

        public IPerson? GetPerson(string name)
        {
            return Persons.FirstOrDefault(e => e.GetName().Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}