using Domain;
using System.Collections.Generic;

namespace InventoryProject.UnitTest.Fixtures;

public static class MenuFixture
{
    public static List<Menu> BuildMenu(int times)
    {
        List<Menu> _menuColletion = new();
        for (int i = 0; i < times; i++)
        {
            _menuColletion.Add( new Menu {ID = i, Name = $"menu{i}", Dishes = new List<Dish>(), Status = 'A'}) ;
        }

        return _menuColletion;
    }

    public static Menu BuildMenu()
    {
        return new Menu
        {
            ID = 0, //The Add method contains the logic to add a new ID to any new menu item.
            Name = "menu",
            Dishes = new List<Dish>(),
            Status = 'A'
        };
    }
}

