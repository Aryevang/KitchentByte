using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orderCollection;
    public OrderRepository()
    {
        _orderCollection = new();
    }

    public void Add(Order model)
    {
        long currentID = _orderCollection.Count();
        currentID++;
        Order newOrder = model with { ID = currentID };
        _orderCollection.Add(newOrder);
    }

    public void Delete(long id)
    {
        var orderToDelete = new Order {ID = id, Status= 'D'};
        Update(orderToDelete);
    }

    public List<Order> GetAll()
    {
        return _orderCollection.Where(i => i.Status == 'A').ToList();
    }

    public Order? GetByID(long id)
    {
        return _orderCollection?.SingleOrDefault(o => o.ID == id && o.Status == 'A');
    }

    public void Update(Order model)
    {
        Order? orderToUpdate = GetByID(model.ID);

        if (orderToUpdate is not null)
        {
            orderToUpdate.Dishes = model.Dishes;
            orderToUpdate.SubTotal = model.SubTotal;
            orderToUpdate.Tax = model.Tax;
            orderToUpdate.Status = model.Status;
        }
    }
}

