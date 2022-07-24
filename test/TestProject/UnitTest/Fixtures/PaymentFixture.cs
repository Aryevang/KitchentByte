using Domain;
using System.Collections.Generic;

namespace PaymentProject.UnitTest.Fixtures;

public static class PaymentFixture
{
    public static List<Payment> Build(int times)
    {
        List<Payment> _dishCollection = new();
        for (int i = 1; i <= times; i++)
            _dishCollection.Add(Build(new Payment { TotalPaid = 500 * i, Status = 'A'}));

        return _dishCollection;
    }

    public static Payment Build()
    {
        return Build(null);
    }

    public static Payment Build(Payment? payment)
    {
        return new Payment 
        {
            ID = payment?.ID ?? 1,
            ProcessedOrder = payment?.ProcessedOrder ?? new Order(), //This is going to be changed once the other fixtures are modified.
            TotalPaid = payment?.TotalPaid ?? 500,
            ViaOfPayment = payment?.ViaOfPayment ?? PaymentMethod.Cash,
            Status = payment?.Status ?? 'A'
        };
    }
}

