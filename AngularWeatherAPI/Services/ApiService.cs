using AngularWeatherAPI.Interfaces;
using AngularWeatherAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Services
{
    public class ApiService : IApiService
    {
        private readonly string LocationWoeIdURI = "https://www.metaweather.com/api/location/search/?query=";
        private readonly string WeatherForLocationURI = "https://www.metaweather.com/api/location/";

        private readonly IHttpClientFactory _clientFactory;

        private HttpClient client;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets the weather forecast for the provided city. Returns null if city does not exist
        /// </summary>
        /// <param name="cityName">Name of the city to get the weather forecast for</param>
        /// <returns>Returns a forecast of the weather in the specified city or null if the city does not exist</returns>
        public async Task<WeatherResponse> GetWeatherForCityAsync(string cityName)
        {
            client = _clientFactory.CreateClient();

            //Gets the Where on Earth ID of the searched city
            var locationResponse = await GetCitiesWoeIdAsync(cityName);
            if (locationResponse == null)
            {
                //If it returns null, the city doesn't exist
                return null;
            }

            //Gets the weather for the city using the Where on Earth Id
            var weatherResponse = await GetWeatherWithWoeIdAsync(locationResponse.WoeId);
            if (weatherResponse == null)
            {
                //Something must have gone wrong with the API call to get here as woeId should exist. (Could be the API service is down). Return generic error message
                return null;
            }

            client.Dispose();
            return weatherResponse;
        }

        /// <summary>
        /// Gets the weather for the city with the provided Where on Earth Id (woeId)
        /// </summary>
        /// <param name="woeId">Cities Specific Where on Earth ID</param>
        /// <returns>Weather forecast for the specified city</returns>
        private async Task<WeatherResponse> GetWeatherWithWoeIdAsync(string woeId)
        {
            var response = await client.GetAsync(WeatherForLocationURI + woeId);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseContent);

            return weatherResponse;
        }

        /// <summary>
        /// Gets the cities Where on Earth Id (WoeId) by searching its name.
        /// </summary>
        /// <param name="cityName">Name of a city</param>
        /// <returns>A city location response containing the woeId or null if the city doesn't exist</returns>
        private async Task<SearchLocationResponse> GetCitiesWoeIdAsync(string cityName)
        {
            var response = await client.GetAsync(LocationWoeIdURI + cityName);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var locationResponse = JsonConvert.DeserializeObject<List<SearchLocationResponse>>(responseContent);

            return locationResponse.FirstOrDefault();
        }
    }
}
