using Domain;
using System;
using System.Collections.Generic;

namespace TestProject.UnitTest.Fixtures;

public static class DishFixture
{
    public static List<Dish> BuildDish(int times)
    {
        List<Dish> _dishCollection = new();
        for (int i = 1; i <= times; i++)
        {
            _dishCollection.Add(new Dish { ID = 0, Name = $"dish{i}", Ingredients = new List<Product>(), Price = 100 * i, AverageCompletionTime = TimeSpan.FromMinutes(i), Difficulty = i, Status = 'A' });
        }

        return _dishCollection;
    }

    public static Dish BuildDish()
    {
        return new Dish { ID = 0, Name = "dish", Ingredients = new List<Product>(), Price = 50, AverageCompletionTime = TimeSpan.FromMinutes(1), Difficulty = 2, Status = 'A' };
    }
}

