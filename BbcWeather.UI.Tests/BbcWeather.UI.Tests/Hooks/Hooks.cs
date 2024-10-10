using BoDi;
using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BbcWeather.UI.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Cookies.DeleteAllCookies();
            _objectContainer.RegisterInstanceAs(_driver);

            _driver.Manage()
                .Timeouts()
                .ImplicitWait = new TimeSpan(0, 0, 30);

            _driver.Manage()
                .Window.Maximize();
        }
    }
}