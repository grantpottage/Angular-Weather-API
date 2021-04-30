using AngularWeatherAPI.Interfaces;
using AngularWeatherAPI.Models;
using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ApiServiceTests
    {
        [Fact]
        public async void GetAPIResponse_ChekcsIfResponseIsNotNull_ReturnsAWeatherResponseObjectIfWorking()
        {
            string cityName = "Belfast";
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IApiService>()
                    .Setup(x => x.GetWeatherForCityAsync(cityName))
                    .ReturnsAsync(new WeatherResponse());

                var cls = mock.Create<IApiService>();

                var weatherResponse = await cls.GetWeatherForCityAsync(cityName);

                mock.Mock<IApiService>()
                    .Verify(x => x.GetWeatherForCityAsync(cityName), Times.Exactly(1));

                Assert.NotNull(weatherResponse);
            }
        }

        [Fact]
        public async void GetAPIResponse_ChekcsIfResponseIsNotNull_ReturnsANullObjectIfNotWorking()
        {
            string cityName = "this city does not exist";
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IApiService>()
                    .Setup(x => x.GetWeatherForCityAsync(cityName))
                    .ReturnsAsync((WeatherResponse)null);

                var cls = mock.Create<IApiService>();

                var weatherResponse = await cls.GetWeatherForCityAsync(cityName);

                mock.Mock<IApiService>()
                    .Verify(x => x.GetWeatherForCityAsync(cityName), Times.Exactly(1));

                Assert.Null(weatherResponse);
            }
        }
    }
}
