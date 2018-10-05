using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SharpSeleniumAuto.WebUI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(Constants.Constants.ExpectedCondition));
            _wait = wait;
        }

        // Find WebElement by Id using PageFactory
        [FindsBy(How = How.Id, Using = "id")]
        public IWebElement Field1 { get; set; }

        // Find WebElement by ClassName using PageFactory
        [FindsBy(How = How.ClassName, Using = "class_name")]
        public IWebElement Field2 { get; set; }

        // Find WebElement by XPath uing PageFactory
        [FindsBy(How = How.XPath, Using = "xpath")]
        public IWebElement Button { get; set; }

        // Find WebElement by Name using PageFactory
        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement Label { get; set; }

        // Find WebElement by CssSelector using PageFactory
        [FindsBy(How = How.CssSelector, Using = "css")]
        public IWebElement DropDown { get; set; }


        // Simple method (send text and click)
        public void SignIn(String userName, String password, String database)
        {
            Field1.SendKeys(userName);
            Field2.SendKeys(password);
            DropDown.SendKeys(database);
            Button.Click();
        }

        //Simple method with ExpectedConditions (send text, wait for element and click)
        public void SignInWithEC(String userName, String password, String database)
        {
            Field1.SendKeys(userName);
            this._wait.Until(ExpectedConditions.ElementToBeClickable(Field2));
            Field2.SendKeys(password);
            DropDown.SendKeys(database);
            Button.Click();

        }

        // Simple method with Assert (send text, verify data and click)
        public void SignInWithAssert(String userName, String password, String database)
        {
            Field1.SendKeys(userName);
            Field2.SendKeys(password);
            Assert.AreEqual(DropDown.Text, database);
            Button.Click();
        }
    }
}
