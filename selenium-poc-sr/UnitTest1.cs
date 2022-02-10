using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Common;
using System;
using System.Threading;

using selenium_poc_sr.pages;
using selenium_poc_sr.entities;
using selenium_poc_sr.helpers;
using System.IO;
using System.Text;
using System.Net.Http;

namespace selenium_poc_sr
{
    public class Tests
    {
        private ChromeDriver driver = new ChromeDriver();
        private HttpClient client = new HttpClient();

        [SetUp]
        public void Setup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

        [Test]
        public void CreateSrHiredCandidate()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
           
            #region get fake person data

            #region by using httprequest
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.namefake.com/english-united-states");
            //request.Headers.Add("Accept", "application/json");

            //HttpResponseMessage response = client.Send(request);
            //Stream stream = response.Content.ReadAsStream();
            //string strResponse = "";

            //using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //{
            //    strResponse = reader.ReadToEnd();
            //}
            #endregion

            driver.Navigate().GoToUrl("https://www.fakenamegenerator.com/");

            Fakenamegenerator fakenamegenerator = new Fakenamegenerator(driver);
            Person person = fakenamegenerator.GetPerson();

            #endregion

            #region sign in to smart recruiters

            driver.Navigate().GoToUrl("https://www.smartrecruiters.com/account/sign-in");

            SrSignIn srSignIn = new SrSignIn(driver);
            srSignIn.SignIn("U4SR.Dev@gmail.com", "Smart2020");

            #endregion

            #region create candidate

            driver.Navigate().GoToUrl("https://www.smartrecruiters.com/app/home/");

            SrCreateCandidate srCreateCandidate = new SrCreateCandidate(driver, wait);
            srCreateCandidate.CreateCandidate(person);

            #endregion

            Thread.Sleep(3000);

            #region hire candidate

            SrHireCandidate srHireCandidate = new SrHireCandidate(driver, wait);
            srHireCandidate.HireCandidate(person);

            #endregion

            Thread.Sleep(2000);

            #region trigger EK [vo sln] U4_SEV_NewHires_MAIL_01.0

            string triggerUrl = "https://t-eun-ek1-serverless-gateway.azure-api.net/webhook/v2/990e9af8-2568-494f-a880-b69042feebb5?sig=aMEiyzaI0JNMjvzJAuCLIMDvrm2WAX4R6KLF95KjSDw%253d";
            string triggerResponse;

            WebhookTrigger wt = new WebhookTrigger(client, triggerUrl);
            triggerResponse = wt.Trigger();

            #endregion

            #region ERPx login

            driver.Navigate().GoToUrl("https://erpx.unit4cloud-lab.com/");

            ERPxSignInOrg erpxSignInOrg = new ERPxSignInOrg(driver, wait);
            erpxSignInOrg.SignIn("u4erx_pso_int");

            Thread.Sleep(3000);

            ERPxSignInUser erpxSignInUser = new ERPxSignInUser(driver, wait);
            erpxSignInUser.SignIn("system@u4im.com");

            Thread.Sleep(3000);

            ERPxSignInPassword erpxSignInPassword = new ERPxSignInPassword(driver, wait);
            erpxSignInPassword.SignIn("IndModels21!");

            Thread.Sleep(3000);

            ERPxSignInFinal erpxSignInFinal = new ERPxSignInFinal(driver, wait);
            erpxSignInFinal.SignIn();

            #endregion

            #region ERPx goto tasks

            Thread.Sleep(5000);

            ERPxHome erpxHome = new ERPxHome(driver, wait);
            erpxHome.GotoTasks();

            #endregion

            Thread.Sleep(7000);

            driver.Quit();
        }
    }
}