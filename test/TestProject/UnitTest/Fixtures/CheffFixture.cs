using System.Collections.Generic;
using Domain;

namespace TestProject.UnitTest.Fixtures;

public static class CheffFixture
{
    public static List<Cheff> Build(int times)
    {
        List<Cheff> _cheffColletion = new();
        for (int i = 1; i <= times; i++)
            _cheffColletion.Add(Build(new Cheff { ID = i, Level = Experience.Junior, OrderCapacity = i, Status = 'A' }));

        return _cheffColletion;
    }

    public static Cheff Build()
    {
        return Build(null);
    }

    public static Cheff Build(Cheff? cheff)
    {
        return new Cheff
        {
            ID = cheff?.ID ?? 1,
            Level = cheff?.Level ?? Experience.Junior,
            OrderCapacity = cheff?.OrderCapacity ?? 1,
            Status = cheff?.Status ?? 'A'
        };
    }
}

