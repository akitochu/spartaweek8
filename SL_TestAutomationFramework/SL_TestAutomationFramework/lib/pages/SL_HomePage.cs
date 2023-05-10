

using OpenQA.Selenium;

namespace SL_TestAutomationFramework.lib.pages
{
    public class SL_HomePage
    {
        private IWebDriver _seleniumDriver;
        //Get web elements
        //private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _passwordField
        {
            get { return _seleniumDriver.FindElement(By.Id("password")); }
        }
        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("[data-test=\"error\"]"));

        private string _homePageUrl = AppConfigReader.BaseUrl;


        public SL_HomePage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void EnterUserName(string username) => _usernameField.SendKeys(username);
        public void EnterPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLoginButton() => _loginButton.Click();
        public string CheckErrorMessage() => _errorMessage.Text;
    }
}
