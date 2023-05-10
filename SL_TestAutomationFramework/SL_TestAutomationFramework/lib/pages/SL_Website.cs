

using OpenQA.Selenium;
using SL_TestAutomationFramework.lib.driver_config;

namespace SL_TestAutomationFramework.lib.pages
{
    // Super class. When we instantiate this, we instantiate all web pages
    public class SL_Website<T> where T : IWebDriver, new()
    {
        #region Accessible Page Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }
        public SL_HomePage SL_HomePage { get; set; }
        public SL_InventoryPage SL_InventoryPage { get; set; }
        #endregion

        public SL_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            //Instatniate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            SL_HomePage = new SL_HomePage(SeleniumDriver);
            SL_InventoryPage = new SL_InventoryPage(SeleniumDriver);
        }

    }
}
