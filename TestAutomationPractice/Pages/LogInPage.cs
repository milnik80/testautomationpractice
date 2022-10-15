using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationPractice.Pages
{
    class LogInPage
    {
        readonly IWebDriver driver;

        public By loginpage = By.Id("authentication");
        public By username = By.Id("email");
        public By password = By.Id("passwd");
        public By signinBtn = By.Id("SubmitLogin");

        public LogInPage(IWebDriver driver)
        {
        this.driver = driver;
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(loginpage));
        }
    }
}
