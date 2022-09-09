using Domain;
using System;
using System.Collections.Generic;

namespace TestProject.UnitTest.Fixtures;

public static class DishFixture
{

    public static List<Dish> Build(int times)
    {
        List<Dish> _dishCollection = new();
        for (int i = 1; i <= times; i++)
            _dishCollection.Add(Build(new Dish { ID = i, Name = $"dish{i}", Ingredients = new List<Product>(), Price = 100 * i, AverageCompletionTime = TimeSpan.FromMinutes(i), Difficulty = i, Status = 'A' }));

        return _dishCollection;
    }

    public static Dish Build()
    {
        return Build(null);
    }

    public static Dish Build(Dish? dish)
    {
        return new Dish
        {
            ID = dish?.ID ?? 1,
            Name = dish?.Name ?? "menu",
            Ingredients = dish?.Ingredients ?? new List<Product>(),
            Price = dish?.Price ?? 100,
            AverageCompletionTime = dish?.AverageCompletionTime ?? TimeSpan.FromMinutes(1),
            Difficulty = dish?.Difficulty ?? 1,
            Status = dish?.Status ?? 'A'
        };
    }
}

