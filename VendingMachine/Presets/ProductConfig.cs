using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Presets
{
    public class ProductConfig
    {
        public static Product GetCola()
        {
            return new Product("Cola", 1, 20, 0);
        }

        public static Product GetChips()
        {
            return new Product("Chips", 0.5M, 20, 0);
        }

        public static Product GetCandy()
        {
            return new Product("Candy", 0.65M, 20, 0);
        }
    }
}
