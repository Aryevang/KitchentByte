using System.Collections.Generic;
using Domain;
using Infrastructure.Repositories;
using InventoryProject.UnitTest.Fixtures;
using Xunit;

namespace DishProject.UnitTest;

public class DishRepositoryTest
{
    private readonly DishRepository _sut;
    public DishRepositoryTest()
    {
        _sut = new DishRepository();
    }

    [Fact]
    public void ShouldAddOneDish()
    {
        //Given
        Dish? dish = DishFixture.BuildDish();

        //When
        _sut.Add(dish);

        //Then
        int totalDishCount = _sut.GetAll().Count;
        Assert.Equal(1, totalDishCount);
    }

    [Fact]
    public void ShouldDeleteOneDish()
    {
        //Given
        List<Dish> dishes = DishFixture.BuildDish(3);
        dishes.ForEach(inv =>
        {
            _sut.Add(inv);
        });

        //When
        _sut.Delete(1);
        var remainingDish = _sut.GetByID(2);
        var dishNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count);
        Assert.Equal("dish2", remainingDish?.Name);
        Assert.Null(dishNotFound);
    }

    [Fact]
    public void ShouldUpdateTheDishName()
    {
        //Given
        Dish? dish = DishFixture.BuildDish();
        _sut.Add(dish);

        //When
        Dish newDish = _sut.GetByID(1) with { Name = "UpdatedDish" };
        _sut.Update(newDish);

        //Then
        Dish? updatedDish = _sut.GetByID(1);
        Assert.Equal("UpdatedDish", updatedDish?.Name);
    }
}

