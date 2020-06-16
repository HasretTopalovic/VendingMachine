using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineManager
    {
        void StockProductsInMachine(List<Product> products);
        void StockChangeInMachine(List<Coin> change);
        string MakeSelection(Product product);
    }
}
