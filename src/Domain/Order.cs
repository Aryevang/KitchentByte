namespace Domain;

//The `Order` record holds the information of the Dishes required by the client.
public record Order(long ID, IEnumerable<Dish> Dishes, double SubTotal, double Tax);
