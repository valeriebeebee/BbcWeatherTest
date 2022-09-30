using System.Threading.Tasks;
using BbcWeather.UI.Tests.Pages;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Steps
{
    [Binding]
    public class BbcWeatherSteps
    {
        private readonly BbcWeatherPage _bbcWeatherPage;

        public BbcWeatherSteps(IPage page)
        {
            _bbcWeatherPage = new BbcWeatherPage(page);
        }

        [Given(@"I am on the BBC Weather page")]
        public async void GivenIAmOnTheBbcWeatherPage()
        {
            await _bbcWeatherPage.Navigate();
        }

        [When(@"I search for '(.*)'")]
        public async Task WhenISearchFor(string location)
        {
            await _bbcWeatherPage.SearchField.TypeAsync(location);
            await _bbcWeatherPage.BournemouthLocationOption.ClickAsync();
        }

        [Then(@"tomorrow\'s high temperature is higher than tomorrow\'s low temperature")]
        public void ThenTomorrowsHighTemperatureIsHigherThanTomorrowsLowTemperature()
        {
            Assert.IsNotNull(_bbcWeatherPage.TomorrowsHighTemperature);
            Assert.IsNotNull(_bbcWeatherPage.TomorrowsLowTemperature);
            Assert.Greater(_bbcWeatherPage.TomorrowsHighTemperature, _bbcWeatherPage.TomorrowsLowTemperature);
        }
    }
}