
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SL_TestAutomationFramework.lib.driver_config
{
    // When we instantiate this class, we specfy the generic Type (T)
    // We have put on a constraint which says, that T can ONLY be of IWebDriver type
    // new() - IWebDriver has to be a concrete class (i.e. no abstract, not an interface)
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }
        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs, bool isHeadless)
        {
            Driver = isHeadless ? HeadlessDriver() : new T();
            // The time the driver will wait for the page to load
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            // This is the time the driver waits for elements to load
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }

        private IWebDriver HeadlessDriver()
        {
            if (typeof(T) == typeof(ChromeDriver))
            {
                var options = new ChromeOptions();
                options.AddArgument("headless");
                return new ChromeDriver(options);
            }
            else if (typeof(T) == typeof(FirefoxDriver))
            {
                var options = new FirefoxOptions();
                options.AddArgument("--headless");
                return new FirefoxDriver(options);
            }
            else
            {
                throw new ArgumentException("Headless mode not supported for this browser");
            }
        }
    }
}
