namespace Domain;

//This model handle the detail of an Inventory. Additonally, will be the join between the Products and the Inventory.
public record InventoryItem(long ID, long InventoryID, long ProductID, int ItemCount, double SpecialPrice);
