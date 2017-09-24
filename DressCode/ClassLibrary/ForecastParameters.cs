using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSMHI.Model;

namespace TestSMHI
{
    public class ForecastParameters
    {
        public ForecastParameters(TimeSery timeSery)
        {
            //msl hPa hmsl	0	Air pressure    public decimal number, one decimal
            AirPressure = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "msl").values[0];

            //t C hl	2	Air temperature public decimal number, one decimal
            AirTemperature = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "t").values[0];

            //vis km hl	2	Horizontal visibility   public decimal number, one decimal
            HorizontalVisibility = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "vis").values[0];

            //wd  degree hl	10	Wind direction  Integer
            WindDirection = (int)timeSery.parameters.FirstOrDefault(x => x.name == "wd").values[0];

            //        ws  m/s hl	10	Wind speed  public decimal number, one decimal
            WindSpeed = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "ws").values[0];

            //r	%	hl	2	Relative humidity   Integer, 0-100
            RelativeHumidity = (int)timeSery.parameters.FirstOrDefault(x => x.name == "r").values[0];

            //tstm	%	hl	0	Thunder probability Integer, 0-100
            ThunderProbability = (int)timeSery.parameters.FirstOrDefault(x => x.name == "tstm").values[0];

            //tcc_mean octas   hl	0	Mean value of total cloud cover Integer, 0-8
            MeanValueOfTotalCloudCover = (int)timeSery.parameters.FirstOrDefault(x => x.name == "tcc_mean").values[0];

            //lcc_mean octas   hl	0	Mean value of low level cloud cover Integer, 0-8
            MeanValueOfLowLevelCloudCover = (int)timeSery.parameters.FirstOrDefault(x => x.name == "lcc_mean").values[0];

            //mcc_mean octas   hl	0	Mean value of medium level cloud cover Integer, 0-8
            MeanValueOfMediumLevelCloudCover = (int)timeSery.parameters.FirstOrDefault(x => x.name == "mcc_mean").values[0];

            //hcc_mean octas   hl	0	Mean value of high level cloud cover Integer, 0-8
            MeanValueOfHighLevelCloudCover = (int)timeSery.parameters.FirstOrDefault(x => x.name == "hcc_mean").values[0];

            //gust m/s hl	10	Wind gust speed public decimal number, one decimal
            WindGustSpeed = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "gust").values[0];

            //pmin    mm/h hl	0	Minimum precipitation intensity public decimal number, one decimal
            MinimumPrecipitationIntensity = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "pmin").values[0];

            //pmax    mm/h hl	0	Maximum precipitation intensity public decimal number, one decimal
            MaximumPrecipitationIntensity = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "pmax").values[0];

            //spp	%	hl	0	Percent of precipitation in frozen form Integer, -9 or 0-100
            PercentOfPrecipitationInFrozenForm = (int)timeSery.parameters.FirstOrDefault(x => x.name == "spp").values[0];

            //pcat category    hl	0	Precipitation category  Integer, 0-6
            PrecipitationCategory = (int)timeSery.parameters.FirstOrDefault(x => x.name == "pcat").values[0];

            //pmean mm/h hl	0	Mean precipitation intensity public decimal number, one decimal
            MeanPrecipitationIntensity = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "pmean").values[0];

            //pmedian mm/h hl	0	Median precipitation intensity public decimal number, one decimal
            MedianPrecipitationIntensity = (decimal)timeSery.parameters.FirstOrDefault(x => x.name == "pmedian").values[0];

            //Wsymb2(or Wsymb)   code hl	0	Weather symbol  Integer, 1-27 (1-15 for pmp2g)
            WeatherSymbol = (int)timeSery.parameters.FirstOrDefault(x => x.name == "Wsymb2").values[0];

        }

        //Parameter Unit    Level Type  Level(m)   Description Value range

        ///msl hPa hmsl	0	Air pressure    public decimal number, one decimal
        public decimal AirPressure { get; set; }
        ///t C hl	2	Air temperature public decimal number, one decimal
        public decimal AirTemperature { get; set; }
        ///vis km hl	2	Horizontal visibility   public decimal number, one decimal
        public decimal HorizontalVisibility { get; set; }
        //wd  degree hl	10	Wind direction  Integer
        public int WindDirection { get; set; }
        ///        ws  m/s hl	10	Wind speed  public decimal number, one decimal
        public decimal WindSpeed { get; set; }
        ///r	%	hl	2	Relative humidity   Integer, 0-100
        public int RelativeHumidity { get; set; }
        ///tstm	%	hl	0	Thunder probability Integer, 0-100
        public int ThunderProbability { get; set; }
        ///tcc_mean octas   hl	0	Mean value of total cloud cover Integer, 0-8
        public int MeanValueOfTotalCloudCover { get; set; }
        ///lcc_mean octas   hl	0	Mean value of low level cloud cover Integer, 0-8
        public int MeanValueOfLowLevelCloudCover { get; set; }
        ///mcc_mean octas   hl	0	Mean value of medium level cloud cover Integer, 0-8
        public int MeanValueOfMediumLevelCloudCover { get; set; }
        ///hcc_mean octas   hl	0	Mean value of high level cloud cover Integer, 0-8
        public int MeanValueOfHighLevelCloudCover { get; set; }
        ///gust m/s hl	10	Wind gust speed public decimal number, one decimal
        public decimal WindGustSpeed { get; set; }
        ///pmin    mm/h hl	0	Minimum precipitation intensity public decimal number, one decimal
        public decimal MinimumPrecipitationIntensity { get; set; }
        ///pmax    mm/h hl	0	Maximum precipitation intensity public decimal number, one decimal
        public decimal MaximumPrecipitationIntensity { get; set; }
        ///spp	%	hl	0	Percent of precipitation in frozen form Integer, -9 or 0-100
        public int PercentOfPrecipitationInFrozenForm { get; set; }
        ///pcat category    hl	0	Precipitation category  Integer, 0-6
        public int PrecipitationCategory { get; set; }
        ///pmean mm/h hl	0	Mean precipitation intensity public decimal number, one decimal
        public decimal MeanPrecipitationIntensity { get; set; }
        ///pmedian mm/h hl	0	Median precipitation intensity public decimal number, one decimal
        public decimal MedianPrecipitationIntensity { get; set; }
        ///Wsymb2(or Wsymb)   code hl	0	Weather symbol  Integer, 1-27 (1-15 for pmp2g)
        public int WeatherSymbol { get; set; }

    }
}

