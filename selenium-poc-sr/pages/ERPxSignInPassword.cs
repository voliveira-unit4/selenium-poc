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
    public class ERPxSignInPassword
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By passwordBy = By.Id("i0118");
        private By signInBy = By.Id("idSIButton9");
        

        public ERPxSignInPassword(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void SignIn(string password)
        {
            driver.FindElement(passwordBy).SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInBy)).Click();
        }
    }
}
