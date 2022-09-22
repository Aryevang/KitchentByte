using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Controllers;
using NSubstitute;
using TestProject.UnitTest.Fixtures;
using Xunit;

namespace TestProject.UnitTest;

public class ProductControllerTest
{
    private readonly ProductController _sut;
    private readonly IProductRepository _repo = Substitute.For<IProductRepository>();

    public ProductControllerTest()
    {
        _sut = new ProductController(_repo);
    }

    [Fact]
    public void ShouldAddOneProduct()
    {
        //Given
        int counter = 0;
        var product = ProductFixture.Build();

        //When
        _repo.When(x => x.Add(product))
            .Do(x => counter++);
        _sut.Create(product);

        //Then
        Assert.Equal(1, counter);
    }

    [Fact]
    public void ShouldAddManyProducts()
    {
        //Given
        int counter = 0;
        var products = ProductFixture.Build(3);

        //When
        _repo.When(x => x.AddMany(products))
            .Do(x => counter++);
        _sut.CreateMany(products);

        //Then
        Assert.Equal(1, counter);
    }

    [Fact]
    public void ShouldGetOneProductById()
    {
        //Given
        Product newProd = ProductFixture.Build();
        _repo.GetByID(Arg.Any<long>()).Returns(newProd);

        //When
        var product = _sut.Get(2);

        //Then
        Assert.NotNull(product);
        Assert.Equal(newProd.Name, product.Name);
    }

    [Fact]
    public void ShouldGetManyProducts()
    {
        //Given
        var newPeroduts = ProductFixture.Build(4);
        _repo.GetAll().Returns(newPeroduts);

        //When
        var prods = _sut.GetAll();

        //Then
        Assert.NotNull(prods);
        Assert.Equal(4, prods.Count);
    }

    [Fact]
    public void ShouldDeleteOneProduct()
    {
        //Given
        var newPeroduts = ProductFixture.Build(4);
        int counter = 0;

        //When
        _repo.When(x => x.Delete(Arg.Any<long>()))
            .Do(x => counter++);
        _sut.Delete(1);

        //Then
        Assert.Equal(1, counter);
    }

    [Fact]
    public void ShouyldUpdateOneProduct()
    {
        //Given
        int counter = 0;
        Product prod = ProductFixture.Build();

        //When
        _repo.When(x => x.Update(Arg.Any<Product>()))
            .Do(x => counter++);
        _sut.Update(prod);

        //Then
        Assert.Equal(1, counter);
    }
}
