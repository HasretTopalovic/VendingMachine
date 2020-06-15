using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Interfaces
{
    public interface IProductHandler
    {
        Product SelectProduct(Product product);
    }
}
