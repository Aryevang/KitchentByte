using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Repositories;
using Xunit;

namespace TestProject.UnitTest;

public class ProductRepositoryTest
{
    private readonly ProductRepository _sut;

    public ProductRepositoryTest()
    {
        _sut = new ProductRepository();
    }

    [Fact]
    public void ShouldAddAProduct()
    {
        //Given
        Product product = new Product(1, "Test",'A');

        //When
         _sut.Add(product);

        //Then
        Assert.Equal(1, _sut.Count());
    }

    [Fact]
    public void ShouldAddManyProducts()
    {
        //Given
        var products = new List<Product>(){
            new Product(1,"Test2", 'A'),
            new Product(2,"Test3", 'A'),
        };

        //When
         _sut.AddMany(products);

        //Then
        Assert.Equal(2, _sut.Count());
    }

    [Fact]
    public void ShouldGetOneProduct()
    {
        //Given
        var products = new List<Product>(){
            new Product(1,"Test2", 'A'),
            new Product(2,"Test3", 'A'),
        };
         _sut.AddMany(products);

        //When
        var product =  _sut.GetByID(2);

        //Then
        Assert.Equal("Test3", product?.Name);
    }


    [Fact]
    public void ShouldDeleteOneProduct()
    {
        //Given
        var products = new List<Product>(){
            new Product(1,"Test2", 'A'),
            new Product(2,"Test3", 'A'),
        };
         _sut.AddMany(products);

        //When
         _sut.Delete(1);
        var remainingProduct =  _sut.GetByID(2);
        var productNotFound =  _sut.GetByID(1);

        //Then
        Assert.Equal(1, _sut.Count());
        Assert.Equal("Test3", remainingProduct?.Name);
        Assert.Null(productNotFound);
    }

    [Fact]
    public void ShouldReturnSeveralProducts()
    {
        //Given
        var products = new List<Product>(){
            new Product(1,"Test2", 'A'),
            new Product(2,"Test3", 'A'),
        };
         _sut.AddMany(products);

        //When
        List<Product> retrievedproducts =  _sut.GetAll();

        //Then
        Assert.NotNull(retrievedproducts);
        Assert.Equal(2, retrievedproducts.Count);
    }

    [Fact]
    public void ShouldUpdateTheProduct()
    {
        //Given
        Product product = new Product(1, "Test", 'A');
         _sut.Add(product);
        Product newProduct = product with {Name ="Updated"};

        //When
         _sut.Update(newProduct);

        //Then
        Product? updatedProduct =  _sut.GetByID(1);
        Assert.Equal("Updated", updatedProduct?.Name);
    }
}
