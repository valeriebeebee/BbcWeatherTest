using System;
using System.Threading;
using System.Threading.Tasks;
using BbcWeather.UI.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Steps
{
    [Binding]
    public class BbcWeatherSteps
    {
        private readonly BbcWeatherPage _bbcWeatherPage;
        private readonly IWebDriver _driver;

        public BbcWeatherSteps(BbcWeatherPage bbcWeatherPage)
        {
            _bbcWeatherPage = bbcWeatherPage;
            _driver = new ChromeDriver();
        }

        [Given(@"I have openedd a new driver window")]
        public void GivenIHaveOpeneddANewDriverWindow()
        {
            _driver.Manage().Cookies.DeleteAllCookies();

            _driver.Manage()
                .Timeouts()
                .ImplicitWait = new TimeSpan(0, 0, 30);

            _driver.Manage()
                .Window.Maximize();        
        }
        
        [When(@"I am on the BBC Weather page")]
        public async Task GivenIAmOnTheBbcWeatherPage()
        {
            await _bbcWeatherPage.Navigate();
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string location)
        {
            Thread.Sleep(1500);
            _bbcWeatherPage.TypeInSearchField(location);
            Thread.Sleep(1500);
            _bbcWeatherPage.ClickBournemouthLocationOption();
        }

        [Then(@"tomorrow\'s high temperature is higher than tomorrow\'s low temperature")]
        public void ThenTomorrowsHighTemperatureIsHigherThanTomorrowsLowTemperature()
        {
            var isTodayHigherThanTomorrow = true;
            try
            {
                isTodayHigherThanTomorrow = _bbcWeatherPage.IsTodayHigherThanTomorrow();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
            Assert.True(isTodayHigherThanTomorrow);
        }
    }
}