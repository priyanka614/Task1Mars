using MarsQA_1.Helpers;
using NUnit.Framework;
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
    class EditLanguage
    {

        [Given(@"I have Click on Edit button corresponding language")]
        public void GivenIHaveClickOnEditButtonCorrespondingLanguage()
        {
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();
            Driver.driver.FindElement(By.XPath("//td[text()='Native/Bilingual']//following::i[1]")).Click();
            Thread.Sleep(3000);
        }

        [Given(@"I have select the update details")]
        public void GivenIHaveSelectTheUpdateDetails()
        {
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")).Click();
            Thread.Sleep(2000);
            //Choose the language level
            Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']//following::option[3]")).Click();
            Thread.Sleep(1000);



        }

        [When(@"I press update button")]
        public void WhenIPressUpdateButton()
        {
            //clicking update button
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"the verifiying language is updated correctly or not")]
        public void ThenTheVerifiyingLanguageIsUpdatedCorrectlyOrNot()
        {
            Assert.AreEqual("English has been updated to your languages", Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text);
            Thread.Sleep(2000);


            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Edit a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English has been updated to your languages";
                string ActualValue = Driver.driver.FindElement(By.CssSelector(".ns-box-inner")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, edited a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageEdited");
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
