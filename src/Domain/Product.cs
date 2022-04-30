namespace Domain;

//This model provides the more atomic unit of the inventory.
public record Product(long ID, string Name, char Status);
