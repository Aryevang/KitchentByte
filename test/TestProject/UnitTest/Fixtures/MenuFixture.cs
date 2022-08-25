using Domain;
using System.Collections.Generic;

namespace TestProject.UnitTest.Fixtures;

public static class MenuFixture
{
    public static List<Menu> Build(int times)
    {
        List<Menu> _menuColletion = new();
        for (int i = 1; i <= times; i++)
            _menuColletion.Add(Build(new Menu { ID = i, Name = $"menu{i}", Dishes = new List<Dish>(), Status = 'A' }));

        return _menuColletion;
    }

    public static Menu Build()
    {
        return Build(null);
    }

    public static Menu Build(Menu? menu)
    {
        return new Menu
        {
            ID = menu?.ID ?? 1,
            Name = menu?.Name ?? "menu",
            Dishes = new List<Dish>(),
            Status = menu?.Status ?? 'A'
        };
    }
}

