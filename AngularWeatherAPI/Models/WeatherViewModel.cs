using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Models
{
    public class WeatherViewModel
    {
        public WeatherViewModel(WeatherResponse weather)
        {
            Weather = weather;

            //If weather object is empty, city doesnt exist.
            if(this.Weather == null)
            {
                ErrorMessage = "No city found.";
                this.Weather = new WeatherResponse();
            }
        }

        public string CityName { get; set; }
        public string LastRefresh
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }
        public WeatherResponse Weather { get; set; }
        public string ErrorMessage { get; set; }
    }
}
