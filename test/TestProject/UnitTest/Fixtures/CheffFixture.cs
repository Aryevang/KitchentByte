using System.Collections.Generic;
using Domain;

namespace TestProject.UnitTest.Fixtures;

public static class CheffFixture
{
    public static List<Cheff> BuildCheff(int times)
    {
        List<Cheff> cheffList = new();

        for (int i = 1; i <= times; i++)
        {
            cheffList.Add(new Cheff { ID = 0, Level = Experience.Junior, OrderCapacity = i, Status = 'A' });
        }

        return cheffList;
    }

    public static Cheff BuildCheff()
    {
        return new Cheff { ID = 0, Level = Experience.Junior, OrderCapacity = 3, Status = 'A' };
    }
}

