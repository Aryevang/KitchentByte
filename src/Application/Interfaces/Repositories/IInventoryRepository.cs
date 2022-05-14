using Domain;

namespace Application.Interfaces.Repositories;

public interface IInventoryRepository : IRepository<Inventory>
{
    void AddItem(long InventoryId, InventoryItem item);
    void UpdateItem(long InventoryId, InventoryItem item);
    void DeleteItem(long invId, long itemId);
    (Inventory, InventoryItem) GetItem(long invId, long InvItemId);
}
