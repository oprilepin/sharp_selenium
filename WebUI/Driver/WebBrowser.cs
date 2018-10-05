using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharpSeleniumAuto.WebUI.Constants;

namespace SharpSeleniumAuto.WebUI.Driver
{
    public class WebBrowser
    {
        private IWebDriver driver;

        // Initialize web driver
        public IWebDriver SetDriver()
        {
            driver = new ChromeDriver();
            driver.Url = Constants.Constants.Url;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.Constants.ImplicitWait);
            driver.Manage().Window.FullScreen();
            return driver;
        }

        // Close driver and browser
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}
