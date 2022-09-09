using Domain;
using System;
using System.Collections.Generic;

namespace TestProject.UnitTest.Fixtures;

public static class InventoryFixture
{
    public static List<Inventory> Build(int times)
    {
        List<Inventory> _inventoryCollection = new();
        for (int i = 1; i <= times; i++)
            _inventoryCollection.Add(Build(new Inventory { ID = i, items = new List<InventoryItem>(), CompletionDate = new DateOnly(2022, 5, 1), ToTalUnits = 1, TotalInventoryPrice = 500.00, Status = 'A' }));
        return _inventoryCollection;
    }

    public static Inventory Build()
    {
        return Build(null);
    }

    public static Inventory Build(Inventory? inv)
    {
        long id = inv?.ID ?? 1;
        var invItem = new InventoryItem { ID = id, product = new Product { ID = id, Name = $"Product{id}", Status = 'A' }, ItemCount = 0, Price = 0, Status = 'A' };
        return new Inventory
        {
            ID = inv?.ID ?? 1,
            items = inv?.items ?? new List<InventoryItem>() { invItem },
            CompletionDate = inv?.CompletionDate ?? new DateOnly(2022, 8, 1),
            ToTalUnits = inv?.ToTalUnits ?? 1,
            TotalInventoryPrice = inv?.TotalInventoryPrice ?? 500.00,
            Status = inv?.Status ?? 'A'
        };
    }
}
