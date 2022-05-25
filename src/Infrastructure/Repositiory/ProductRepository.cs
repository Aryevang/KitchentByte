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
        Product? productToDelete = GetByID(id);
        if (productToDelete is not null)
            Update(productToDelete with {Status = 'D'});
    }

    public List<Product> GetAll()
    {
        return _productCollection.Where(p => p.Status =='A').ToList();

    }

    public Product? GetByID(long id)
    {
        return _productCollection?.Where(p => p.ID == id && p.Status == 'A').SingleOrDefault();
    }

    public void Update(Product model)
    {
        Product? productToUpdate = GetByID(model.ID);

        if (productToUpdate is not null)
        {
            productToUpdate.Name = model.Name;
            productToUpdate.Status = model.Status;
        }
    }

    public int Count()
    {
        return GetAll().Count();
    } 

}
