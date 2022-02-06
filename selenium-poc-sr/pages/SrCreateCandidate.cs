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

using System.Threading;

namespace selenium_poc_sr.pages
{
    public class SrCreateCandidate
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By dropdownBy = By.Id("st-shortcutsDropdownButton");
        private By addcandidateBy = By.Id("st-shortcutsAddCandidate");
        private By fillmanuallyBy = By.Id("st-fillManually");
        private By firstnameBy = By.Id("st-firstName");
        private By lastnameBy = By.Id("st-lastName");
        private By locationBy = By.Name("location");
        private By phonenumberBy = By.Id("st-phoneNumber");
        private By emailBy = By.Id("st-email");
        private By sourcetypepickerBy = By.Id("st-typeSelect");
        private By sourcetypeBy = By.CssSelector("option[label='Organic']");
        private By jobpickerBy = By.Id("st-jobPicker");
        private By jobBy = By.XPath("/html/body/div[2]/div[2]/add-candidates/div/div/form/add-single/div[1]/div[4]/div/div/div[2]/div/job-picker/div/div/div[1]/ul/li[1]/div/button/span/strong");
        private By sourcedetailBy = By.Id("st-sourceDetail");
        private By sourceBy = By.XPath("/html/body/div[2]/div[2]/add-candidates/div/div/form/add-single/div[1]/div[4]/div/div/div[1]/div/source-picker/div/div[3]/div[1]/div/ul/li/span/div/div[1]/strong");

        public SrCreateCandidate(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void CreateCandidate(Person person)
        {
            driver.FindElement(dropdownBy).Click();
            driver.FindElement(addcandidateBy).Click();
            driver.FindElement(fillmanuallyBy).Click();

            driver.FindElement(firstnameBy).SendKeys(person.FirstName);
            driver.FindElement(lastnameBy).SendKeys(person.LastName);
            driver.FindElement(locationBy).SendKeys(person.City);
            driver.FindElement(phonenumberBy).SendKeys(person.Phone);
            driver.FindElement(emailBy).SendKeys(person.Email);
            driver.FindElement(sourcetypepickerBy).Click();
            driver.FindElement(sourcetypeBy).Click();
            driver.FindElement(jobpickerBy).SendKeys("Smart Recruiters operator");
            driver.FindElement(jobBy).Click();
            driver.FindElement(sourcedetailBy).SendKeys("ACCA Careers");
            driver.FindElement(sourceBy).Click();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("st-submitCandidate"))).Click();
        }
    }
}
