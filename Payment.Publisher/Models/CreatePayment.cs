namespace Payment.Models
{
  public class CreatePayment
  {
    public string CardNumber { get; set; } = default!;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = default!;
  }

}
