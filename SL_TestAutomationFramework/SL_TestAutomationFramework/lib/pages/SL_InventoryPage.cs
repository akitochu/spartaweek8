
using OpenQA.Selenium;

namespace SL_TestAutomationFramework.lib.pages
{
    public class SL_InventoryPage
    {
        private IWebDriver _seleniumDriver;

        public SL_InventoryPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        private string _homePageUrl = AppConfigReader.InventoryPageUrl;

        private IWebElement _filter => _seleniumDriver.FindElement(By.Name("select_container"));

        public void VisitInventoryPage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
    }
}
