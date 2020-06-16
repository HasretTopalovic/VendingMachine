using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Enums;
using VendingMachine.Objects;

namespace VendingMachine.Presets
{
    public class CoinConfig
    {
        public static Coin GetDime()
        {
            return new Coin(2.268M, 1.35M, 10, CoinType.Dime, true);
        }

        public static Coin GetPenny()
        {
            return new Coin(2.5M, 1.32M, 1, CoinType.Penny, true);
        }

        public static Coin GetNickel()
        {
            return new Coin(5M, 1.95M, 5, CoinType.Nickel, true);
        }

        public static Coin GetQuarter()
        {
            return new Coin(5.67M, 1.75M, 25, CoinType.Quarter, true);
        }
    }
}
