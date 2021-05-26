
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Language
    {
        public Language()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialite web Element

        //Click on Language tab
        [FindsBy(How= How.XPath,Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")]
        private IWebElement LanTab{ get; set; }
        //Click on Add New Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement LanAddBtn { get; set; }

        //Click on textbox and enter Language
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement LanText { get; set; }
        //Click on dropdown and select Level
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement LanLevel { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddLan { get; set; }

        //Edit Language
        //Language to Edited
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement LanToSel { get; set; }

        //Click on edit language button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")]
        private IWebElement EditLangBtn { get; set; }

        //Click on update language
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        private IWebElement UpdateLangBtn { get; set; }

        //Delete Language
        //Click on delete cross icon
        [FindsBy(How=How.XPath, Using= "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement DeleteCross { get; set; }

        #endregion


        internal void DeleteLanguage()
        {

            #region DeleteLanguage
            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Language
                LanTab.Click();

                //Click on Language to Delete
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                LanToSel.Click();

                //Click on Delete Cross Icon
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 10000);
                DeleteCross.Click();

                Base.test.Log(LogStatus.Pass, "Language deleted successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Language", ex.Message);
                Base.test.Log(LogStatus.Fail, "Language is not deleted successfully");
            }
            #endregion


        }
        internal void VerifyEditLanguage()
        {
            #region Verify EditLanguage
            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();

            try
            {
                //Verify Updated LanguageLevel
                //Click on Language Button
                LanTab.Click();

                //Select language that is updated
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Xpath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var UpdatedLanguageLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(UpdatedLanguageLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "LanguageLevel")));
                Base.test.Log(LogStatus.Info, "Edited Language successfully");

            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Edit Language", ex.Message);
            }
            #endregion
        }


        internal void EditLanguage()
        {
            #region EditLanguage
            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on Language
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
            LanTab.Click();

            //Click on Language to Edit 
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            LanToSel.Click();

            //Click on Level To Edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 10000);
            EditLangBtn.Click();

            //Click on Level and choose new level
            LanLevel.Click();
            new SelectElement(LanLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "LanguageLevel"));

            //Click on Update Lnguage
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]", 10000);
            UpdateLangBtn.Click();
            Base.test.Log(LogStatus.Info, "Edit Language successfully");
            #endregion

        }


        internal void VerifyLanguage()
        {
            #region Verify Enter Language
            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();

            try
            {    //Verify Language name

                //Click on Language button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
                LanTab.Click();

                //Click on Language Name from already entered row

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var LastLanguageName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(LastLanguageName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Language")));

                //Verify Language Level
                //Click on Last row Language Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]", 10000);
                var LastLanguageLevel = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
                Assert.That(LastLanguageLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel")));
                Base.test.Log(LogStatus.Pass, "Added Language verified successfully");

            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Language", ex.Message);
                Base.test.Log(LogStatus.Fail, "Added Language is not verified successfully");
            }
            #endregion
        }


        internal void EnterLanguage()
        {
            #region Enter Language
            //polulate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh Page
            GlobalDefinitions.driver.Navigate().Refresh();
          
            try
            {
                //Click on Language tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPAth", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
                LanTab.Click();

                // Click on add new button 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 10000);
                LanAddBtn.Click();

                //click on Add Language text Box
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "name", 10000);
                LanText.Click();
                LanText.Clear();
                LanText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

                //click on Dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
                LanLevel.Click();

                //choose level
                new SelectElement(LanLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));

                //click on Add button
                AddLan.Click();
                Base.test.Log(LogStatus.Info, "Select the available time");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Faild to Enter Language", ex.Message);

            }

            #endregion

        }
    }
}

