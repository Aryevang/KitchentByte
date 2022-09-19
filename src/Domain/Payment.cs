namespace Domain;

public record Payment
{
    public long ID { get; set; }
    public Order? ProcessedOrder { get; set; }
    public double? TotalPaid { get; set; }
    public string? PaymentMethod { get; set; }
    public char? Status { get; set; }
}

//Provide the supported payment methods.
public enum PaymentMethod
{
    TC,
    Cash
}
