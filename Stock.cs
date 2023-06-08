using System;
using System.Collections.Generic;

namespace StockMarket.StockType;

// Stock Data Type
class Stock {

    private string companyName;
    private string stockName;
    private double price;

    public Stock(string name, string stockN) {

        this.companyName = name;
        this.stockName = stockN;

        Random rng = new Random();
        this.price = rng.NextDouble() * (0.20 + 20.5) + 0.20;
        this.price = (double) decimal.Round((decimal)this.price, 2);
        this.price = Math.Round(this.price, 2);

    }

    public void upPrice(double amountUp) {

        this.price += amountUp;

    }

    public void lowerPrice(double amountDown) {

        this.price -= amountDown;

    }

    public string getStockName() {

        return stockName;

    }

    public double getPrice() {

        return price;

    }
    

}