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
    public class Fakenamegenerator
    {
        protected WebDriver driver;
        
        private By generateBy = By.Id("genbtn");
        private By nameBy = By.CssSelector("#details > div.content > div.info > div > div.address > h3");
        private By addressBy = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[1]/div");
        private By phoneBy = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[2]/dl[4]/dd");
        private By emailBy = By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[2]/dl[9]/dd");
        
        public Fakenamegenerator(WebDriver driver)
        {
            this.driver = driver;
        }

        public Person GetPerson()
        {
            driver.FindElement(generateBy).Click();
            var eName = driver.FindElement(nameBy).Text;
            var eAddress = driver.FindElement(addressBy);
            var ePhone = driver.FindElement(phoneBy);
            var eEmail = driver.FindElement(emailBy);

            string stateCode = eAddress.Text.Split("\r\n")[1].Split(",")[1].Trim().Split(" ")[0];

            Person person = new Person()
            {
                FirstName = eName.Split(" ")[0],
                LastName = eName.Split(" ")[2],
                ShortName = $"{eName.Split(" ")[0].Substring(0, 1).ToUpper()}{eName.Split(" ")[2].ToUpper()}",
                Phone = ePhone.Text,
                Email = eEmail.Text.Split("\r\n")[0],
                StreetAddress = eAddress.Text.Split("\r\n")[0],
                City = eAddress.Text.Split("\r\n")[1].Split(",")[0],
                ZipCode = eAddress.Text.Split("\r\n")[1].Split(",")[1].Trim().Split(" ")[1],
                State = Tools.DecodeUSState(stateCode),
                Country = "USA"
            };

            return person;
        }
    }
}
