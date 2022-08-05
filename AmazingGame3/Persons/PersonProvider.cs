using AmazingGame3.Persons.Instances;
using AmazingGame3.Rooms.Instances;

namespace AmazingGame3.Persons
{
    public static class PersonProvider
    {
        private static List<IPerson> Persons { get; }

        static PersonProvider()
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

        public static IPerson GetPerson(int id)
        {
            return Persons.First(e => e.GetId() == id);
        }

        public static IPerson? GetPerson(string name)
        {
            return Persons.FirstOrDefault(e => e.GetName().Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}