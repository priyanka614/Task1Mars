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
    class AddSkills
    {

        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //click on skills tab
            Driver.driver.FindElement(By.XPath("//a[text()='Skills']")).Click();
        }

        [When(@"I add a new Skills (.*) and (.*)")]
        public void WhenIAddANewSkills(string Skill,string Level)
        {

            //Click on Add New button first time
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //Add skills
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(Skill);

            //Click on skills Level and choose skill level
            IWebElement Drop_Level = Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"));
            SelectElement Dropdown4 = new SelectElement(Drop_Level);
            Dropdown4.SelectByValue(Level);
            Thread.Sleep(2000);


            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(3000);


        }

        [Then(@"that Skills should be displayed on my listings")]
        public void ThenThatSkillsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()=   'Manual Testing']")).Displayed);

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Manual Testing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='Manual Testing']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
