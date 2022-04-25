using Domain;

namespace Application.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    void AddMany(IEnumerable<Product> products);
}
