using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Repositories;
using TestProject.UnitTest.Fixtures;
using Xunit;

namespace TestProject.UnitTest;

public class CheffRepositoryTest
{
    private readonly CheffRepository _sut;

    public CheffRepositoryTest()
    {
        _sut = new CheffRepository();
    }

    [Fact]
    public void ShouldAddACheff()
    {
        //Given
        Cheff cheff = CheffFixture.BuildCheff(); 

        //When
        _sut.Add(cheff);

        //Then
        int totalAddedCheffs = _sut.GetAll().Count();
        Assert.Equal(1, totalAddedCheffs);
    }

    [Fact]
    public void ShouldGetOneCheffById()
    {
        //Given
        var cheffs = CheffFixture.BuildCheff(3);
        cheffs.ForEach(c =>
        {
            _sut.Add(c);
        });

        //When
        var cheff = _sut.GetByID(2);

        //Then
        Assert.Equal(3, _sut.GetAll().Count);
        Assert.Equal(2, cheff?.OrderCapacity);
    }


    [Fact]
    public void ShouldDeleteOneCheff()
    {
        //Given
        var cheffs = CheffFixture.BuildCheff(3);
        cheffs.ForEach(c =>
        {
            _sut.Add(c);
        });

        //When
        _sut.Delete(1);
        var remainingCheff = _sut.GetByID(2);
        var cheffNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count());
        Assert.Equal(2, remainingCheff?.OrderCapacity);
        Assert.Null(cheffNotFound);
    }

    [Fact]
    public void ShouldReturnSeveralCheffs()
    {
        //Given
        var cheffs = CheffFixture.BuildCheff(3);
        cheffs.ForEach(c =>
        {
            _sut.Add(c);
        });

        //When
        List<Cheff> retrievedcheffs = _sut.GetAll();

        //Then
        Assert.NotNull(retrievedcheffs);
        Assert.Equal(3, retrievedcheffs.Count);
    }

    [Fact]
    public void ShouldUpdateTheCheff()
    {
        //Given
        Cheff cheff  = CheffFixture.BuildCheff();
        _sut.Add(cheff);
        Cheff newcheff = _sut.GetByID(1) with { Level = Experience.Senior };

        //When
        _sut.Update(newcheff);

        //Then
        Cheff? updatedcheff = _sut.GetByID(1);
        Assert.Equal(Experience.Senior, updatedcheff?.Level);
    }
}

