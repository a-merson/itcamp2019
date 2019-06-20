using System;
using System.Collections.Generic;
using System.Text;

namespace Stachka.Sales.Core
{
    class Dummy
    {
        public void CallCheckOutService()
        {
            new OrderCheckoutService(null).Checkout(0);
            new OrderCheckoutServiceV2(null, null).CheckoutV2(0);
        }
    }
}
