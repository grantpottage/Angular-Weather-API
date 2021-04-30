using AngularWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Interfaces
{
    public interface IApiService
    {
        Task<WeatherResponse> GetWeatherForCityAsync(string cityName);
    }
}
