using Xunit;

namespace IoC.Test.UnitTest;

public class IoCTest
{
    private readonly IInstancePool _sut; //SUT stands for System Under Test.

    public IoCTest()
    {
        _sut = InstancePool.Instance;
    }

    [Fact]
    public void ShouldGetARegisteredInstance()
    {
        //Given
        _sut.Register(new object());

        //When
        var tc = _sut.GetInstance<object>();

        //Then
        Assert.NotNull(tc);
    }


    [Fact]
    public void ShouldReturnTheSameGUID()
    {
        //Given

        //When
        var instance1 = _sut.GetInstance<object>();
        var instance2 = _sut.GetInstance<object>();

        //Then
        Assert.True(instance1.Equals(instance2));
    }
}
