﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Converters;
using VendingMachine.Handlers;
using VendingMachine.Managers;
using VendingMachine.Objects;
using VendingMachine.Presets;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineManagerTests
    {
        [Test]
        public void Purchase()
        {
            var acceptedCoins = new List<Coin>()
            {
                CoinConfig.GetDime(),
                CoinConfig.GetNickel(),
                CoinConfig.GetQuarter()
            };

            var productsToStock = new List<Product>() {
                ProductConfig.GetCandy(),
                ProductConfig.GetChips(),
                ProductConfig.GetCola()
            };

            var change = new List<Coin>();
            change.AddRange(BulkAddChange(10, CoinConfig.GetQuarter()));
            change.AddRange(BulkAddChange(10, CoinConfig.GetNickel()));

            var vendineMachine = SetUpMachine(acceptedCoins, productsToStock, change);
        }

        private VendingMachineManager SetUpMachine(List<Coin> acceptedCoins, List<Product> productsToStock, List<Coin> changeInMachine)
        {
            var cc = new CoinConverter(acceptedCoins);
            var ch = new CoinHandler(cc);
            var ph = new ProductHandler();
            var vm = new VendingMachineManager(ch, ph);

            vm.StockProductsInMachine(productsToStock);
            vm.StockChangeInMachine(changeInMachine);

            return vm;
        }

        private List<Coin> BulkAddChange(int loopNumber, Coin coin)
        {
            var result = new List<Coin>();
            for (int ii = 0; ii < loopNumber; ii++)
            {
                result.Add(coin);
            }

            return result;
        }
    }
}
