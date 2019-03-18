using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            List<(string ticker, double shares, double price)> purchases = new List<(string, double, double)>();
            Dictionary<string, double> aggregatedPurchases = new Dictionary<string, double>();
            double updatedValuation = 0;

            stocks.Add("CBRL", "Cracker Barrel");
            stocks.Add("HD", "Home Depot");
            stocks.Add("UA", "Under Armour");
            stocks.Add("GOOGL", "Google");
            stocks.Add("NFLX", "Netflix");

            purchases.Add((ticker: "CBRL", shares: 225, price: 156.49));
            purchases.Add((ticker: "CBRL", shares: 45, price: 157.36));
            purchases.Add((ticker: "CBRL", shares: 110, price: 156.45));
            purchases.Add((ticker: "HD", shares: 75, price: 183.42));
            purchases.Add((ticker: "HD", shares: 256, price: 183.79));
            purchases.Add((ticker: "HD", shares: 189, price: 187.45));
            purchases.Add((ticker: "GOOGL", shares: 95, price: 1188.55));
            purchases.Add((ticker: "GOOGL", shares: 22, price: 1189.23));
            purchases.Add((ticker: "GOOGL", shares: 73, price: 1190.04));
            purchases.Add((ticker: "NFLX", shares: 10, price: 363.44));
            purchases.Add((ticker: "NFLX", shares: 45, price: 363.79));
            purchases.Add((ticker: "NFLX", shares: 79, price: 364.23));
            purchases.Add((ticker: "UA", shares: 43, price: 19.85));
            purchases.Add((ticker: "UA", shares: 35, price: 20.15));
            purchases.Add((ticker: "UA", shares: 45, price: 19.06));

            var ownershipReport =
                stocks.Join(purchases, (stock => stock.Key), (purchase => purchase.ticker),
                            ((stock, purchase) => new { Name = stock.Value, Valuation = (purchase.shares * purchase.price) }));

            foreach (var stock in ownershipReport)
            {
                if (aggregatedPurchases.ContainsKey(stock.Name))
                {
                    aggregatedPurchases[stock.Name] = aggregatedPurchases[stock.Name] + (stock.Valuation);
                }
                else
                {
                    aggregatedPurchases.Add(stock.Name, stock.Valuation);
                }
            }

            foreach (var stock in aggregatedPurchases)
            {
                Console.WriteLine($"You own ${stock.Value} of {stock.Key}.");
            }

            Console.ReadKey();
        }
    }
}