using System;
using Sample.Enums;

namespace Sample.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal PaymentAmount { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public Order Order { get; set; }
    public DateTime CreatedAt {get;}

    public Payment(int id, Order order, decimal paymentAmount, PaymentMethod paymentMethod)
    {
        PaymentId = id;
        Order = order;
        PaymentAmount = paymentAmount;
        PaymentMethod = paymentMethod;
        CreatedAt = DateTime.Now;
    }
    


}
