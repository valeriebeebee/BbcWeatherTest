using System;
using System.Threading;
using BbcWeather.UI.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Steps
{
    [Binding]
    public class BbcWeatherSteps
    {
        private readonly BbcWeatherPage _bbcWeatherPage;

        public BbcWeatherSteps(BbcWeatherPage bbcWeatherPage)
        {
            _bbcWeatherPage = bbcWeatherPage;
        }

        [Given(@"I am on the BBC Weather page")]
        public void GivenIAmOnTheBbcWeatherPage()
        {
            _bbcWeatherPage.Navigate();
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