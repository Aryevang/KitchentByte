using Domain;
using System.Collections.Generic;

namespace PaymentProject.UnitTest.Fixtures;

public static class PaymentFixture
{
    public static List<Payment> Build(int times)
    {
        List<Payment> _paymentCollection = new();
        for (int i = 1; i <= times; i++)
            _paymentCollection.Add(Build(new Payment { TotalPaid = 500 * i, Status = 'A'}));

        return _paymentCollection;
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
            PaymentMethod = payment?.PaymentMethod ?? nameof(PaymentMethod.Cash),
            Status = payment?.Status ?? 'A'
        };
    }
}

