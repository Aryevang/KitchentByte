namespace Domain;

public record Payment(long ID, long OrderID, double TotalPaid, PaymentMethod ViaOfPayment);

//Provide the supported payment methods.
public enum PaymentMethod
{
    TC,
    Cash
}
