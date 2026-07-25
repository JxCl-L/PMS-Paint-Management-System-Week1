using System;

namespace Sample.Models;

public class User
{
    public List<Order> OrderHistory { get; set; }
    public List<Payment> PaymentHistory { get; set; }
    public User()
    {
        // need to initialzie the history lists otherwise null exception
        OrderHistory = new List<Order>();
        PaymentHistory = new List<Payment>();
    }

    public Order? GetMostExpensiveOrder()
    {
        return OrderHistory.OrderByDescending(p => p.TotalPrice).FirstOrDefault();
        // order+? and First() => FirstOrDefault()
        // avoid empty list throw exception
    }
    public Order GetMostRecentOrder()
    {
        return OrderHistory.OrderByDescending(p => p.CreatedAt).First();
    }
    public Payment GetPaymentWithLowestPrice()
    {
        return PaymentHistory.OrderBy(p=>p.PaymentAmount).First();
    }
    public Payment GetMostRecentPayment()
    {
        return PaymentHistory.OrderByDescending(p => p.CreatedAt).First();
    }
    public List<Payment> GetPaymentsAbove10()
    {
        return PaymentHistory.Where(p=>p.PaymentAmount>10).ToList();
    }
}
