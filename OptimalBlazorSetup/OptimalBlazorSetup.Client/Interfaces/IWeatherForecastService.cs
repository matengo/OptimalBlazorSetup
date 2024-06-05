using MagicOnion;
using OptimalBlazorSetup.Client.Interfaces.Dto;

namespace OptimalBlazorSetup.Client.Interfaces
{
    public interface IWeatherForecastService : IService<IWeatherForecastService>
    {
        UnaryResult<WeatherForecast[]> GetAllAsync();
    }
}
