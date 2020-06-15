using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Objects
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        //stock and quantity sold could also be removed? Possibly more of a vending machine property
        public int Stock { get; private set; }
        public int QuantitySold { get; private set; }

        public Product(string name, decimal price, int stock, int quantitySold)
        {
            Name = name;
            Price = price;
            Stock = stock;
            QuantitySold = quantitySold;
        }

        public void SoldProduct()
        {
            //this shouldn't be in here I feel
            if (Stock > 0)
            {
                Stock = Stock - 1;
                QuantitySold = QuantitySold + 1;
            }
        }
    }
}
