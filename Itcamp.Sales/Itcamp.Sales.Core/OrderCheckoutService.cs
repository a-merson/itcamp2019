﻿using System;
using System.Linq;

namespace Itcamp.Sales.Core
{
    public class OrderCheckoutService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderCheckoutService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Checkout(long id)
        {
            var ord = _ordersRepository.GetOrder(id);
            var orders = _ordersRepository.GetOrders()
                                          .Count(o => o.CustomerId == ord.CustomerId
                                                      && o.StateId == 3
                                                      && o.OrderDate >= DateTime.UtcNow.AddYears(-3));

            ord.Price *= (100 - (orders >= 5 ? 30m : orders >= 3 ? 20m : orders >= 1 ? 10m : 0)) / 100;
            ord.StateId = 1;
            _ordersRepository.SaveOrder(ord);
        }
    }
}
