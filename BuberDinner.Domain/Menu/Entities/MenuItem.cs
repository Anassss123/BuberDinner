using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }
        private MenuItem(MenuItemId menuItemId, string name, string description)
            :base(menuItemId)
        {
            Name = name;
            Description = description;
        }
        public static MenuItem Create(string name, string description )
        {
            return new(MenuItemId.CreateUnique() , name, description);
        }
    }
}