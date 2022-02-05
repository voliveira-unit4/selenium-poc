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

            #region get fake person data

            driver.Navigate().GoToUrl("https://www.fakenamegenerator.com/");
            driver.FindElement(By.Id("genbtn")).Click();
            
            string eName = driver.FindElement(By.CssSelector("#details > div.content > div.info > div > div.address > h3")).Text;
            var eAddress = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[1]/div"));
            var ePhone = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[2]/dl[4]/dd"));
            var eEmail = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div[2]/div[2]/div/div[2]/dl[9]/dd"));

            string firstName = eName.Split(" ")[0];
            string lastName = eName.Split(" ")[2];
            string streetAddress = eAddress.Text.Split("\r\n")[0];
            string place = eAddress.Text.Split("\r\n")[1].Split(",")[0];
            string state = eAddress.Text.Split("\r\n")[1].Split(",")[1].Trim().Split(" ")[0];
            string postalCode = eAddress.Text.Split("\r\n")[1].Split(",")[1].Trim().Split(" ")[1];
            string phone = ePhone.Text;
            string email = eEmail.Text.Split("\r\n")[0];

            Thread.Sleep(2000);

            #endregion

            #region sign in to smart recruiters

            driver.Navigate().GoToUrl("https://www.smartrecruiters.com/account/sign-in");
            
            driver.FindElement(By.Id("email")).SendKeys("U4SR.Dev@gmail.com");
            driver.FindElement(By.Id("sign-in-next-btn")).Click();
            driver.FindElement(By.Id("password")).SendKeys("Smart2020");
            driver.FindElement(By.Id("sign-in-btn")).Click();
            
            #endregion

            #region create candidate

            driver.Navigate().GoToUrl("https://www.smartrecruiters.com/app/home/");
            
            driver.FindElement(By.Id("st-shortcutsDropdownButton")).Click();
            driver.FindElement(By.Id("st-shortcutsAddCandidate")).Click();
            driver.FindElement(By.Id("st-fillManually")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("st-firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("st-lastName")).SendKeys(lastName);
            driver.FindElement(By.Name("location")).SendKeys(place);
            driver.FindElement(By.Id("st-phoneNumber")).SendKeys(phone);
            driver.FindElement(By.Id("st-email")).SendKeys(email);
            driver.FindElement(By.Id("st-typeSelect")).Click();
            driver.FindElement(By.CssSelector("option[label='Organic']")).Click();
            driver.FindElement(By.Id("st-jobPicker")).SendKeys("Smart Recruiters operator");
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/add-candidates/div/div/form/add-single/div[1]/div[4]/div/div/div[2]/div/job-picker/div/div/div[1]/ul/li[1]/div/button/span/strong")).Click();
            driver.FindElement(By.Id("st-sourceDetail")).SendKeys("ACCA Careers");
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/add-candidates/div/div/form/add-single/div[1]/div[4]/div/div/div[1]/div/source-picker/div/div[3]/div[1]/div/ul/li/span/div/div[1]/strong")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("st-submitCandidate")).Click();
            Thread.Sleep(6000);
            #endregion

            driver.Quit();
        }
    }
}