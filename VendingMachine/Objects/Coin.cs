using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Enums;

namespace VendingMachine.Objects
{
    public class Coin
    {
        public decimal Weight { get; private set; }
        public decimal Width { get; private set; }
        public decimal Value { get; private set; }
        public CoinType CoinType { get; private set; }
        public bool IsValid { get; private set; }

        public Coin(decimal weight, decimal width, decimal value, CoinType coinType, bool valid)
        {
            SetCoin(weight, width, value, coinType, valid);
        }

        private void SetCoin(decimal weight, decimal width, decimal value, CoinType coinType, bool valid)
        {
            this.Weight = weight;
            this.Width = width;
            this.Value = value;
            this.CoinType = coinType;
            this.IsValid = valid;
        }
    }
}
