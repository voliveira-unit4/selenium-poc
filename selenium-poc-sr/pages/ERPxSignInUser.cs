using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Common;
using OpenQA.Selenium.Support.UI;
using selenium_poc_sr.entities;
using selenium_poc_sr.helpers;

namespace selenium_poc_sr.pages
{
    public class ERPxSignInUser
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By userBy = By.Id("i0116");
        private By nextBy = By.Id("idSIButton9");
        

        public ERPxSignInUser(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void SignIn(string user)
        {
            driver.FindElement(userBy).SendKeys(user);
            wait.Until(ExpectedConditions.ElementToBeClickable(nextBy)).Click();
        }
    }
}
