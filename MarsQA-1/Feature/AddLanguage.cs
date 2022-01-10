using MarsQA_1.Helpers;
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
    class AddLanguage
    {

        [Given(@"I click on the Language tab in profile")]
        public void GivenIClickOnTheLanguageTabInProfile()
        {
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//a[text()='Profile']")).Click();
        }

        [When(@"I addded a new language (.*) and (.*)")]
        public void WhenIAdddedANewLanguage(string Languages,string Level)
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[text()='Add New']")).Click();
            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys(Languages);
            //Click on Language Level
           


            IWebElement Drop_Level = Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement dropdown3 = new SelectElement(Drop_Level);
            dropdown3.SelectByValue(Level);

          

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(5000);
        }

        

        [Then(@"that language should be displayed on my listing")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListing()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                // string ExpectedValue = "English";
                //string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                Thread.Sleep(500);

                var lang = new List<String> { "Hindi", "English", "Telugu" };
                foreach (String l in lang)
                {
                    if (l == "Hindi")
                    {
                        string ExpectedValue = "Hindi";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Hindi']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                    if (l == "English")
                    {
                        string ExpectedValue = "English";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='English']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                    if (l == "Telugu")
                    {
                        string ExpectedValue = "Telugu";
                        string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Telugu']")).Text;
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

    }
}
