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
    class Skill
    {
        public Skill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialite web Element

        //Click on Skill Tab
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillBtn { get; set; }

        //click on Add New Skill Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Click on Add Skill text box and add new Langauge
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddSkillText { get; set; }

        // add new skill
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddNewSkill { get; set; }

        //Click on dropdown  skill level
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement SkillLevelDrpdwn { get; set; }

        //Choose Skill Level from dropdown list
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement ChooseSkillLevel { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddSkillBtn { get; set; }

        //Edit Action 
        //click on skill to be Edit
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement SkillToEdit { get; set; }

        //Click On Edit Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
        private IWebElement EditBtn { get; set; }

        //Click on Update Skill Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        private IWebElement UpdateSkill { get; set; }

        //Delete Skill
        //click on delete cross icon
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")]
        private IWebElement DeleteSkillBtn { get; set; }

        #endregion

        internal void DeleteSkill()
        {
            #region DeleteSkill

            //Populate data saved in excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Skill Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //Click on skill to delete
                SkillToEdit.Click();

                //Click on Delete Skill Icon
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 20000);
                DeleteSkillBtn.Click();
                Base.test.Log(LogStatus.Pass, "Skill deleted successfully");
            }
            catch(Exception ex)
            {
                Assert.Fail("Test failed to Delete Skill", ex.Message);
                Base.test.Log(LogStatus.Fail, "Skill is deleted successfully");
            }
            #endregion
        }

        internal void VerifyEditSkill()
        {
            #region verify EditSkill

            //Populate data saved in excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();

            try
            {
                //Click on Skill Button
                SkillBtn.Click();

                //Verify Last edit skill Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]",10000);
                var lastSkillLevelEdit = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
                Assert.That(lastSkillLevelEdit, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "SkillLevel")));

                Base.test.Log(LogStatus.Pass, "Skill edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify updated Skills", ex.Message);
                Base.test.Log(LogStatus.Fail, "Skill edited is not verified successfully");
            }
            #endregion
        }

        internal void VerifySkill()
        {
            #region Verify Enter Skill

            //Populate data saved in excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();

            try
            {
                //Click on Skill Button
                SkillBtn.Click();

                //Click on Skill to verify
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                var lastRowSkillName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowSkillName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Skill")));

                //Click on Skill Level to verify
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowSkillLevel = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowSkillLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel")));
                Base.test.Log(LogStatus.Pass, "Added skill verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Verify add skill",ex.Message);
                Base.test.Log(LogStatus.Fail, "Added skill is not verified successfully");
            }
            #endregion
        }

        internal void EditSkill()
        {
            #region EditSkill

            //Populate data saved in excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();

        
                //Click on Skill Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //click on Skill to be edit
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]", 10000);
                SkillToEdit.Click();         
                          
                //Click on edit Button corresponding to skill
                // GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 10000);
                EditBtn.Click();

                //click on SkillLevel and select skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
                SkillLevelDrpdwn.Click();
                ChooseSkillLevel.Click();
                new SelectElement(ChooseSkillLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "SkillLevel"));

                //Click on Update Skill Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]", 10000);
                UpdateSkill.Click();
                Base.test.Log(LogStatus.Info, "Select the Edit Skill");

           
            #endregion
        }

        internal void AddSkill()
        {

            #region Enter Skill

            //Populate data saved in excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();

            try
            {

                //Click on Skill tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //Click on Add New Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 10000);
                AddNewSkillBtn.Click();

                //Click on Add Skill TextBox
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "name", 10000);
                AddSkillText.Click();
                AddSkillText.Click();

                //Add Skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
                AddNewSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

                //Click on Skill Level dropdown 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
                SkillLevelDrpdwn.Click();

                //Choose Skill Level
                //GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "name", 10000);
                new SelectElement(ChooseSkillLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));

                //Click on Add Button
                AddSkillBtn.Click();
                Base.test.Log(LogStatus.Info, "Select the Skill");
            }
            catch(Exception ex)
            {
                Assert.Fail("Test Failed to add Skill", ex.Message);

            }
            #endregion
        }

    }

}
