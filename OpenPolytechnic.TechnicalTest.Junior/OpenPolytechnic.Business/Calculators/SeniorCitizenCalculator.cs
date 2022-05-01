using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Calculators
{
    public class SeniorCitizenCalculator
    {
        public SeniorCitizenCalculator()
        {

        }

        public OrderCost CalculateOrderCostForPartyMember(IEnumerable<MenuItem> menuItems)
        {
            var originalCost = 0m;
            var surcharge = 0m;
            var discountAmount = 0m;

            foreach (var menuItem in menuItems)
            {
                originalCost += menuItem.Cost;
                if (menuItem.ChildrensMenu == true)
                {
                    surcharge += menuItem.Cost * 0.1m;
                }
                else
                {
                    discountAmount += menuItem.Cost * 0.3m;
                }
            }

            var totalOwing = originalCost + surcharge - discountAmount;

            return new OrderCost
            {
                OriginalCost = originalCost,
                DiscountAmount = discountAmount,
                Surcharge = surcharge,
                TotalOwing = totalOwing
            };
        }
    }
}
