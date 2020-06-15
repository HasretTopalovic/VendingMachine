using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineManager
    {
        void StockMachine(List<Product> products);
        string MakeSelection(Product product);
    }
}
