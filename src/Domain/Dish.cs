namespace Domain;

//This record represent a Dish: Lasagna, Seafood Paella, etc, while provide an average completion for the dish and a Difficulty.
public record Dish
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public List<Product>? Ingredients { get; set; }
    public double Price { get; set; }
    public TimeSpan AverageCompletionTime { get; set; }
    public int Difficulty { get; set; }
    public char Status { get; set; }
}
