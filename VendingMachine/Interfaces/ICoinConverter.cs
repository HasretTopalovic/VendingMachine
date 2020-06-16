using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Objects;

namespace VendingMachine.Interfaces
{
    public interface ICoinConverter
    {
        List<Coin> AvailableTender { get; set; }
        Coin MeasureCoin(decimal weight, decimal width);
        List<Coin> CalculateChange(List<Coin> coins, decimal amount);
    }
}
