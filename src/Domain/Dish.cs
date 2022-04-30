namespace Domain;

//This record represent a Dish: Lasagna, Seafood Paella, etc, while provide an average completion for the dish and a Difficulty.
public record Dish(long ID, string Name, IEnumerable<Product> Ingredients, double Price, TimeSpan AverageCompletionTime, int Difficulty, char Status);
