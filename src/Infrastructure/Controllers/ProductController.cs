using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Controllers;
public class ProductController
{
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo)
    {
        _repo = repo;
    }

    public void Create(Product prod)
    {
        _repo.Add(prod);
    }

    public void CreateMany(List<Product> prods)
    {
        _repo.AddMany(prods);
    }

    public void Delete(long id)
    {
        _repo.Delete(id);
    }

    public Product Get(long id)
    {
        return _repo.GetByID(id);
    }

    public List<Product> GetAll()
    {
        return _repo.GetAll();
    }

    public void Update(Product prod)
    {
        _repo.Update(prod);
    }
}
