using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Interfaces
{
    public interface ICoinHandler
    {
        List<Coin> AcceptCoins(Dictionary<decimal, decimal> potentialCoins);
        void ReturnCoins(List<Coin> coins);
        List<Coin> MakeChange(decimal costPrice, List<Coin> tender);

        //Coin MeasureCoin(decimal weight, decimal width);
    }
}
