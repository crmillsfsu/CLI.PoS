using API.CLI.Database;
using CLI.PoS.Model;

namespace API.CLI.Enterprise
{
    public class MenuItemEC
    {
        public MenuItemEC() { }

        public IEnumerable<Item> Items => FakeDatabase.MenuItems;
    }
}
