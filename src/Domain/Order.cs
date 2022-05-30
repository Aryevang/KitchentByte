namespace Domain;

//The `Order` record holds the information of the Dishes required by the client.
public record Order
{
    public long ID { get; set; }
    public List<Dish>? Dishes { get; set; }
    public double SubTotal { get; set; }
    public double Tax { get; set; }
    public char Status { get; set; }
}
