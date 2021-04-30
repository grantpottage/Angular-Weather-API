using AngularWeatherAPI.Interfaces;
using AngularWeatherAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApiService _apiService;

        public WeatherForecastController(IApiService apiService,
            UserManager<ApplicationUser> userManager)
        {
            _apiService = apiService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<WeatherViewModel> Get(string cityName = "Belfast")
        {
            var weather = await _apiService.GetWeatherForCityAsync(cityName);

            var weatherViewModel = new WeatherViewModel(weather)
            {
                CityName = cityName,
            };

            return weatherViewModel;
        }
    }
}
