using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Converters;
using VendingMachine.Enums;
using VendingMachine.Interfaces;
using VendingMachine.Objects;

namespace VendingMachine.Handlers
{
    public class CoinHandler : ICoinHandler
    {
        private CoinConverter _coinConverter;

        public CoinHandler(CoinConverter coinConverter)
        {
            _coinConverter = coinConverter;
        }
        public List<Coin> AcceptCoins(Dictionary<decimal, decimal> potentialCoins)
        {
            var acceptedCoins = new List<Coin>();
            foreach (var item in potentialCoins)
            {
                var coin = _coinConverter.MeasureCoin(item.Key, item.Value);
                acceptedCoins.Add(coin);
            }

            return acceptedCoins;
        }

        public List<Coin> MakeChange(decimal costPrice, List<Coin> tender)
        {
            var remainingCoins = new List<Coin>();
            if (costPrice >= tender.Sum(a => a.Value))
            {
                var difference = costPrice - tender.Sum(a => a.Value);

                remainingCoins = _coinConverter.CalculateChange(_coinConverter.AvailableTender, difference);
            }
            return remainingCoins;
        }

        public void ReturnCoins(List<Coin> coins)
        {
            //send back to 'machine'
        }
    }
}
