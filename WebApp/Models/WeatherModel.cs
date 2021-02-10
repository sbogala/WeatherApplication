using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class WeatherResponse
    {
        [JsonProperty("@context")]
        public IList<object> Context { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public object Geometry { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("forecastGenerator")]
        public string ForecastGenerator { get; set; }

        [JsonProperty("generatedAt")]
        public string GeneratedAt { get; set; }

        [JsonProperty("upstring")]
        public string Upstring { get; set; }

        [JsonProperty("validTimes")]
        public string ValidTimes { get; set; }

        [JsonProperty("elevation")]
        public object Elevation { get; set; }

        [JsonProperty("periods")]
        public IList<Period> Periods { get; set; }
    }

    public class Period
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("isDayTime")]
        public bool IsDayTime { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("temperatureUnit")]
        public string TemperatureUnit { get; set; }

        [JsonProperty("temperatureTrend")]
        public string TemperatureTrend { get; set; }

        [JsonProperty("windSpeed")]
        public string WindSpeed { get; set; }

        [JsonProperty("windDirection")]
        public string WindDirection { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("shortForecast")]
        public string ShortForecast { get; set; }

        [JsonProperty("detailedForecast")]
        public string DetailedForecast { get; set; }
    }
}
