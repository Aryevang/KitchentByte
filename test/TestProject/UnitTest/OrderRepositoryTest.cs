using System.Collections.Generic;
using Domain;
using Infrastructure.Repositories;
using InventoryProject.UnitTest.Fixtures;
using Xunit;

namespace OrderProject.UnitTest;

public class OrderRepositoryTest
{
    private readonly OrderRepository _sut;

    public OrderRepositoryTest()
    {
        _sut = new OrderRepository();
    }

    [Fact]
    public void ShouldAddOneOrder()
    {
        //Given
        Order? order = OrderFixture.BuildOrder();

        //When
        _sut.Add(order);

        //Then
        int totalOrderCount = _sut.GetAll().Count;
        Assert.Equal(1, totalOrderCount);
    }

    [Fact]
    public void ShouldDeleteOneOrder()
    {
        //Given
        List<Order> orders = OrderFixture.BuildOrder(3);
        orders.ForEach(ord =>
        {
            _sut.Add(ord);
        });

        //When
        _sut.Delete(1);
        var remainingOrder = _sut.GetByID(2);
        var orderNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count);
        Assert.Equal(2, remainingOrder?.ID);
        Assert.Null(orderNotFound);
    }

    [Fact]
    public void ShouldUpdateTheOrder()
    {
        //Given
        Order? order = OrderFixture.BuildOrder();
        _sut.Add(order);

        var orderToUpdate =_sut.GetByID(1);
        Order newOrder = orderToUpdate with { Tax = 200 };

        //When
        _sut.Update(newOrder);

        //Then
        Order? updatedOrder = _sut.GetByID(1);
        Assert.Equal(200, updatedOrder?.Tax);
    }
}

