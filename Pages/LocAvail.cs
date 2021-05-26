using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;


namespace MarsFramework
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region Initialite web Element

        //Click on Edit icon
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailEditBtn { get; set; }
        //Select from dropdown 
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement DrpdwnSlct { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HourEdit { get; set; }


        //click on drop down list and choose hours
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement HoursDrpdwn { get; set; }

        //click on Earn Target edit Icon
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTrgt { get; set; }

        //Click on dropdown list and select from hours dropdown list
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement EarnTrgtDrpdwn { get; set; }

        #endregion

        internal void AddProfile()
        {

            //Populate excel Data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            #region profile details
            try
            {

                // Click on Edit Icon
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPAth", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10000);
                AvailEditBtn.Click();

                //Select drom dropdown
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyType", 10000);
                DrpdwnSlct.Click();
                new SelectElement(DrpdwnSlct).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
                Base.test.Log(LogStatus.Info, "Select the available time");
            }
            catch (Exception ex)
            {
                Assert.Fail("TimeAvailability Failed", ex.Message);

            }


            try
            {
                //Click on Hours edit icon
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i", 10000);
                HourEdit.Click();

                //Click on dropdown button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyHour", 10000);
                HoursDrpdwn.Click();
                new SelectElement(HoursDrpdwn).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
                Base.test.Log(LogStatus.Info, "Select the available time");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to enter Availability Hours", ex.Message);

            }
            try
            {
                //Click on earntarget edit Icon
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i", 10000);
                EarnTrgt.Click();

                //click on drop down list 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyTarget", 10000);
                EarnTrgtDrpdwn.Click();

                //Select earnTarget from dropwdown list
                new SelectElement(EarnTrgtDrpdwn).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
                Base.test.Log(LogStatus.Info, "Select the Earn Target Salary");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Edit Earn Target", ex.Message);
            }

            #endregion
        }

       







        }

        

    }


