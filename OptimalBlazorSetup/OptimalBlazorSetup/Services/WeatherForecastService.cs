using MagicOnion;
using MagicOnion.Server;
using OptimalBlazorSetup.Client.Interfaces;
using OptimalBlazorSetup.Client.Interfaces.Dto;

namespace OptimalBlazorSetup.Services
{
    public class WeatherForecastService : ServiceBase<IWeatherForecastService>, IWeatherForecastService
    {
        //Inject the what you need as usual
        public WeatherForecastService()
        {
        }
        public async UnaryResult<WeatherForecast[]> GetAllAsync()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();

            return await Task.FromResult(forecasts);
        }
    }
}
