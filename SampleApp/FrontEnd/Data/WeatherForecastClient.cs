namespace FrontEnd.Data
{
    public class WeatherForecastClient
    {
        private HttpClient _httpClient;
        private ILogger<WeatherForecastClient> _logger;

        public WeatherForecastClient(HttpClient httpClient, ILogger<WeatherForecastClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime? startDate)
        {
            var query = startDate.HasValue ? $"WeatherForecast?startDate={startDate}" : "WeatherForecast";
            try
            {
                return await _httpClient.GetFromJsonAsync<WeatherForecast[]>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching weather forecasts.");
                throw;
            }
        }
    }
}
