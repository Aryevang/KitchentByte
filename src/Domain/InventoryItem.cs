namespace Domain;

//This model handle the detail of an Inventory. Additonally, will be the join between the Products and the Inventory.
public record InventoryItem
{
    public long ID { get; set; }
    public Product? product { get; set; }
    public int ItemCount { get; set; }
    public double Price { get; set; }
    public char Status { get; set; }
}
