using Miniproject.Data;
using System.Collections.Generic;
using System.Linq;
using project.Domain;
using System;

namespace ConsoleApp_Miniproject
{
    internal class Program
    {
        private static projContext context = new projContext();
        static void Main(string[] args)
        {  
            {

                //No input from Console in this solution 

                List<Asset> assets = PrepareAssets();

                List<ExchangeRate> exchangeRates = PrepareExchangeRates();

                assets = SortAssets(assets);

                PrintHeader();

                PrintData(assets, exchangeRates);



                Console.ReadLine();

            }



            /// <summary> 

            /// Creates a simulated list of inputs from user. 

            /// </summary> 

            /// <returns>List of Assets</returns> 

            static List<Asset> PrepareAssets()

            {

                return new List<Asset>()

                {

                new Phone("iPhone", "X", GetDate("2018-07-15"),new Office("Sweden"), 12450, "SEK",8.45),

                new Computer("Asus", "W234", GetDate("2017-04-21"),new Office("USA"), 1200, "USD",1.00),

                new Phone("iPhone", "11", GetDate("2020-09-25"),new Office("Spain"), 990, "EUR",10.12),

                new Computer("Lenovo", "Yoga 530", GetDate("2019-04-21"),new Office("USA"), 1530, "USD",1.00),

                new Phone("iPhone", "8", GetDate("2018-03-16"),new Office("Spain"), 970, "EUR",10.12),

                new Computer("Lenovo", "Yoga 730", GetDate("2018-05-28"),new Office("USA"), 1835, "USD",1.00),

                new Phone("Motorola", "Razr", GetDate("2020-03-16"),new Office("Sweden"), 9700, "SEK",8.45),

                new Computer("HP", "Elitebook", GetDate("2020-10-02"),new Office("Sweden"), 1588, "SEK",8.45)

                };

            }



            /// <summary> 

            /// Creates a simulated list of exchange rates. 

            /// </summary> 

            /// <returns>List of Exchange rates</returns> 

            static List<ExchangeRate> PrepareExchangeRates()

            {

                return new List<ExchangeRate>()

                {

                new ExchangeRate("USD",1.00),

                new ExchangeRate("SEK", 0.12),

                new ExchangeRate("EUR", 1.21)

                };

            }



            /// <summary> 

            /// Sorts the Asset list by asset type and purchase date. 

            /// </summary> 

            /// <param name="assets"></param> 

            /// <returns>List of sorted Assets</returns> 

            static List<Asset> SortAssets(List<Asset> assets)

            {

                assets = assets.OrderBy(asset => asset.GetType().ToString()).ThenBy(asset => asset.PurchaseDate).ToList();

                return assets;

            }



            /// <summary> 

            /// Prints the Header columns to Console. 

            /// </summary> 

            static void PrintHeader()

            {

                Console.WriteLine(Tab("Brand") + Tab("Model") + Tab("Office") + Tab("Purchase Date") +

                    Tab("Price") +Tab("Currency") + Tab("In USD today"));

                Console.WriteLine( Tab("-----") + Tab("-----") + Tab("------") +

                    Tab("-------------") +

                    Tab("-----") +

                    Tab("---------") +

                    Tab("------------")

                    );

            }



            /// <summary> 

            /// Prints data. 

            /// </summary> 

            /// <param name="assets"></param> 

            /// <param name="exchangeRates"></param> 

            static void PrintData(List<Asset> assets, List<ExchangeRate> exchangeRates)

            {

                assets.ForEach(asset => PreparePrintDataLine(asset, exchangeRates));

            }



            /// <summary> 

            /// Converts date from string to DateTime 

            /// </summary> 

            /// <param name="date"></param> 

            /// <returns>DateTime</returns> 

            static DateTime GetDate(string date)

            {

                return DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            }



            /// <summary> 

            /// Prepares data to be printed. 

            /// </summary> 

            /// <param name="asset"></param> 

            /// <param name="exchangeRates"></param> 

            static void PreparePrintDataLine(Asset asset, List<ExchangeRate> exchangeRates)

            {

                int daysWarning = 913; //Approx 30 months 

                int daysAlarm = 1004;  //Approx 33 months 

                TimeSpan diff = DateTime.Now - asset.PurchaseDate;

                DecideForegroundColor(daysWarning, daysAlarm, diff);



                double usdRateToday = exchangeRates.Where(exchangeRate => exchangeRate.Currency == asset.Currency).Select(ex => ex.Rate).FirstOrDefault();

                PrintDataLine(asset, usdRateToday);



                Console.ForegroundColor = ConsoleColor.White;

            }



            /// <summary> 

            /// Decides what Console Foreground Color to be used  

            /// depending on how old assets are. 

            /// </summary> 

            /// <param name="daysWarning"></param> 

            /// <param name="daysAlarm"></param> 

            /// <param name="diff"></param> 

            static void DecideForegroundColor(int daysWarning, int daysAlarm, TimeSpan diff)

            {

                if (diff.Days > daysAlarm)

                {

                    Console.ForegroundColor = ConsoleColor.Red;

                }

                else if (diff.Days > daysWarning)

                {

                    Console.ForegroundColor = ConsoleColor.Yellow;

                }

                else

                {

                    Console.ForegroundColor = ConsoleColor.White;

                }

            }



            /// <summary> 

            /// Prints data for one asset to Console. 

            /// </summary> 

            /// <param name="asset"></param> 

            /// <param name="usdRateToday"></param> 

            static void PrintDataLine(Asset asset, double usdRateToday)

            {

                Console.WriteLine(

                                Tab(asset.Brand) +

                                Tab(asset.Model) +

                                Tab(asset.Office.Name) +

                                Tab(asset.PurchaseDate.ToShortDateString()) +

                                Tab(asset.PurchasePrice.ToString("0.##")) +

                                Tab(asset.Currency) +

                                Tab((asset.PurchasePrice * usdRateToday).ToString("0.##"))

                                );

            }



            /// <summary> 

            /// PadRight with 14 characters on a string.  

            /// </summary> 

            /// <param name="input"></param> 

            /// <returns></returns> 

            static string Tab(string input)

            {

                return input.PadRight(14);

            }

        }
       
    }
}

 
  