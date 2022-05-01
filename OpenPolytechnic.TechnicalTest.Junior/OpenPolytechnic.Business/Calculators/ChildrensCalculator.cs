using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Calculators
{
    public class ChildrensCalculator
    {
        public ChildrensCalculator()
        {

        }

        public OrderCost CalculateOrderCostForPartyMember(IEnumerable<MenuItem> menuItems)
        {
            var originalCost = 0m;
            var discountedAmount = 0m;

            foreach (var menuItem in menuItems)
            {
                originalCost += menuItem.Cost;
                if (menuItem.ChildrensMenu == false)
                {
                    discountedAmount += menuItem.Cost * 0.5m;
                }
            }

            var totalOwing = originalCost - discountedAmount;

            return new OrderCost
            {
                OriginalCost = originalCost,
                DiscountAmount = discountedAmount,
                TotalOwing = totalOwing
            };
        }
    }
}
