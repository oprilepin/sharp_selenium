using NUnit.Framework;
using OpenQA.Selenium;
using SharpSeleniumAuto.WebUI.Pages;
using SharpSeleniumAuto.WebUI.Driver;
using SharpSeleniumAuto.WebUI.Constants;

namespace SharpSeleniumAuto.WebUI.TestsUI
{
    public class TestSuite
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        string userName = Constants.Constants.UserName;
        string password = Constants.Constants.Password;
        string database = Constants.Constants.DataBae;

        [SetUp] // SetUp Attribute - will be executed as TS precondition
        public void SetUpTest()
        {
            driver = new WebBrowser().SetDriver();
            loginPage = new LoginPage(driver);
        }

        [Test] // Test Attribute - will be recognized as test by TestAdapter
        public void VerifyLogIn()
        {
            loginPage.SignIn(userName, password, database);
        }

        [TearDown] // TearDown Attribute - will be executed as TS postcondition
        public void TearDownTest()
        {
            driver.Quit();
        }
    }
}
