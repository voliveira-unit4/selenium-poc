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
    public class ERPxHome
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By tasksIconBy = By.CssSelector("#u4_button-1066-btnEl");
        private By goToTasksBy = By.Id("u4_pagebutton-1583-btnIconEl");

        public ERPxHome(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void GotoTasks()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(tasksIconBy)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToTasksBy)).Click();
        }
    }
}
