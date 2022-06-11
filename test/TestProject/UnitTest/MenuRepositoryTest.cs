using System.Collections.Generic;
using Domain;
using Infrastructure.Repositories;
using InventoryProject.UnitTest.Fixtures;
using Xunit;

namespace TestProject.UnitTest;

public class MenuRepositoryTest
{
    private readonly MenuRepository _sut;

    public MenuRepositoryTest()
    {
        _sut = new MenuRepository();
    }

    [Fact]
    public void AddedMenu_gets_Upsate()
    {
        //Given
        var menu = MenuFixture.BuildMenu();

        //When
        _sut.Add(menu);

        //Then
        Assert.Equal(1, _sut.GetByID(1)?.ID);
    }

    [Fact]
    public void ShouldAddAMenu()
    {
        //Given
        Menu menu = MenuFixture.BuildMenu();

        //When
        _sut.Add(menu);

        //Then
        Assert.Equal(1, _sut.GetAll().Count);
    }

    [Fact]
    public void ShouldGetOneMenuById()
    {
        //Given
        var menus = MenuFixture.BuildMenu(3);
        menus.ForEach(menu =>
        {
            _sut.Add(menu);
        });

        //When
        var menu = _sut.GetByID(2);

        //Then
        Assert.Equal("menu1", menu?.Name);
    }


    [Fact]
    public void ShouldDeleteOneMenu()
    {
        //Given
        var menus = MenuFixture.BuildMenu(3);
        menus.ForEach(menu =>
        {
            _sut.Add(menu);
        });

        //When
        _sut.Delete(1);
        var remainingMenu = _sut.GetByID(2);
        var menuNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count);
        Assert.Equal("menu1", remainingMenu?.Name);
        Assert.Null(menuNotFound);
    }

    [Fact]
    public void ShouldReturnSeveralMenus()
    {
        //Given
        var menus = MenuFixture.BuildMenu(5);
        menus.ForEach(menu =>
        {
            _sut.Add(menu);
        });

        //When
        List<Menu> retrievedmenus = _sut.GetAll();

        //Then
        Assert.NotNull(retrievedmenus);
        Assert.Equal(5, retrievedmenus.Count);
    }


    [Fact]
    public void ShouldUpdateTheMenu()
    {
        //Given
        Menu menu = MenuFixture.BuildMenu();
        _sut.Add(menu);
        long id = _sut.GetAll().Count;
        Menu newMenu = menu with { ID = id, Name = "UpdatedMenu" };

        //When
        _sut.Update(newMenu);

        //Then
        Assert.Equal("UpdatedMenu", _sut.GetByID(1)?.Name);
    }
}

