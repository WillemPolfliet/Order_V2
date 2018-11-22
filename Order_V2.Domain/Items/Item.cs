using Order_V2.Domain.Items.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Items
{
    class Item
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; set; }

        private Item()
        { }

        private Item(string name, decimal price, int amount, string description)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }

        public static Item CreateNewObjectOfItem(string name, decimal price, int amount, string description)
        {
            CheckIfValuesAreValid(price, amount);

            return new Item(name, price, amount, description);
        }

        private static void CheckIfValuesAreValid(decimal price, int amount)
        {
            //if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            //{ throw new ItemException("All fields are required"); }

            if (amount < 0)
            { throw new ItemException("The amount cannot be negative"); }
            if (price < 0)
            { throw new ItemException("The price cannot be negative"); }
        }
        
    }
}
