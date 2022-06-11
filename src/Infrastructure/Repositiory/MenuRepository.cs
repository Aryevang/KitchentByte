using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly List<Menu> _menuCollection;

    public MenuRepository()
    {
        _menuCollection = new();
    }

    public void Add(Menu model)
    {
        long currentID = _menuCollection.Count();
        currentID++;
        Menu newMenu = model with { ID = currentID };
        _menuCollection.Add(newMenu);
    }

    public void Delete(long id)
    {
        Menu? menuToDelete = GetByID(id);
        if (menuToDelete is not null)
            Update(menuToDelete with { Status = 'D' });
    }

    public List<Menu> GetAll()
    {
        return _menuCollection.Where(m => m.Status == 'A').ToList();
    }

    public Menu? GetByID(long id)
    {
        return _menuCollection.SingleOrDefault(m => m.ID == id && m.Status == 'A');
    }

    public void Update(Menu model)
    {
        Menu? menuToUpdate = GetByID(model.ID);
        if (menuToUpdate is not null)
        {
            menuToUpdate.Name = model.Name;
            menuToUpdate.Dishes = model.Dishes;
            menuToUpdate.Status = model.Status;
        }
    }
}

