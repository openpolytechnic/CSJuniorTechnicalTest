using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Calculators
{
    class StudentCalculator
    {
        public OrderCost CalculateOrderCostForPartyMember(IEnumerable<MenuItem> menuItems)
        {
            var originalCost = 0m;
            var discountAmount = 0m;

            foreach (var menuItem in menuItems)
            {
                originalCost += menuItem.Cost;
                if (menuItem.ChildrensMenu == false)
                {
                    discountAmount += menuItem.Cost * 0.8m;
                }
            }

            var totalOwing = originalCost - discountAmount;

            return new OrderCost
            {
                OriginalCost = originalCost,
                DiscountAmount = discountAmount,
                TotalOwing = totalOwing
            };
        }
    }
}
