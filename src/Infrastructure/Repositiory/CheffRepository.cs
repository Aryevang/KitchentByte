using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class CheffRepository : ICheffRepository
{
    private readonly List<Cheff> _cheffCollection;
    public CheffRepository()
    {
        _cheffCollection = new();
    }

    public void Add(Cheff model)
    {
        long currentID = _cheffCollection.Count;
        currentID++;
        Cheff newCheff = model with {ID = currentID};
        _cheffCollection.Add(newCheff);
    }

    public void Delete(long id)
    {
        Cheff? cheffToDelete = new Cheff { ID = id, Status ='D'};
        if (cheffToDelete is not null)
            Update(cheffToDelete with { Status = 'D' });
    }

    public List<Cheff> GetAll()
    {
        return _cheffCollection.Where(s => s.Status == 'A').ToList();
    }

    public Cheff? GetByID(long id)
    {
        return _cheffCollection.SingleOrDefault(c => c.ID == id && c.Status == 'A');
    }

    public void Update(Cheff model)
    {
        Cheff? cheffToUpdate = GetByID(model.ID);
        if(cheffToUpdate is not null)
        {
            cheffToUpdate.Level = model.Level;
            cheffToUpdate.OrderCapacity = model.OrderCapacity;
            cheffToUpdate.Status = model.Status;
        }
    }
}

