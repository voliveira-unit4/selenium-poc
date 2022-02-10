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
    public class ERPxSignInOrg
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By organizationlBy = By.CssSelector("input[name='inputTenantName']");
        private By continueBy = By.CssSelector("button[type='submit']");
        

        public ERPxSignInOrg(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void SignIn(string organization)
        {
            driver.FindElement(organizationlBy).SendKeys(organization);
            wait.Until(ExpectedConditions.ElementToBeClickable(continueBy)).Click();
        }
    }
}
