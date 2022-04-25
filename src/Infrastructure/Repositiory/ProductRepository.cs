using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _productCollection;
    public ProductRepository()
    {
        _productCollection = new();
    }

    public void Add(Product model)
    {
        _productCollection.Add(model);
    }

    public void AddMany(IEnumerable<Product> products)
    {
        _productCollection.AddRange(products);
    }

    public void Delete(long id)
    {
        Product? productToDelete = _productCollection.Where(p => p.ID == id).SingleOrDefault();
        if (productToDelete is not null)
            _productCollection.Remove(productToDelete);
    }

    public List<Product> GetAll()
    {
        return _productCollection;

    }

    public Product? GetByID(long id)
    {
        return _productCollection?.Where(p => p.ID == id).SingleOrDefault();
    }

    public void Update(Product model)
    {

        Product? productToUpdate = _productCollection.Where(p => p.ID == model.ID).SingleOrDefault();

        if (productToUpdate is not null)
        {
            _productCollection.Remove(productToUpdate);
            _productCollection.Add(productToUpdate with
            {
                Name = model.Name
            });
        }
    }

    public int Count()
    {
        return _productCollection.Count();
    } 

}
