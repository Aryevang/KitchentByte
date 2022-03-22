namespace Domain;

//This record represent a Dish: Lasagna, Seafood Paella, etc, while provide an average completion for the dish.
public record Dish(long ID, string Name, long MenuID, IEnumerable<Product> Ingredients, double Price, TimeSpan AverageCompletionTime);
