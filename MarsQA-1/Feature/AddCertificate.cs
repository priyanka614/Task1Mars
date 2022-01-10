using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Feature
{
    [Binding]
    class AddCertificates
    {
   
        [Given(@"I clicked on the Certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //click on certification tab
            Driver.driver.FindElement(By.XPath("//a[text()='Certifications']")).Click();
        }

        [When(@"I add a new Certification details (.*) and (.*) and (.*)")]
        public void WhenIAddANewCertificationDetails(string Certificate,string From,string Year)
        {
            //click on add new tab
            Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][text()='Add New'])[3]")).Click();
            //entering certification name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys(Certificate);
            //entering certification from
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']")).SendKeys(From);
            //selecting year of certification

            IWebElement Drop_Year = Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
            SelectElement Dropdown6 = new SelectElement(Drop_Year);
            Dropdown6.SelectByValue(Year);

            
            Thread.Sleep(2000);
           Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

            Thread.Sleep(3000);
        }

   
        [Then(@"that Certification Details should be displayed on my listings")]
        public void ThenThatCertificationDetailsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='Cisco']")).Displayed);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Add a Certificate");

                Thread.Sleep(1000);
                string ExpectedValue = "Cisco";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Cisco']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certificate Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Certificate Added");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
    }
}
