namespace Domain;

//This model will handle the information about prodcut stock.
public record Inventory(long ID, IEnumerable<InventoryItem> items, DateOnly CompletionDate, int ToTalUnits, double TotalInventoryPrice, char Status);
