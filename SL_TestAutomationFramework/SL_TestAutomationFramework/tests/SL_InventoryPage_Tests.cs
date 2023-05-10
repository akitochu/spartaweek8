using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SL_TestAutomationFramework.lib.pages;

namespace SL_TestAutomationFramework.tests
{
    public class SL_InventoryPage_Tests
    {
        private SL_Website<ChromeDriver> SL_Website = new(isHeadless: true);
        [Test]
        public void GivenIAmOnTheInventoryPage_WhenISelectNameZToAFilter_ThenTheInventoryShouldBeOrderedInReverseAlphabeticalOrder()
        {
            SL_Website.SeleniumDriver.Manage().Window.Maximize();

            SL_Website.SL_InventoryPage.VisitInventoryPage();

            var _filter = SL_Website.SeleniumDriver.FindElement(By.Name("select_container"));

            _filter.Click();
            Thread.Sleep(10000);
        }
    }
}




