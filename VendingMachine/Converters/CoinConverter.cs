using System.Linq;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Enums;
using VendingMachine.Interfaces;
using VendingMachine.Objects;

namespace VendingMachine.Converters
{
    public class CoinConverter : ICoinConverter
    {
        public List<Coin> AvailableTender;
        public Coin MeasureCoin(decimal weight, decimal width)
        {
            decimal value = 0m;
            CoinType coinType = CoinType.Unassigned;
            bool isValid = false;
            switch (weight)
            {
                case 2.268M:
                    if (width == 1.35M)
                    {
                        value = 10;
                        coinType = CoinType.Dime;
                        isValid = true;
                    }
                    break;
                case 2.5M:
                    if (width == 1.52M)
                    {
                        value = 1;
                        coinType = CoinType.Penny;
                    }
                    break;
                case 5M:
                    if (width == 1.95M)
                    {
                        value = 5;
                        coinType = CoinType.Nickel;
                        isValid = true;
                    }
                    break;
                case 5.67M:
                    if (width == 1.75M)
                    {
                        value = 25;
                        coinType = CoinType.Quarter;
                        isValid = true;
                    }
                    break;
                default:
                    break;
            }

            var coin = new Coin(0, 0, 0, coinType, false);
            if (value > 0 && coinType != CoinType.Unassigned)
            {
                coin = new Coin(weight, width, value, coinType, isValid);
            }

            return coin;
        }

        public CoinConverter(List<Coin> availableTender)
        {
            AvailableTender = availableTender;
        }

        public List<Coin> CalculateChange(List<Coin> coins, decimal amount)
        {
            if (amount == 0) return null;

            var result = new List<Coin>();
            var counter = 0;
            while (coins.ElementAt(counter).Value <= amount)
            {
                result.Add(coins.ElementAt(counter));
                amount = amount - coins.ElementAt(counter).Value;
                if (coins.ElementAt(counter).Value > amount)
                {
                    counter += 1;
                }
            }

            return result;
        }

    }
}
