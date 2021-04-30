using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Models
{
    [DataContract]
    public class WeatherResponse
    {
        [DataMember(Name = "consolidated_weather")]
        public IEnumerable<ConsolidatedWeather> ConsolidatedWeather { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "sun_rise")]
        public DateTime SunRise { get; set; }

        [DataMember(Name = "sun_set")]
        public DateTime SunSet { get; set; }

        [DataMember(Name = "timezone_name")]
        public string TimezoneName { get; set; }

        [DataMember(Name = "parent")]
        public Parent Parent { get; set; }

        [DataMember(Name = "sources")]
        public IEnumerable<Source> Sources { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }

        [DataMember(Name = "woeid")]
        public int WoeId { get; set; }

        [DataMember(Name = "latt_long")]
        public string LatitudeAndLongitude { get; set; }

        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }

    }

    [DataContract]
    public class Parent
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }

        [DataMember(Name = "woeid")]
        public int WoeId { get; set; }

        [DataMember(Name = "latt_long")]
        public string LatitudeAndLongitude { get; set; }
    }

    [DataContract]
    public class ConsolidatedWeather
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "weather_state_name")]
        public string WeatherStateName { get; set; }

        [DataMember(Name = "weather_state_abbr")]
        public string WeatherStateAbbreviation { get; set; }

        [DataMember(Name = "wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [DataMember(Name = "min_temp")]
        public decimal MinTemperatureExact { get; set; }

        [DataMember(Name = "max_temp")]
        public decimal MaxTemperatureExact { get; set; }

        [DataMember(Name = "the_temp")]
        public decimal TheTemperatureExact { get; set; }

        [DataMember(Name = "wind_speed")]
        public decimal WindSpeed { get; set; }

        [DataMember(Name = "wind_direction")]
        public decimal WindDirection { get; set; }

        [DataMember(Name = "air_pressure")]
        public decimal AirPressure { get; set; }

        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }

        [DataMember(Name = "visibility")]
        public decimal Visibility { get; set; }

        [DataMember(Name = "predictability")]
        public int Predictability { get; set; }

        public string WeatherStateImageURL
        {
            get
            {
                return $"https://www.metaweather.com/static/img/weather/{this.WeatherStateAbbreviation}.svg";
            }
        }

        public decimal MaxTemperature
        {
            get
            {
                return decimal.Round(this.MaxTemperatureExact);
            }
        }

        public decimal MinTemperature
        {
            get
            {
                return decimal.Round(this.MinTemperatureExact);
            }
        }

        public decimal CurrentTemperature
        {
            get
            {
                return decimal.Round(this.TheTemperatureExact);
            }
        }

        public string Date
        {
            get
            {
                if(this.ApplicableDate.Day == DateTime.Now.Day)
                {
                    return "Today";
                }

                return this.ApplicableDate.ToString("dddd, dd MMMM");
            }
        }
    }

    [DataContract]
    public class Source
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "crawl_rate")]
        public int CrawlRate { get; set; }
    }


}
