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
    public class ERPxSignInFinal
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By yesdBy = By.Id("idSIButton9");       

        public ERPxSignInFinal(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void SignIn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(yesdBy)).Click();
        }
    }
}
