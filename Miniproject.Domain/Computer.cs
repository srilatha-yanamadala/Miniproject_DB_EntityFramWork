
using System;

using System.Collections.Generic;

using System.Linq;

namespace project.Domain
{
    public class Computer : Asset

    {
       
        public Computer(string brand, string model, DateTime purchaseDate, Office office, double purchasePrice, string currency, double exchangeRate)

        {

            Brand = brand;

            Model = model;

            PurchaseDate = purchaseDate;

            Office = office;

            PurchasePrice = purchasePrice;

            Currency = currency;

            ExchangeRate = exchangeRate;

        }


    }

}
