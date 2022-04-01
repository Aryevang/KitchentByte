using Xunit;
using Xunit.Abstractions;

namespace IoC.Test.UnitTest;

public class IoCTest
{
    private readonly InstancePool _sut; //SUT stands for System Under Test.

    public IoCTest(ITestOutputHelper output)
    {
        _sut = InstancePool.Instance;
    }

    [Fact]
    public void ShouldGetARegisteredInstance()
    {
        //Given
        _sut.Register<TestClass>();

        //When
        var tc = _sut.GetInstance<TestClass>();

        //Then
        Assert.NotNull(tc);
    }


    [Fact]
    public void ShouldReturnTheSameGUID()
    {
        //Given

        //When
        var instance1 = _sut.GetInstance<TestClass>();
        var instance2 = _sut.GetInstance<TestClass>();

        //Then
        Assert.Equal(instance1.GUID, instance2.GUID);
    }

}
