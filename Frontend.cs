using System;
using System.Collections.Generic;
using StockMarket.StockType;
using StockMarket.BuyerType;


namespace StockMarket.FrontEnd;

// Middleware, This will connect the Frontend and Backend.. when I write the backend
class StockGame {

    public Buyer player;
    private List<Stock> stocksAvailable;

    public StockGame(string username) {

        player = new Buyer(username);
        stocksAvailable = new List<Stock>() {

            new Stock("Apple", "AAPL"),
            new Stock("Microsoft", "MSFT"),
            new Stock("Google", "GOOGL"),
            new Stock("Amazon", "AMZN"),
            new Stock("Meta", "META"),
            new Stock("Tesla", "TSLA"),

        };

    }

    private void UpdateStocks() {

        // Update the stocks
        foreach (Stock stock in stocksAvailable) {

            Random rng = new Random();
            double amount = rng.NextDouble() * (0.20 + 20.5) + 0.20;
            amount = (double) decimal.Round((decimal)amount, 2);
            if (rng.Next(1, 3) == 1) {

                stock.upPrice(amount);

            } else {

                stock.lowerPrice(amount);

            }

        }

    }


    public void SellStock(string stockName) {

        // First get the stock
        Stock stock = FindStock(stockName);

        // Then sell it
        player.SellStock(stock.getStockName());
        Console.WriteLine("Sold stock: " + stock.getStockName() + " for: " + stock.getPrice());
        Console.WriteLine($"You now have {player.money} now");

    }

    // Helper method to find a stock
    public Stock FindStock(string stockName) {

        // index the list to find `stock`
        foreach (Stock stock in stocksAvailable) {

            if (stock.getStockName() == stockName) {

                return stock;

            }

        }
        return null;

    }

    public void PrintStocksToBuy() {

        // Print all the stocks
        foreach (Stock stock in stocksAvailable) {

            Console.Write($"Stock: {stock.getStockName()} Price: ");
            if (stock.getPrice() > 0.00) {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"${stock.getPrice()}");
                Console.ResetColor();

            } else {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"${stock.getPrice()}");
                Console.ResetColor();

            }

        }
        PickStockToBuy();

    }

    private void PickStockToBuy() {

        // Ask the player to pick a stock
        Console.Write("Pick a stock to buy: ");
        string stockName = Console.ReadLine();
        // Get Stock from list
        Stock stock = FindStock(stockName);

        // Buy the stock
        player.BuyStock(stock);

    }

    public static void Prompt(StockGame game) {

        Console.WriteLine("Here are the commands: LISTOWNED, BUY, SELL, QUIT (Will not save your data!)");
        Console.Write("What would you like to do: ");
        string command = Console.ReadLine();
        switch (command) {

            case "LISTOWNED":
            case "listowned":
                game.player.getOwnedStocks();
                break;
            case "BUY":
            case "buy":
                game.PrintStocksToBuy();
                break;
            case "SELL":
            case "sell":
                game.player.getOwnedStocks();
                Console.Write("What stock would you like to sell: ");
                string stockName = Console.ReadLine();
                game.SellStock(stockName);
                break;
            case "QUIT":
            case "quit":
                Console.WriteLine("Goodbye! (YOUR DATA WILL NOT BE SAVED!!!!)\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
                break;
        }

        game.UpdateStocks();


    }


}

class MainProgram {

    public static void Main() {

        Console.WriteLine("Welcome to STOCK BUYER SIMULATOR!");
        Console.Write("Let's Get you setup, first your username: ");
        string username = Console.ReadLine();
        StockGame game = new StockGame(username);

        Console.WriteLine("Welcome " + username + "!");
        Console.WriteLine("You have $" + game.player.money + " to spend, let's go!");
        while (true) {

            StockGame.Prompt(game);

        }


    }

}