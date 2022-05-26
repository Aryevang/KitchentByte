namespace Domain;

//This model provides the more atomic unit of the inventory.
public record Product
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public char Status { get; set; }
}
