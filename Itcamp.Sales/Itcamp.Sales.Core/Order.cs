using System;
using System.Collections.Generic;

namespace Stachka.Sales.Core
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int StateId { get; set; }

        public OrderState State { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }

        public void ApplyDiscount(decimal discount)
        {
            Discount = discount;
            FinalPrice = Price * (100 - discount) / 100;
        }
    }


    public enum OrderState
    {
        Created = 0,
        AwaitingPayment = 1,
        Paid = 2,
        Completed = 3
    }
}
