using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using TestSMHI.Services;
using TestSMHI.Model;

namespace TestSMHI
{
    class Program
    {

        static void Main(string[] args)
        {
           //  ForecastService.ForecastRunAsync().Wait();
            Test().Wait();
        }

        private static async Task Test()
        {
            ForeCast foreCast = await ForecastService.ForecastRunAsync();
            ShowProduct(foreCast);
            Console.ReadLine();
        }


        private static void ShowAllParameters(ForeCast product)
        {
            foreach (var timeSerie in product.timeSeries)
            {
               
                Console.WriteLine();
                Console.WriteLine();
               

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"validTime: {timeSerie.validTime}");
                Console.WriteLine($"validTime: {timeSerie.parameters.Count}");
                Console.ForegroundColor = ConsoleColor.White;

                ForecastParameters parameters = new ForecastParameters(timeSerie);
                var AirTemperature = timeSerie.parameters.FirstOrDefault(x => x.name == "t").values[0];
                Console.WriteLine($"AirTemperature: {parameters.AirTemperature}");
                Console.WriteLine($"AirPressure: {parameters.AirPressure}");
               // Console.WriteLine($"PrecipitationCategory: {PrecipitationCategory.PrecipitationCategoryDictionary[parameters.PrecipitationCategory]}");
                //Console.WriteLine($"HorizontalVisibility: {parameters.HorizontalVisibility}");
                //Console.WriteLine($"MeanValueOfHighLevelCloudCover: {parameters.MeanValueOfHighLevelCloudCover}");
                //Console.WriteLine($"MeanValueOfLowLevelCloudCover: {parameters.MeanValueOfLowLevelCloudCover}");
                Console.WriteLine($"PercentOfPrecipitationInFrozenForm: {parameters.PercentOfPrecipitationInFrozenForm}");
                Console.WriteLine($"RelativeHumidity: {parameters.RelativeHumidity}");
                Console.WriteLine($"ThunderProbability: {parameters.ThunderProbability}");
                Console.WriteLine($"WindDirection: {parameters.WindDirection}");
                Console.WriteLine($"WindSpeed: {parameters.WindSpeed}");
                Console.WriteLine($"WindGustSpeed: {parameters.WindGustSpeed}");
                Console.WriteLine($"WeatherSymbol: {WeatherSymbol.WeatherSymbolDictionary[parameters.WeatherSymbol]}");





                //foreach (var p in timeSerie.parameters)
                //{
                //    Console.WriteLine($"name: {p.name}");
                //    //Console.WriteLine($"level: {p.level}");
                //    //Console.WriteLine($"leveltype: {p.levelType}");
                //    //foreach (var v in p.values)
                //    //{
                //    //    Console.WriteLine($"values: {v.ToString()}");
                //    //}
                //}
            }
        }

        private static void TestInfo(ForeCast product)
        {
            foreach (var timeSerie in product.timeSeries)
            {
                Console.WriteLine($"validTime: {timeSerie.validTime}");
                Console.WriteLine($"validTime: {timeSerie.parameters.Count}");


                //foreach (var p in timeSerie.parameters)
                //{

                //    Console.WriteLine($"name: {p.name}");
                //    Console.WriteLine($"level: {p.level}");
                //    Console.WriteLine($"leveltype: {p.levelType}");
                //    foreach (var v in p.values)
                //    {
                //        Console.WriteLine($"values: {v.ToString()}");
                //    }
                //}
            }
        }

        private static void ShowProduct(ForeCast product)
        {
            Console.WriteLine($"Approved Time: {product.approvedTime}");
            Console.WriteLine($"Reference Time: {product.referenceTime}");
            Console.WriteLine($"Long: {product.geometry.coordinates[0][0]}");
            Console.WriteLine($"Lat: {product.geometry.coordinates[0][1]}");
            ShowAllParameters(product);
        }

    }
}
