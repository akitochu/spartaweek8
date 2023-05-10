using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject
{
    public class Selenium_SigninTests
    {

        [Test]
        [Category("Happy")]
        public void GivenIAmOnTheHomepage_WhenIEnterAValidEmailAndValidPassword_ThenIShouldLandOnTheInventoryPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            //The resource with in the using argument is disposed of when it leaves the closing brace
            //Anything in the using statement argument must implement the IDisposable method
            //So When we leave the using block, its Dispose method is called.
            using (IWebDriver driver = new ChromeDriver())  
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                var userName = driver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");
                Thread.Sleep(1000);
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("secret_sauce");
                var loginButton = driver.FindElement(By.Name("login-button"));
                loginButton.Click();
                Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
            }
        }

        [Test]
        [Category("Sad")]
        public void GivenIAmOnTheHomepage_WhenIEnterAValidEmailAndAnInvalidPassword_ThenIShouldEncounterAnError()
        {
            //The resource with in the using argument is disposed of when it leaves the closing brace
            //Anything in the using statement argument must implement the IDisposable method
            //So When we leave the using block, its Dispose method is called.
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                var userName = driver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");
                Thread.Sleep(1000);
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("incorrect_password");
                var loginButton = driver.FindElement(By.Name("login-button"));
                loginButton.Click();
                var errorMessage = driver.FindElement(By.ClassName("error-message-container"));
                Assert.That(errorMessage.Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
            }
        }

    }
}