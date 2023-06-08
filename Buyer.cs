using System;
using System.Collections.Generic;
using StockMarket.StockType;

namespace StockMarket.BuyerType;


// The 'player'
class Buyer {

    public string username;
    public double money;
    private List<Stock> ownedStocks;

    public Buyer(string username) {

        this.username = username;
        ownedStocks = new List<Stock>();
        this.money = 100.00;

    }

    public void BuyStock(Stock stock) {

        // Check to see if the player has enough money to buy the stock
        if (stock.getPrice() > this.money) {

            Console.WriteLine("You don't have enough money to buy this stock!");

        } else if (stock.getPrice() < this.money) {

            this.money -= stock.getPrice();
            ownedStocks.Add(stock);
            Console.WriteLine($"Stock bought: {stock.getStockName()} for {stock.getPrice()} was purchased, you now have {this.money - stock.getPrice()}$ remaining");

        }

    }

    public Stock FindStock(string s) {

        // index the list to find `stock`
        foreach (Stock stock in ownedStocks) {

            if (stock.getStockName() == s) {

                return stock;

            }

        }
        return null;

    }

    public void SellStock(string stockName) {

        // First get the stock
        Stock stock = FindStock(stockName);

        // Add the stock's current worth to the player's money
        this.money += stock.getPrice();

        // Remove the stock from the player's ownedStocks list
        ownedStocks.Remove(stock);


    }


    // Mainly a UI Method
    public void getOwnedStocks() {

        foreach(Stock stock in ownedStocks) {

            Console.Write($"Stock: {stock.getStockName()} Price: ");
            if (stock.getPrice() < 0) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"${stock.getPrice()}");
                Console.ResetColor();

            } else {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"${stock.getPrice()}");
                Console.ResetColor();

            }

        }

    }


}