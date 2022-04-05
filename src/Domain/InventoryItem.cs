namespace Domain;

//This model handle the detail of an Inventory. Additonally, will be the join between the Products and the Inventory.
public record InventoryItem(long ID, Product Product, int ItemCount, double Price);
