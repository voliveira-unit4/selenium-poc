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
    public class SrHireCandidate
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        private By convertBy = By.Id("st-parallel-convert");
        private By processstepsBy = By.CssSelector("button[title='Hiring Process steps']");
        private By hireBy = By.CssSelector("#st-candidateView > aside > sr-job-application-sidebar > div.box > div > div.status_bar.status_bar-hiring_process.ng-scope > div.status_bar-labels.text--center.margin--bottom--none.margin--top--s > span:nth-child(5) > a");
        private By datepickerBy = By.Id("st-candidateFields--dateField");
        private By currentedayBy = By.CssSelector("button[class='datepicker-button ng-binding available current']");
        private By integrationselectBy = By.CssSelector("#st-candidateView > main > div.box.profile-actions.padding--none.print--hidden > sr-application-action-tabs > div.ng-scope > sr-candidate-hire > div > hire-form > span > div > div > form-builder > div.dialog-content.ng-invalid.ng-invalid-required.ng-dirty.ng-valid-date-disabled.ng-valid-parse.ng-valid-date > fieldset > div > div:nth-child(2) > single-select-field > label > span:nth-child(4) > large-select");
        private By integrateerpxBy = By.CssSelector("option[value='fa1a6a45-568c-4177-832d-41f0a488927c']");
        private By shortnameBy = By.CssSelector("input[name='ShortName']");
        private By addressline1By = By.CssSelector("input[name='EmployeeAddressLine1']");
        private By addresscityBy = By.CssSelector("input[name='EmployeeCity']");
        private By addresszipcodeBy = By.CssSelector("input[name='EmployeeZipCode']");
        private By addressstateBy = By.CssSelector("input[name='EmployeeState']");




        private By countryselectBy = By.CssSelector("#st-candidateView > main > div.box.profile-actions.padding--none.print--hidden > sr-application-action-tabs > div.ng-scope > sr-candidate-hire > div > hire-form > span > div > div > form-builder > div.dialog-content.ng-dirty.ng-valid-date-disabled.ng-valid-parse.ng-valid-date.ng-valid.ng-valid-required > fieldset > div > div:nth-child(12) > single-select-field > label > span:nth-child(4) > large-select > select");
        private By countryBy = By.CssSelector("option[value='1399390f-a5d5-4df8-b097-15485e5f298d']");
        private By submitBy = By.Id("st-submitForm");

        public SrHireCandidate(WebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void HireCandidate(Person person)
        {
            By candidatenameBy = By.CssSelector($"a[title='{person.FirstName} {person.LastName}']");
            
            wait.Until(ExpectedConditions.ElementToBeClickable(candidatenameBy)).Click();

            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(convertBy)).Click();

            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(processstepsBy)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(hireBy)).Click();

            driver.FindElement(datepickerBy).Click();
            driver.FindElement(currentedayBy).Click();
            driver.FindElement(integrationselectBy).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(integrateerpxBy)).Click();
            driver.FindElement(shortnameBy).SendKeys(person.ShortName);
            driver.FindElement(addressline1By).SendKeys(person.StreetAddress);
            driver.FindElement(addresscityBy).SendKeys(person.City);
            driver.FindElement(addresszipcodeBy).SendKeys(person.ZipCode);
            driver.FindElement(addressstateBy).SendKeys(person.State);
            driver.FindElement(countryselectBy).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(countryBy)).Click();

            driver.FindElement(submitBy).Click();
        }
    }

    
}
