using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestSMHI.Model;

namespace TestSMHI.Services
{
    public class ForecastService
    {
        private static HttpClient client = new HttpClient();

        private static async Task<ForeCast> GetProductAsync(string path)
        {
            ForeCast product = null;
            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ForeCast>(content);
            }
            return product;
        }

        public static async Task<ForeCast> ForecastRunAsync()
        {

            client.BaseAddress = new Uri("https://opendata-download-metfcst.smhi.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Get the product
                ForeCast product = await GetProductAsync("/api/category/pmp3g/version/2/geotype/point/lon/16/lat/58/data.json").ConfigureAwait(false);
                return product;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            return null;
        }


    }
}
