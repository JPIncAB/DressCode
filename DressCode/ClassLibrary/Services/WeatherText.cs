using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSMHI;
using TestSMHI.Model;

namespace TestSMHI.Services
{
    public class WeatherText
    {
        ForeCast forecast;
        TestSMHI.ForecastParameters forecastparams;
        List<TimeSery> todaysWeather = new List<TimeSery>();
        List<TimeSery> tomorrowsWeather = new List<TimeSery>();

        TimeSpan morning;
        TimeSpan day;
        TimeSpan evening;
        public WeatherText(ForeCast forecast)
        {
            morning = TimeSpan.Parse("06:00");
            day = TimeSpan.Parse("12:00");
            evening = TimeSpan.Parse("18:00");

            todaysWeather = forecast.timeSeries.Where(ts => Convert.ToDateTime(ts.validTime).Date.Equals(DateTime.Today)).ToList();
            tomorrowsWeather = forecast.timeSeries.Where(ts => Convert.ToDateTime(ts.validTime).Date.Equals(DateTime.Today.AddDays(1))).ToList();


        }

        public void GetWeatherTextToday(ForeCast forecast)
        {

        }

        private void TemperatureText(List<TimeSery> series)
        {

            foreach (var ts in series)
            {
                DateTime parsedTime = Convert.ToDateTime(ts.validTime);
                var timeOfDay = parsedTime.TimeOfDay;
                if (timeOfDay == morning)
                {
                    ForecastParameters parameters = new ForecastParameters(ts);
                    var temp = parameters.AirTemperature; //C°", TextView.BufferType.Normal, tableRow);
                    var weatherSymbol = WeatherSymbol.WeatherSymbolDictionary[parameters.WeatherSymbol];
                    var minPrecipitation = parameters.MinimumPrecipitationIntensity;
                    var maxPrecipitation = parameters.MaximumPrecipitationIntensity;
                    var windDirection = parameters.WindDirection;
                    var windSpeed = parameters.WindSpeed;

                    var windGustSpeed = parameters.WindGustSpeed;
                }
                //else if (timeOfDay == day)
                //{
                //    ForecastParameters parameters = new ForecastParameters(timeSerie)
                //}
                //else if (timeOfDay == evening)
                //{
                //    ForecastParameters parameters = new ForecastParameters(timeSerie)
                //}
            }

        }
    }
}
