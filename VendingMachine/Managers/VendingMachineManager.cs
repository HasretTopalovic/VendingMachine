using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Interfaces;
using VendingMachine.Objects;

namespace VendingMachine.Managers
{
    public class VendingMachineManager : IVendingMachineManager
    {
        private ICoinHandler _coinHandler;
        private IProductHandler _productHandler;

        public List<Product> Products { get; private set; }
        public List<Coin> Tender { get; set; }
        public int ButtonCounter { get; set; } = 0;
        public List<Coin> ChangeInMachine { get; private set; }

        public VendingMachineManager(ICoinHandler coinHandler, IProductHandler productHandler)
        {
            _coinHandler = coinHandler;
            _productHandler = productHandler;
        }
        public void StockMachine(List<Product> products)
        {
            Products = products;
        }

        public void AcceptCurrency(Dictionary<decimal, decimal> coins)
        {
            var filteredCoins = _coinHandler.AcceptCoins(coins);
            Tender = filteredCoins.Where(a => a.IsValid == true).ToList();

            var money = filteredCoins.Where(a => a.IsValid == true).ToList();
            _coinHandler.ReturnCoins(money);
            
        }

        public string MakeSelection(Product product)
        {
            string response = "";
            //Would ideally be something nicer than name comparison. Id etc
            var vendingProduct = Products.First(a => a.Name == product.Name);
            if (vendingProduct.Stock > 1)
            {
                if (Tender.Sum(a => a.Value) >= product.Price)
                {
                    //this name search is being done twice and is horrible. would change
                    //along with removing stock from product etc
                    _productHandler.SelectProduct(Products.First(a => a.Name == product.Name));
                    var change = _coinHandler.MakeChange(product.Price, Tender);
                    response = "THANK YOU";

                    var amountCharged = RemoveCoins(change, Tender);
                    ChangeInMachine.AddRange(amountCharged);
                    _coinHandler.ReturnCoins(change);
                    Tender = new List<Coin>();
                }
                else
                {
                    response = product.Price.ToString();
                }
            }
            else
            {
                if (ButtonCounter == 0)
                {
                    ButtonCounter += 1;
                    return "SOLD OUT";
                }
                else
                {
                    ButtonCounter = 0;
                    var remaining = Tender.Sum(a => a.Value);
                    if (remaining > 0)
                    {
                        return remaining.ToString();
                    }
                    else
                    {
                        return "INSERT COIN";
                    }
                }
                
            }
            

            return response;
        }

        private List<Coin> RemoveCoins(List<Coin> money, List<Coin> list)
        {
            foreach (var item in money)
            {
                list.Remove(item);
            }

            return list;
        }

    }
}
