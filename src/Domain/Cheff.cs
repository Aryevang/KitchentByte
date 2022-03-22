namespace Domain;

//This class represents a Cheff model.
//The `orderCapacity` determine how many orders a Cheff can handle at the same time.
//The `level` will filter witch cheff is able to prepare a Dish based on the difficulty of it.
public record Cheff
{
    public long ID { get; init; }
    public Experience Level { get; init; }
    private int _orderCapacity;
    public int OrderCapacity
    {
        get => _orderCapacity;
        set => _orderCapacity = (value > 5 ? 5 : value); //The Max capacity for Cheff are 5 orders.
                                                         //`NOTE`: This validation could be removed or changed in the near future.
    }
}

//Provides a clear limit of difficulty a Cheff for a Dish.
public enum Experience
{
    Senior = 10,
    MidSenior = 8,
    Junior = 5
}
