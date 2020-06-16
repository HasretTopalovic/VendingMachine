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
            return new Product("Cola", 100, 20, 0);
        }

        public static Product GetChips()
        {
            return new Product("Chips", 50, 20, 0);
        }

        public static Product GetCandy()
        {
            return new Product("Candy", 65, 20, 0);
        }
    }
}
