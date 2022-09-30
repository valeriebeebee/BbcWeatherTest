using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false });
            var page = await browser.NewPageAsync();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(page);
        }
    }
}