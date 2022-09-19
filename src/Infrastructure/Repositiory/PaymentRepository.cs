using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly List<Payment> _paymentCollection;
    public PaymentRepository()
    {
        _paymentCollection = new();
    }

    public void Add(Payment model)
    {
        long currentID = _paymentCollection.Count;
        currentID++;
        Payment newPayment = model with { ID = currentID };
        _paymentCollection.Add(newPayment);
    }

    public void Delete(long id)
    {
        Payment paymentToDelete = new Payment { ID = id, Status = 'D' };
        if (paymentToDelete is not null)
            Update(paymentToDelete);
    }

    public List<Payment> GetAll()
    {
        return _paymentCollection.Where(p => p.Status == 'A').ToList();
    }

    public Payment? GetByID(long id)
    {
        return _paymentCollection?.SingleOrDefault(p => p.Status == 'A' && p.ID == id);
    }

    public void Update(Payment model)
    {
        Payment? paymentToUpdate = GetByID(model.ID);
        if(paymentToUpdate is not null)
        {
           paymentToUpdate.ProcessedOrder = model?.ProcessedOrder ?? paymentToUpdate.ProcessedOrder;
           paymentToUpdate.TotalPaid = model?.TotalPaid ?? paymentToUpdate.TotalPaid;
           paymentToUpdate.PaymentMethod = model?.PaymentMethod ?? paymentToUpdate.PaymentMethod;
           paymentToUpdate.Status = model?.Status ?? paymentToUpdate.Status;
        }
    }
}

