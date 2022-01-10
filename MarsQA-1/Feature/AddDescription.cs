using MarsQA_1.Helpers;
using OpenQA.Selenium;
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
    class AddDescription
    {

       
        [Given(@"user clicked on the description tab under Profile page")]
        public void GivenuserclickedonthedescriptiontabunderProfilepage()
        {
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();
            Thread.Sleep(3000);
            //clicking descrption edit button
            Driver.driver.FindElement(By.XPath("//h3[text()='Description']//following::i[1]")).Click();
        }

        [When(@"user add description and save")]
        public void Whenuseradddescriptionandsave()
        {
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).Clear();
            // entering description
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).SendKeys("hi this is priyanka i have 1 years of experience in cyber security");
            //clicking save button
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']//following::button")).Click();

        }


      
        [Then(@"That Description should be displayed in Descrption tab")]
        public void Thenthatdescriptionshouldbedisplayedunderdescriptiontab()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Add a Description");

                Thread.Sleep(1000);
                string ExpectedValue = "hi this is priyanka i have 1 years of experience in cyber security";
                string ActualValue = Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Description Added");
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