using System.Collections.Generic;
using Domain;
using Infrastructure.Repositories;
using PaymentProject.UnitTest.Fixtures;
using Xunit;

namespace PaymentProject.UnitTest;

public class PaymentRepositoryTest
{
    private readonly PaymentRepository _sut;
    public PaymentRepositoryTest()
    {
        _sut = new PaymentRepository();
    }

    [Fact]
    public void ShouldAddOnePayment()
    {
        //Given
        Payment payment = PaymentFixture.Build();

        //When
        _sut.Add(payment);

        //Then
        int totalPaymentCount = _sut.GetAll().Count;
        Assert.Equal(1, totalPaymentCount);
    }

    [Fact]
    public void ShouldDeleteOnePayment()
    {
        //Given
        List<Payment> paymentes = PaymentFixture.Build(3);
        paymentes.ForEach(p =>
        {
            _sut.Add(p);
        });

        //When
        _sut.Delete(1);
        var remainingPayment = _sut.GetByID(2);
        var paymentNotFound = _sut.GetByID(1);

        //Then
        Assert.Equal(2, _sut.GetAll().Count);
        Assert.Equal(1000, remainingPayment?.TotalPaid);
        Assert.Null(paymentNotFound);
    }

    [Fact]
    public void ShouldUpdateThePaymentMethod()
    {
        //Given
        Payment payment = PaymentFixture.Build();
        _sut.Add(payment);

        //When
        Payment newPayment = new Payment { ID = 1, PaymentMethod = nameof(PaymentMethod.TC) };
        _sut.Update(newPayment);

        //Then
        Payment? updatedPayment = _sut.GetByID(1);
        Assert.Equal(nameof(PaymentMethod.TC), updatedPayment?.PaymentMethod);
    }

    [Fact]
    public void ShouldNotUpdateTotalPaid()
    {
        //Given
        Payment payment = PaymentFixture.Build();
        _sut.Add(payment);

        //When
        Payment newPayment = new Payment { ID = 1, TotalPaid = null };
        _sut.Update(newPayment);

        //Then
        Payment? updatedPayment = _sut.GetByID(1);
        Assert.Equal(500, updatedPayment?.TotalPaid);
    }
}

