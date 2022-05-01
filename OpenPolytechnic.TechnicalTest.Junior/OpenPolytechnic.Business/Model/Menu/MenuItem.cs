﻿using OpenPolytechnic.Business.Model.Menu.Enum;

namespace OpenPolytechnic.Business.Model.Menu
{
    public class MenuItem
    {
        public MenuItem(
            int id,
            string name,
            string description,
            decimal cost,
            MenuItemType itemType,
            bool childrensMenuItem)
        {
            Id = id;
            Name = name;
            Description = description;
            ItemType = itemType;
            Cost = cost;
            ChildrensMenu = childrensMenuItem;
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public MenuItemType ItemType { get; internal set; }
        public decimal Cost { get; internal set; }
        public bool ChildrensMenu { get; internal set; }

    }
}
