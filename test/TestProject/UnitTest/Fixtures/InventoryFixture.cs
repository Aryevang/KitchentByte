using Domain;
using System;
using System.Collections.Generic;

namespace InventoryProject.UnitTest.Fixtures;

public static class InventoryFixture
{
    public static List<Inventory> BuildInventory(int times)
    {
        var inventories = new List<Inventory>();

        for (int i = 0; i < times; i++)
        {

            var invItem = new InventoryItem { ID = 1, product = new Product { ID = 1, Name = "Product", Status = 'A' }, ItemCount = 0, Price = 0, Status = 'A' };
            inventories.Add(new Inventory {ID= i, items= new List<InventoryItem>{ invItem }, CompletionDate = new DateOnly(2022, 5, 1), ToTalUnits = 1, TotalInventoryPrice = 500.00, Status = 'A'});
        }

        return inventories;
    }

    public static Inventory BuildInventory()
    {
        var invItem = new InventoryItem { ID = 1, product = new Product { ID = 1, Name = "Product", Status = 'A' }, ItemCount = 0, Price = 0, Status = 'A' };
        return new Inventory {ID= 1, items= new List<InventoryItem>{ invItem }, CompletionDate = new DateOnly(2022, 5, 1), ToTalUnits = 1, TotalInventoryPrice = 500.00, Status = 'A'};
    }
}
