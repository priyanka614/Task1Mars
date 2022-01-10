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
    class Education
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //clicking on Education tab

            Driver.driver.FindElement(By.XPath("//a[text()='Education']")).Click();
        }

        [When(@"I add a new Education details  (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenIAddANewEducationDetails(string College,string Degree,string Country,string Title,string Year)
        {

            //adding first education detais

            //clicking on add new tab
            Driver.driver.FindElement(By.XPath("//th[text()='Graduation Year']//following::div[1]")).Click();
            //entering college or uni name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys(College);
            //selecting college of country
             
            //select coutry from dropdown
             IWebElement Drop_Country= Driver.driver.FindElement(By.XPath("//select[@name='country']"));
             SelectElement Dropdown1= new SelectElement(Drop_Country);
             Dropdown1.SelectByValue(Country);

            Thread.Sleep(3000);

            //SELECT title from dropdown
            IWebElement Drop_Title = Driver.driver.FindElement(By.XPath("//select[@name='title']"));
            SelectElement dropdown2 = new SelectElement(Drop_Title);
            dropdown2.SelectByValue(Title);

            Thread.Sleep(3000);
         
            //entering degree
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).SendKeys(Degree);

            //selecting year of graduation
           IWebElement Drop_GradYear = Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
            SelectElement dropdown3 = new SelectElement(Drop_GradYear);
            dropdown3.SelectByValue(Year);

            Thread.Sleep(2000);
           
            Thread.Sleep(1000);
            //clicking on add button
            Driver.driver.FindElement(By.XPath("//div[@class='sixteen wide field']/input[1]")).Click();
            Thread.Sleep(2000);

        }

        [Then(@"that Education Details should be displayed on my listings")]
        public void ThenThatEducationDetailsShouldBeDisplayedOnMyListings()
        {
            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//td[text()='UUNZ']")).Displayed);
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.Extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "UUNZ";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[text()='UUNZ']")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Education details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Details Added");
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
