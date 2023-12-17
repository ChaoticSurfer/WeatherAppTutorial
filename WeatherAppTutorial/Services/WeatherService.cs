using Microsoft.Extensions.Options;

namespace WeatherAppTutorial.Services
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiKey;

        public WeatherService(IHttpClientFactory clientFactory, IOptions<OpenWeatherConfig> config)
        {
            _clientFactory = clientFactory;
            _apiKey = config.Value.OpenWeatherKey;
        }

        public async Task<string> GetWeatherDataAsync(double latitude, double longitude)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}");

            //    response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }


}
