import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './weather.component.html'
})

export class WeatherComponent {
  public forecast: WeatherResponse;
  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherResponse>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecast = result;
    }, error => console.error(error));

    this.baseUrl = baseUrl;
    this.httpClient = http;
  }

  async myRefreshEvent(event: Subject<any>, message: string) {
    await this.getWeatherForCity(this.forecast.cityName, event);
  }

  getWeatherForCity(cityName, event = null) {
    this.httpClient.get<WeatherResponse>(this.baseUrl + 'weatherforecast?cityName=' + cityName).subscribe(result => {
      this.forecast = result;

      if (event) {
        event.next();
      }

    }, error => console.error(error));
  }

  onSubmit(cityName) {
    this.getWeatherForCity(cityName);
  }
}

interface WeatherResponse {
  lastRefresh: string;
  cityName: string;
  weather: Weather;
  errorMessage: string;
}

interface Weather {
  consolidatedWeather: ConsolidatedWeather[];
  sunRise: Date;
  sunSet: Date;
  parent: Parent;
  title: string;
  latitudeAndLongitude: string;
}

interface Parent {
  title: string;
}

interface ConsolidatedWeather {
  weatherStateName: string;
  weatherStateAbbreviation: string;
  date: string;
  minTemperature: number;
  maxTemperature: number;
  currentTemperature: number;
  windSpeed: number;
  windDirection: number;
  airPressure: number;
  humidity: number;
  visibility: number;
  weatherStateImageURL: string;
}
