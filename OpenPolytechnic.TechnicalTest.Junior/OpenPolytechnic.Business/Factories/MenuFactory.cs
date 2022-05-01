﻿using OpenPolytechnic.Business.Model.Menu;
using System.Collections.Generic;

namespace OpenPolytechnic.Business.Factories
{
    public class MenuFactory
    {
        private readonly MenuItemFactory menuItemFactory;

        public MenuFactory()
        {
            menuItemFactory = new MenuItemFactory();
        }

        public Menu RegularMenu() 
        {
            var items = new List<MenuItem>
            {
                menuItemFactory.CurlyFries(),
                menuItemFactory.HotWings(),
                menuItemFactory.GarlicBread(),
                menuItemFactory.SquidRings(),
                menuItemFactory.CheeseBurger(),
                menuItemFactory.KidsBurger(),
                menuItemFactory.ChickenNuggets(),
                menuItemFactory.Pizza(),
                menuItemFactory.Steak(),
                menuItemFactory.FishAndChips(),
                menuItemFactory.GardenSalad(),
                menuItemFactory.IceCreamCone(),
                menuItemFactory.FruitSalad(),
                menuItemFactory.Sundae(),
                menuItemFactory.BananaSplit(),
                menuItemFactory.Cola(),
                menuItemFactory.Lemonade(),
                menuItemFactory.AppleJuice(),
                menuItemFactory.StrawberryMilk(),
                menuItemFactory.SodaWater()
            };
            return new Menu
            {
                Name = "Y'Shtola's Emporium Menu",
                Items = items
            };
        }

        public Menu WeekendMenu()
        {
            var items = new List<MenuItem>
            {              
                menuItemFactory.Pizza(),
                menuItemFactory.AllDayBreakfast(),
                menuItemFactory.FruitSalad(),
                menuItemFactory.Cola(),
                menuItemFactory.Lemonade(),
                menuItemFactory.AppleJuice(),
                menuItemFactory.StrawberryMilk(),
                menuItemFactory.SodaWater()
            };
            return new Menu
            {
                Name = "Y'Shtola's Emporium Weekend Menu",
                Items = items
            };
        }

        public Menu CateringMenu()
        {
            var items = new List<MenuItem>
            {
                menuItemFactory.SushiPlatter(),
                menuItemFactory.SandwichPlatter(),
                menuItemFactory.CheesePlatter(),
                menuItemFactory.FruitPlatter(),
                menuItemFactory.SoupBowl(),
                menuItemFactory.TeaDispenser(),
                menuItemFactory.CoffeeDispenser()
            };
            return new Menu
            {
                Name = "Fen's Catering Menu",
                Items = items
            };
        }
    }
}
