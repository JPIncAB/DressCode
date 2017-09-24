using Android.App;
using Android.Widget;
using Android.OS;
using TestSMHI.Services;
using System.Threading.Tasks;
using TestSMHI.Model;
using TestSMHI;
using System.Linq;
using System;

namespace DressCodeAnroidClient
{
    [Activity(Label = "DressCode", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //GridViewPresentation();
            TableLayout tableLaout = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            GetForecast().Wait();
        }



        private async Task GetForecast()
        {
            ForeCast foreCast = await ForecastService.ForecastRunAsync().ConfigureAwait(false);
            var WeatherText = new WeatherText(foreCast);
            ShowProduct(foreCast);
        }

      /*  public  void GridViewPresentation()
        {
            GridLayout layout = FindViewById<GridLayout>(Resource.Id.gridLayout1);

            //Img
            ImageView imgView = new ImageView(this);
            GridLayout.LayoutParams param = new GridLayout.LayoutParams();
            param.Height = GridLayout.LayoutParams.WrapContent;
            param.Width = GridLayout.LayoutParams.WrapContent;
            param.SetMargins(5, 5, 5, 5);
            param.SetGravity(Android.Views.GravityFlags.Center);

            //param.ColumnSpec = GridLayout.Spec;
            //param.rowSpec = GridLayout.spec(r);;
            imgView.LayoutParameters = param;
            layout.AddView(imgView);

            //Time
            TextView timeTextView = new TextView(this);
            timeTextView.Text = "Test";
            GridLayout.LayoutParams param1 = new GridLayout.LayoutParams();
            param1.Height = GridLayout.LayoutParams.WrapContent;
            param1.Width = GridLayout.LayoutParams.WrapContent;
            param1.SetMargins(5, 5, 5, 5);
            param1.SetGravity(Android.Views.GravityFlags.Center);

            timeTextView.LayoutParameters = param1;
            layout.AddView(timeTextView);

            //Temp


            //Wind


            //precipitation 


            //Text
        }*/

        private void ShowProduct(ForeCast product)
        {

            //label1.Text = ($"Approved Time: {product.approvedTime}");
            //label2.Text = ($"Reference Time: {product.referenceTime}");
            //label3.Text = ($"Long: {product.geometry.coordinates[0][0]}");
            //label4.Text = ($"Lat: {product.geometry.coordinates[0][1]}");

            TableLayout tableLayout = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            foreach (var timeSerie in product.timeSeries)
            {
                DateTime parsedTime = Convert.ToDateTime(timeSerie.validTime);
                TimeSpan start = TimeSpan.Parse("12:00");
                if (parsedTime.TimeOfDay == start)
                {
                    TableRow tableRow = new TableRow(this);

                    var culture = new System.Globalization.CultureInfo("sv-SE");
                    var day = culture.DateTimeFormat.GetDayName(parsedTime.DayOfWeek).ToUpperInvariant();  // 23 Sat Saturday
                    AddTextView($"{day}", TextView.BufferType.Normal, tableRow);
                    //AddTextView($"Count: {timeSerie.parameters.Count}", TextView.BufferType.Normal, tableRow);

                    ForecastParameters parameters = new ForecastParameters(timeSerie);
                    var AirTemperature = timeSerie.parameters.FirstOrDefault(x => x.name == "t").values[0];
                    TextView AirTemperatureTv = new TextView(this);
                    AddTextView($"{parameters.AirTemperature} C°", TextView.BufferType.Normal, tableRow);
                    AddTextView($"{WeatherSymbol.WeatherSymbolDictionary[parameters.WeatherSymbol]}", TextView.BufferType.Normal, tableRow);
                    AddTextView($"{parameters.MinimumPrecipitationIntensity} - {parameters.MaximumPrecipitationIntensity} mm", TextView.BufferType.Normal, tableRow);
                    //AddTextView($"{parameters.WindDirection}", TextView.BufferType.Normal, tableRow);
                    AddTextView($"{parameters.WindSpeed} m/s", TextView.BufferType.Normal, tableRow);

                    AddTextView($"{parameters.WindGustSpeed}", TextView.BufferType.Normal, tableRow);

                    //AddTextView($"{ PrecipitationCategory.PrecipitationCategoryDictionary[parameters.PrecipitationCategory]}", TextView.BufferType.Normal, tableRow);


                    //label4.Text = ($"AirPressure: {parameters.AirPressure}");
                    // Console.WriteLine($"PrecipitationCategory: {PrecipitationCategory.PrecipitationCategoryDictionary[parameters.PrecipitationCategory]}");
                    //Console.WriteLine($"HorizontalVisibility: {parameters.HorizontalVisibility}");
                    //Console.WriteLine($"MeanValueOfHighLevelCloudCover: {parameters.MeanValueOfHighLevelCloudCover}");
                    //Console.WriteLine($"MeanValueOfLowLevelCloudCover: {parameters.MeanValueOfLowLevelCloudCover}");
                    //Console.WriteLine($"PercentOfPrecipitationInFrozenForm: {parameters.PercentOfPrecipitationInFrozenForm}");
                    //label1.Text = ($"RelativeHumidity: {parameters.RelativeHumidity}");
                    //Console.WriteLine($"ThunderProbability: {parameters.ThunderProbability}");


                    tableLayout.AddView(tableRow);
                }

            }
        }

        private void AddTextView(string text, TextView.BufferType bufferType, TableRow tr)
        {
            TextView textView = new TextView(this);
            textView.SetPadding(5, 5, 5, 5);
            textView.SetText(text, bufferType);
            tr.AddView(textView);
        }

    }
}

