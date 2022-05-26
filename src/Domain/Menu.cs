namespace Domain;

//This record will hold the details about the Menu.
//The main use is to create menu categories like: Vegetarian, Mediterranean, etc.
public record Menu
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public IEnumerable<Dish>? Dishes { get; set; }
    public char Status { get; set; }
}
