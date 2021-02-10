using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            string path = "/gridpoints/TOP/33,36/forecast";
            var task = Task.Run(() => GetWeatherInfoAsync(path));
            task.Wait();
            var weatherResponse = task.Result;
            var property = weatherResponse.Properties.Periods.Where(x => x.Number == 3).SingleOrDefault();
            return View(property);
        }

        private async Task<WeatherResponse> GetWeatherInfoAsync(string path)
        {
            var weatherResponse = new WeatherResponse();
            var constants = new Constants();
            string baseUrl = constants.GetApiUrl();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "WeatherApp");
                    var response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return weatherResponse;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
