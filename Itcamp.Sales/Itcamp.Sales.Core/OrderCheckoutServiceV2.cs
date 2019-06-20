using System;
using System.Linq;

namespace Stachka.Sales.Core
{
    public class OrderCheckoutServiceV2
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly DiscountCalculator _discountCalculator;

        public OrderCheckoutServiceV2(IOrdersRepository ordersRepository, DiscountCalculator discountCalculator)
        {
            _ordersRepository = ordersRepository;
            _discountCalculator = discountCalculator;
        }

        public void CheckoutV2(long orderId)
        {
            var order = _ordersRepository.GetOrder(orderId);
            var discount = _discountCalculator.CalculateDiscountBy(order.CustomerId);
            order.ApplyDiscount(discount);
            order.State = OrderState.AwaitingPayment;
            _ordersRepository.SaveOrder(order);
        }
    }

    public class DiscountCalculator
    {
        private readonly IOrdersRepository _ordersRepository;
        public DiscountCalculator(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public decimal CalculateDiscountBy(long customerId)
        {
            var completedOrdersCount = _ordersRepository.GetLast3YearsCompletedOrdersCountFor(customerId);
            return DiscountBy(completedOrdersCount);
        }

        private decimal DiscountBy(int completedOrdersCount)
        {
            if (completedOrdersCount >= 5)
                return 30;

            if (completedOrdersCount >= 3)
                return 20;

            if (completedOrdersCount >= 1)
                return 10;

            return 0;
        }
    }

}