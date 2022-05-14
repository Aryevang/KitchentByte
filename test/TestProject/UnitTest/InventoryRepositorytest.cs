using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Repositories;
using InventoryProject.UnitTest.Fixtures;
using Xunit;

namespace InventoryProject.UnitTest;

public class InventoryRepositoryInventory
{
    private readonly InventoryRepository _sut;

    public InventoryRepositoryInventory()
    {
        _sut = new InventoryRepository();
    }

    [Fact]
    public void ShouldAddOneInventory()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();

        //When
        _sut.Add(inventory);

        //Then
        int totalInventoryCount = _sut.GetAll().Count;
        Assert.Equal(1, totalInventoryCount);
    }

    [Fact]
    public void ShouldAddOneInventoryItem()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();
        InventoryItem newItem = new InventoryItem { ID = 0, product = new Product { ID = 1, Name = "test", Status = 'A' }, ItemCount = 200, Price = 0, Status = 'A' };

        //When
        _sut.Add(inventory);
        _sut.AddItem(1, newItem);
        var (_, item) = _sut.GetItem(1, 1);

        //Then
        Assert.Equal(1, item.ID);
    }

    [Fact]
    public void ShouldAddTwoInventoryItem()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();
        InventoryItem firstItem = new InventoryItem { ID = 0, product = new Product { ID = 1, Name = "test", Status = 'A' }, ItemCount = 100, Price = 0, Status = 'A' };
        InventoryItem secondItem = new InventoryItem { ID = 0, product = new Product { ID = 2, Name = "test2", Status = 'A' }, ItemCount = 200, Price = 0, Status = 'A' };

        //When
        _sut.Add(inventory);
        _sut.AddItem(1, firstItem);
        _sut.AddItem(1, secondItem);
        var inv = _sut.GetByID(1);

        //Then
        Assert.Equal(3, inv?.items?.Count());
    }

    [Fact]
    public void ShouldDeleteOneInventoryItem()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();
        InventoryItem firstItem = new InventoryItem { ID = 0, product = new Product { ID = 1, Name = "test", Status = 'A' }, ItemCount = 100, Price = 0, Status = 'A' };
        InventoryItem secondItem = new InventoryItem { ID = 0, product = new Product { ID = 2, Name = "test2", Status = 'A' }, ItemCount = 200, Price = 0, Status = 'A' };

        //When
        _sut.Add(inventory);
        _sut.AddItem(1, firstItem);
        _sut.AddItem(1, secondItem);
        var inv = _sut.GetByID(1);
        Assert.Equal(3, inv?.items?.Count());

        _sut.DeleteItem(1, 3);
        var (invet, item) = _sut.GetItem(1, 2);
        //Then
        Assert.Equal(2, _sut.GetByID(1)?.items?.Count());
        Assert.Equal("test", item?.product?.Name);
        Assert.Equal(0, invet.items?.Where(i => i.product?.Name == "DeleteMe").Count());
    }

    [Fact]
    public void ShouldDeleteOneInventory()
    {
        //Given
        List<Inventory> inventories = InventoryFixture.BuildInventory(3);

        inventories.ForEach(inv =>
        {
            _sut.Add(inv);
        });

        //When
        _sut.Delete(1);
        var remainingInventory = _sut.GetByID(2);
        var inventoryNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count);
        Assert.Equal(2, remainingInventory?.ID);
        Assert.Null(inventoryNotFound);
    }

    [Fact]
    public void ShouldUpdateTheInventory()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();
        Assert.NotNull(inventory);
        Assert.Equal(1, inventory.ID);

        _sut.Add(inventory);

        Inventory newInventory = inventory with { ToTalUnits = 200 };
        Assert.Equal(200, newInventory.ToTalUnits);

        //When
        _sut.Update(newInventory);

        //Then
        Inventory? updatedInventory = _sut.GetByID(1);
        Assert.Equal(200, updatedInventory?.ToTalUnits);
    }

    [Fact]
    public void ShouldUpdateOneInventoryItem()
    {
        //Given
        Inventory? inventory = InventoryFixture.BuildInventory();

        //When
        _sut.Add(inventory);

        var (_, item) = _sut.GetItem(1, 1);
        InventoryItem newItem = item with
        {
            product = new Product { ID = 1, Name = "Updated", Status = 'A' },
            ItemCount = 10,
            Price = 1,
            Status = 'A'
        };

        _sut.UpdateItem(1, newItem);

        var (_, updatedItem) = _sut.GetItem(1, 1);

        //Then
        Assert.Equal(10, updatedItem.ItemCount);
    }
}
