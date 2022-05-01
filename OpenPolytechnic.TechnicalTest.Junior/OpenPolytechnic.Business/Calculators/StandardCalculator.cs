using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Calculators
{
    public class StandardCalculator
    {
        public StandardCalculator()
        {

        }

        public OrderCost CalculateOrderCostForPartyMember(IEnumerable<MenuItem> menuItems)
        {
            var originalCost = 0m;
            var surcharge = 0m;

            foreach(var menuItem in menuItems)
            {
                originalCost += menuItem.Cost;
                if (menuItem.ChildrensMenu == true)
                {
                    surcharge += menuItem.Cost * 0.1m;
                }
            }

            var totalOwing = originalCost + surcharge;

            return new OrderCost
            {
                OriginalCost = originalCost,
                Surcharge = surcharge,
                TotalOwing = totalOwing
            };
        }
    }
}
