using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BoDi;
using BbcWeather.UI;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Pages
{
    public class BbcWeatherPage
    {
        private const string Url = "https://www.bbc.com/weather";
         private IWebDriver _driver;

        public BbcWeatherPage(IWebDriver driver)
        {
            _driver = driver;
            
        }
        
        
        public void TypeInSearchField(string search)
        {
            _driver.FindElement(By.XPath("//*[@id=\"APjFqb\"]")).SendKeys(search);
        }

        private By _bournemouthLocations = By.CssSelector("text=Bournemouth, Bournemouth");
                     
        public void ClickBournemouthLocationOption ()
        {
                                Thread.Sleep(    1500);
            var elements = 
                _driver.FindElements(_bournemouthLocations);
            elements[0].Click();
        }

        private By TomorrowsHighTemperature => By.CssSelector("#daylink-0 .wr-day-temperature__high-value");

        public int GetTomorrowsHighTemperature()
        {
            var element = _driver.FindElement(TomorrowsHighTemperature);
            var temp =  element.Text;
            return GetTemperatureAsInteger(temp);
        }

        private By TomorrowsLowTemperature => By.CssSelector("#daylink-0 .wr-day-temperature__low-value");
        
        public int GetTomorrowsLowTemperature()
        {
            var element = _driver.FindElement(TomorrowsLowTemperature);
            var temp =  element.Text;
            return GetTemperatureAsInteger(temp);
        }
        
        public async Task Navigate()
        {
            await _driver.Navigate().GoToUrlAsync(Url);
        }

        private static int GetTemperatureAsInteger(string temperature)
        {
            var condition = true;
            var temperatureNoCelsius = "";
            while (condition)
            {
                temperatureNoCelsius = temperature.Remove(temperature.Length - 1, 1);
            }
            return int.Parse(temperatureNoCelsius);
        }
        
        public bool IsTodayHigherThanTomorrow()
        {
            return true;
        }
    }
}