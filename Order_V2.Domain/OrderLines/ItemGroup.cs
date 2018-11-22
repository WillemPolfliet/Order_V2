using Order_V2.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.OrderLines
{
    public class ItemGroup
    {
        public Guid ItemID { get; private set; }
        public int ItemAmount { get; private set; }
        public decimal PricePerItem { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public string Description { get; private set; }

        public decimal PriceOf_OrderItemGroup { get { return PricePerItem * ItemAmount; } }


        //public ItemGroup(Item givenItem, int orderingAmount, DateTime orderDate)
        //{
        //    ItemID = givenItem.Id;
        //    ItemAmount = orderingAmount;
        //    PricePerItem = givenItem.Price;

        //    if (givenItem.Amount == 0)
        //    { ShippingDate = orderDate.AddDays(7); }
        //    else if (givenItem.Amount == orderingAmount)
        //    { ShippingDate = orderDate.AddDays(7); }
        //    else
        //    { ShippingDate = orderDate.AddDays(1); }
        //}

        //public ItemGroup(Guid itemID, int itemAmount)
        //{
        //    ItemID = itemID;
        //    ItemAmount = itemAmount;
        //}

        //public static ItemGroup CreateNewObjectOfItemGroup(in ItemAmount, decimal price, int amount, string description)
        //{
        //    CheckIfValuesAreValid(price, amount);

        //    return new Item(name, price, amount, description);
        //}

    }
}
