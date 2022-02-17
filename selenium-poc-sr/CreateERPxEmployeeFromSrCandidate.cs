using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Common;
using System;
using System.Threading;

using selenium_poc_sr.pages;
using selenium_poc_sr.entities;
using selenium_poc_sr.helpers;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace selenium_poc_sr
{
    public class CreateERPxEmployeeFromSrCandidate
    {
        const string authUrl = "https://t-eu-ids1.unit4cloud-lab.com/identity/connect/token";
        const string clientId = "u4erp-api-u4erx_pso_int-m2m";
        const string clientSecret = "114a80a9-38ec-48f8-8527-fa794714867b";
        const string erpxApiBaseUrl = "https://eu01.erpx-api.unit4cloud-lab.com";
        const string erpxCompanyId = "X10";
        const string srExternalSystem = "Smart Recruiters";

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

            Thread.Sleep(500);

            #region hire candidate

            SrHireCandidate srHireCandidate = new SrHireCandidate(driver, wait);
            string candidateId = srHireCandidate.HireCandidate(person);

            #endregion

            Thread.Sleep(1000);

            #region trigger EK [vo sln] U4_SEV_NewHires_MAIL_01.0

            string ek1TriggerUrl = "https://t-eun-ek1-serverless-gateway.azure-api.net/webhook/v2/990e9af8-2568-494f-a880-b69042feebb5?sig=aMEiyzaI0JNMjvzJAuCLIMDvrm2WAX4R6KLF95KjSDw%253d";
            string ek1TriggerResponse;

            WebhookTrigger wt1 = new WebhookTrigger(client, ek1TriggerUrl);
            ek1TriggerResponse = wt1.Trigger();

            #endregion

            #region check new employee creation awaits approval

            string url = $"{erpxApiBaseUrl}/v1/objects/workflow-transactions?filter=workflowProcess/elementTypeId eq 'RES' and taskDetails/col9Value eq '{candidateId}'&historicalItems=false&activeItems=true";

            string response = "[]";
            ERPxApiCall erpxCall = new ERPxApiCall(client, authUrl, clientId, clientSecret);
            Stopwatch sw = Stopwatch.StartNew();

            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                response = erpxCall.Get(url);
            } while (response == "[]" && sw.Elapsed.Minutes < 3);

            dynamic wfdata = JArray.Parse(response);

            #endregion

            //#region ERPx login

            //driver.Navigate().GoToUrl("https://erpx.unit4cloud-lab.com/");

            //ERPxSignInOrg erpxSignInOrg = new ERPxSignInOrg(driver, wait);
            //erpxSignInOrg.SignIn("u4erx_pso_int");

            //Thread.Sleep(3000);

            //ERPxSignInUser erpxSignInUser = new ERPxSignInUser(driver, wait);
            //erpxSignInUser.SignIn("system@u4im.com");

            //Thread.Sleep(2000);

            //ERPxSignInPassword erpxSignInPassword = new ERPxSignInPassword(driver, wait);
            //erpxSignInPassword.SignIn("IndModels21!");

            //Thread.Sleep(2000);

            //ERPxSignInFinal erpxSignInFinal = new ERPxSignInFinal(driver, wait);
            //erpxSignInFinal.SignIn();

            //#endregion

            //#region ERPx goto tasks

            //Thread.Sleep(5000);

            //ERPxHome erpxHome = new ERPxHome(driver, wait);
            //erpxHome.GotoTasks();

            //#endregion

            //Thread.Sleep(2000);

            driver.Quit();

            //Thread.Sleep(TimeSpan.FromMinutes(3));

            //#region trigger EK [vo sln] U4_SEV_updateSRCandidateERPxEmployeeId_HTTP_01.00

            //string ek2TtriggerUrl = "https://t-eun-ek1-serverless-gateway.azure-api.net/webhook/v2/2b9d48bd-f92b-4aa7-ac72-4ee160a7bdc1?sig=FyhWUYxVySB47S0g33FzLIo2AX4WCYrrsFLFrUPYhds%253d";
            //string ek2TriggerResponse;

            //WebhookTrigger wt2 = new WebhookTrigger(client, ek2TtriggerUrl);
            //ek2TriggerResponse = wt2.Trigger();

            //#endregion


        }
    }
}