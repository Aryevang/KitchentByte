using Domain;
using System.Collections.Generic;

namespace InventoryProject.UnitTest.Fixtures;

public static class OrderFixture
{
    public static List<Order> BuildOrder(int times)
    {
        List<Order> orders = new();
        for (int i = 1; i <= times; i++)
        {
            orders.Add(new Order { ID = 0, Dishes = new List<Dish>(), SubTotal = i, Tax = 1, Status = 'A' });
        }

        return orders;
    }

    public static Order BuildOrder()
    {
        return new Order { ID = 0, Dishes = new List<Dish>(), SubTotal = 100, Tax = 5, Status = 'A' };
    }
}

