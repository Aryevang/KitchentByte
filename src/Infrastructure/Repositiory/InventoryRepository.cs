using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly List<Inventory> _inventoryCollection;
    public InventoryRepository()
    {
        _inventoryCollection = new();
    }

    public void Add(Inventory model)
    {
        long currentID = _inventoryCollection.Count();
        currentID++;
        Inventory newInventory = model with { ID = currentID };
        _inventoryCollection.Add(model);
    }

    public void AddItem(long InventoryId, InventoryItem item)
    {
        Inventory? inventory = GetByID(InventoryId);
        if (inventory is not null)
        {
            int newItemId = inventory.items.Count();
            newItemId++;
            InventoryItem itemToAdd = item with { ID = newItemId };

            inventory.items.Add(itemToAdd);
        }
    }

    public void Delete(long id)
    {
        var inventoryToDelete = new Inventory { ID = id, items = new List<InventoryItem>(), CompletionDate = new DateOnly(2022, 5, 1), ToTalUnits = 0, TotalInventoryPrice = 0, Status = 'D' };
        Update(inventoryToDelete);
    }

    public void DeleteItem(long invId, long itemId)
    {
        var (inventory, itemToDelete) = GetItem(invId, itemId);
        if (inventory is not null || itemToDelete is not null)
            inventory.items?.Remove(itemToDelete);
    }

    public List<Inventory> GetAll()
    {
        return _inventoryCollection.Where(i => i.Status == 'A').ToList();
    }

    public Inventory? GetByID(long id)
    {
        return _inventoryCollection?.Where(i => i.ID == id && i.Status == 'A').SingleOrDefault();
    }

    public (Inventory, InventoryItem) GetItem(long invId, long InvItemId)
    {
        Inventory? inv = GetByID(invId);
        InventoryItem? item = inv?.items.SingleOrDefault(i => i.ID == InvItemId && i.Status == 'A');

        if (inv is not null && item is not null)
            return (inv, item);

        return default;
    }

    public void Update(Inventory model)
    {
        Inventory? inventoryToUpdate = GetByID(model.ID);

        if (inventoryToUpdate is not null)
        {
            inventoryToUpdate.items = model.items;
            inventoryToUpdate.CompletionDate = model.CompletionDate;
            inventoryToUpdate.ToTalUnits = model.ToTalUnits;
            inventoryToUpdate.TotalInventoryPrice = model.TotalInventoryPrice;
            inventoryToUpdate.Status = model.Status;
        }
    }

    public void UpdateItem(long InventoryId, InventoryItem item)
    {
        var (inventory, invItem) = GetItem(InventoryId, item.ID);

        if (inventory is not null && invItem is not null)
        {
            invItem.product = item.product;
            invItem.ItemCount = item.ItemCount;
            invItem.Price = item.Price;
            invItem.Status = item.Status;
        }
    }
}
