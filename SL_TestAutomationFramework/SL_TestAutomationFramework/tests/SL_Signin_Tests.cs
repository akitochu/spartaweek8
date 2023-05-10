
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SL_TestAutomationFramework.lib.pages;

namespace SL_TestAutomationFramework.tests
{
    public class SL_Signin_Tests
    {
        private SL_Website<ChromeDriver> SL_Website = new(isHeadless:true);

        [Test]
        public void GivenIAmOnTheHomePage_WhenIEnterAValidEmailAndValidPassword_ThenIShouldLandOnTheInventoryPage()
        {
            // Maximise browser
            SL_Website.SeleniumDriver.Manage().Window.Maximize();
            // Navigate to home page
            SL_Website.SL_HomePage.VisitHomePage();
            // Enter valid username
            SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
            // Enter valid password
            SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
            // Click login button
            SL_Website.SL_HomePage.ClickLoginButton();
            // Check landing page is correct
            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.InventoryPageUrl));
        }
        
        [Test]
        public void GivenIAmOnTheHomePage_WhenIEnterAValidEmailAndInvalidPassword_ThenIShouldSeeAnErrorMessage_WhichContainsEpicSadFace()
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
        [OneTimeTearDown]
        public void CleanUp()
        {
            SL_Website.SeleniumDriver.Quit();
        }

    }
}
