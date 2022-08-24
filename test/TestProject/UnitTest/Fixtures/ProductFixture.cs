using Domain;
using System.Collections.Generic;

namespace TestProject.UnitTest.Fixtures;

public static class ProductFixture
{
    public static List<Product> Build(int times)
    {
        List<Product> _productCollection = new();
        for (int i = 1; i <= times; i++)
            _productCollection.Add(Build(new Product { ID = i, Name = i.ToString(), Status = 'A' }));

        return _productCollection;
    }

    public static Product Build()
    {
        return Build(null);
    }

    public static Product Build(Product? product)
    {
        return new Product
        {
            ID = product?.ID ?? 1,
            Name = product?.Name ?? "Product1",
            Status = product?.Status ?? 'A'
        };
    }
}
