using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Interfaces;
using VendingMachine.Objects;

namespace VendingMachine.Handlers
{
    public class ProductHandler : IProductHandler
    {
        public Product SelectProduct(Product product)
        {
            product.SoldProduct();
            return product;
        }
    }
}
