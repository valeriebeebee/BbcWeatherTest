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

//         public async Task ids()
//         {
// //             driver.find_element(:xpath, "//input[@id='loginid']"
// //             driver.find_element(:xpath, "//input[@name='q']"
// //                 <input id="gbqfq" class="gbqfif" type="text" value="" autocomplete="off" name="q">
// // //input[@id="amount" and @maxlength='50']
// // //input[@id and @maxlength]
// //
// //                 driver.find_element(:id, 'amount') and driver.find_element(xpath: "//input[@maxlength='50']")
//         }
    }
}