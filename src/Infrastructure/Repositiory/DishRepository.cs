using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class DishRepository : IDishRepository
{
    private readonly List<Dish> _dishCollection;
    public DishRepository()
    {
        _dishCollection = new();
    }

    public void Add(Dish model)
    {
        long currentID = _dishCollection.Count;
        currentID++;
        Dish newDish = model with { ID = currentID };
        _dishCollection.Add(newDish);
    }

    public void Delete(long id)
    {
        Dish? dishToDelete = new Dish { ID = id, Status = 'D' };
        if (dishToDelete is not null)
            Update(dishToDelete);
    }

    public List<Dish> GetAll()
    {
        return _dishCollection.Where(d => d.Status == 'A').ToList();
    }

    public Dish? GetByID(long id)
    {
        return _dishCollection?.SingleOrDefault(d => d.Status == 'A' && d.ID == id);
    }

    public void Update(Dish model)
    {
        Dish? dishToUpdate = GetByID(model.ID);
        if (dishToUpdate is not null)
        {
            dishToUpdate.Name = model.Name;
            dishToUpdate.Price = model.Price;
            dishToUpdate.Ingredients = model.Ingredients;
            dishToUpdate.AverageCompletionTime = model.AverageCompletionTime;
            dishToUpdate.Difficulty = model.Difficulty;
            dishToUpdate.Status = model.Status;
        }
    }
}

