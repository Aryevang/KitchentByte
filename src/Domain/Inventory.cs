namespace Domain;

//This model will handle the information about prodcut stock.
public record Inventory
{
    public long ID { get; set; }
    public List<InventoryItem>? items { get; set; }
    public DateOnly CompletionDate { get; set; }
    public int ToTalUnits { get; set; }
    public double TotalInventoryPrice { get; set; }
    public char Status { get; set; }
}
