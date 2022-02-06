using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using selenium_poc_sr.entities;
using selenium_poc_sr.helpers;

namespace selenium_poc_sr.pages
{
    public class SrSignIn
    {
        protected WebDriver driver;

        private By emailBy = By.Id("email");
        private By nextBy = By.Id("sign-in-next-btn");
        private By passwordBy = By.Id("password");
        private By signinBy = By.Id("sign-in-btn");

        public SrSignIn(WebDriver driver)
        {
            this.driver = driver;
        }

        public void SignIn(string user, string password)
        {
            driver.FindElement(emailBy).SendKeys(user);
            driver.FindElement(nextBy).Click();
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(signinBy).Click();
        }
    }
}
