using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace selenium_poc_sr
{
    public class Tests
    {
        private ChromeDriver driver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.smartrecruiters.com/app/home/");
            var jobs = driver.FindElement(By.Id("st-jobsLink"));
            jobs.Click();

            Assert.That(driver.Title, Is.EqualTo("Jobs • SmartRecruiters"));
                        
            driver.Quit();
        }
    }
}