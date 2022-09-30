using System.Threading.Tasks;
using Microsoft.Playwright;

namespace BbcWeather.UI.Tests.Pages
{
    public class BbcWeatherPage
    {
        private const string Url = "https://www.bbc.com/weather";

        private readonly IPage _page;

        public BbcWeatherPage(IPage page)
        {
            _page = page;
        }

        public ILocator SearchField => _page.Locator("id=ls-c-search__input-label");
        
        public ILocator BournemouthLocationOption => _page.Locator("text=Bournemouth, Bournemouth").First;
        
        public int TomorrowsHighTemperature =>
            GetTemperatureAsInteger(_page.Locator("#daylink-0 .wr-day-temperature__high-value").InnerTextAsync());

        public int TomorrowsLowTemperature =>
            GetTemperatureAsInteger(_page.Locator("#daylink-0 .wr-day-temperature__low-value").InnerTextAsync());

        public async Task Navigate()
        {
            await _page.GotoAsync(Url);
        }

        private static int GetTemperatureAsInteger(Task<string> temperature)
        {
            var temperatureNoCelsius = temperature.Result.Remove(temperature.Result.Length - 1, 1);
            return int.Parse(temperatureNoCelsius);
        }
    }
}