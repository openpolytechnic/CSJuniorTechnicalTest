using OpenPolytechnic.Business.Calculators;
using OpenPolytechnic.Business.Factories;
using OpenPolytechnic.Business.Model.Menu;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Model.Order.Enum;
using OpenPolytechnic.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenPolytechnic.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly ChildrensCalculator childrensCalculator;
        private readonly SeniorCitizenCalculator seniorCitizenCalculator;
        private readonly StudentCalculator studentCalculator;
        private readonly StandardCalculator standardCalculator;
        private readonly MenuItemFactory menuItemFactory;

        public OrderService()
        {
            childrensCalculator = new ChildrensCalculator();
            seniorCitizenCalculator = new SeniorCitizenCalculator();
            studentCalculator = new StudentCalculator();
            standardCalculator = new StandardCalculator();
            menuItemFactory = new MenuItemFactory();
        }

        public OrderSummary GetOrderSummary(Orders orders)
        {
            var orderSummary = new OrderSummary();
            var allMenuItems = new List<MenuItem>();

            foreach(var individualOrder in orders.IndividualOrders)
            {
                var menuItems = GetMenuItemsForOrder(individualOrder.MenuItemIds);
                allMenuItems.AddRange(menuItems);
                OrderCost orderCost;

                if (individualOrder.customerType == CustomerType.Child)
                {
                    orderCost = childrensCalculator.CalculateOrderCostForPartyMember(menuItems);
                }
                else if (individualOrder.customerType == CustomerType.Student)
                {
                    orderCost = studentCalculator.CalculateOrderCostForPartyMember(menuItems);
                }
                else if (individualOrder.customerType == CustomerType.SeniorCitizen)
                {
                    orderCost = seniorCitizenCalculator.CalculateOrderCostForPartyMember(menuItems);
                }
                else
                {
                    orderCost = standardCalculator.CalculateOrderCostForPartyMember(menuItems);
                }

                orderSummary.OriginalCost += orderCost.OriginalCost;
                orderSummary.Surcharge += orderCost.Surcharge;
                orderSummary.DiscountAmount += orderCost.DiscountAmount;
                orderSummary.TotalCost += orderCost.TotalOwing;
            }

            orderSummary.Items = allMenuItems;

            return orderSummary;
        }

        private IEnumerable<MenuItem> GetMenuItemsForOrder(IEnumerable<int> menuItemIds)
        {
            var result = new List<MenuItem>();
            var menuItems = menuItemFactory.GetAllMenuItems();
            foreach(var menuItem in menuItems)
            {
                if (menuItemIds.Contains(menuItem.Id)) 
                {
                    result.Add(menuItem);
                }
            }
            return result;
        }
}
}
