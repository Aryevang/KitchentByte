namespace Domain;

//This model will handle the information about prodcut stock.
public record Inventory(long ID, DateOnly CompletionDate, int ToTalUnits, double TotalInventoryPrice);
