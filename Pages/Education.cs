
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;


namespace MarsFramework.Pages
{
    class Education
    {

        public Education()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //initalize web elements
        #region
        //Click on Education tab
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
        private IWebElement EducationTab { get; set; }
        //Click on Add New Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNewBtn { get; set; }

        //Click on UniversityName TextBox 
        [FindsBy(How = How.Name, Using = "instituteName")]
        private IWebElement UniTextBox { get; set; }
        //Add Institution Name in UniversityName TextBox 
        [FindsBy(How = How.Name, Using = "instituteName")]
        private IWebElement AddUniName { get; set; }

        //Click on Country dropdown list
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement CntryDrpdwn { get; set; }

        //Select Country name from dropdownlist
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement ChooseCtryName { get; set; }

        //Click on Title Text dropdown list
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement TitleDrpdwn { get; set; }

        //Select  Title from Title Text dropdown list
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement ChooseTitle { get; set; }

        //Click on Degree TextBox
        [FindsBy(How = How.Name, Using = "degree")]
        private IWebElement DegreTextBox { get; set; }

        //Select Degree
        [FindsBy(How = How.Name, Using = "degree")]
        private IWebElement AddDegreName { get; set; }

        //Click on Year of Graduation dropdown list
        [FindsBy(How = How.Name, Using = "yearOfGraduation")]
        private IWebElement yearOfGradtndrpdwn { get; set; }

        //Select year from year from Year of Graduation list
        [FindsBy(How = How.Name, Using = "yearOfGraduation")]
        private IWebElement ChooseYrOfGrdtn { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddBtn { get; set; }

        //Edit ...
        //Education to edit
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement EduToSel { get; set; }

        //Click on Edit Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]")]
        private IWebElement EditBtn { get; set; }

        // Click on Update Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")]
        private IWebElement UpdateBtn { get; set; }

        //Delete....

        // Click on Delete Cross Icon
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i")]
        private IWebElement DeleteBtn { get; set; }

        #endregion

        internal void VerifyEditEducation()
        {
            #region Verify Updated Education 
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Edu Tab
                EducationTab.Click();
                Base.test.Log(LogStatus.Pass, "education is Edited successfully");

                //verify Title 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]", 10000);
                var LastRowTitleName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]title")).Text;
                Assert.That(LastRowTitleName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "title")));

                Base.test.Log(LogStatus.Pass, "edited education verify successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Enter Education Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "education is not Edited successfully");
            }

            #endregion
        }

        internal void DeleteLanguage()
        {
            #region Edit Education 
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Edu Tab
                EducationTab.Click();

                //click on eduacation to delete
                EduToSel.Click();

                // Click on Delete Cross Icon educatiob button
                //Click on  delete education button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i", 20000);
                DeleteBtn.Click();
                Base.test.Log(LogStatus.Pass, "education is Deleted successfully");
            } 
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Delete Education Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "education is not Deleted successfully");
            }

          #endregion
        }

         internal void VerifyEducation()
        {
            #region VerifyEducation Details
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Edu Tab
                EducationTab.Click();

                //Verify Country
                //click on last row country name

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowCountryName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Assert.That(lastRowCountryName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Country")));

                //Verify University.....click on last row university name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowUniName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
                Assert.That(lastRowUniName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "University")));

                //Verify Title....click on last row title 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]", 10000);
                var lastRowTitle = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]")).Text;
                Assert.That(lastRowTitle, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));

                //Verify Degree.....click on last row  degree
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]", 10000);
                var lastRowDegree = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")).Text;
                Assert.That(lastRowDegree, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Degree")));

                //Verify Year Of Graduaction.....click on last row Year Of Graduaction
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]", 10000);
                var lastRowYrOfGrdtn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]")).Text;
                Assert.That(lastRowYrOfGrdtn, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation")));
                Base.test.Log(LogStatus.Pass, "Added Education verified successfully");

            }
            catch (Exception ex)

            {
                Assert.Fail("Test Failed to Enter Skill Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "Added education is not eneterd successfully");
            }

            #endregion

        }

        internal void EditEducation()
        {
            #region Edit Education 
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Edu Tab
                EducationTab.Click();

                //Click on education To Edit
                //Click on education to be edit
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                EduToSel.Click();

                //Click on Edit Button
                EditBtn.Click();

                //Clcik on Education(Title) To Be Update...
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
                TitleDrpdwn.Click();

                //Choose Title 
                new SelectElement(ChooseTitle).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

                //click on Update Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]", 10000);
                UpdateBtn.Click();
                Base.test.Log(LogStatus.Pass, "education is Edited successfully");

            }  
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Enter Education Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "education is not Edited successfully");
            }

             #endregion
         }

        internal void EnterEducation()
        {
            #region EnterEducation Details
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Edu Tab
                EducationTab.Click();

                //Click on Add New Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 10000);
                AddNewBtn.Click();

                //Click on UniversityName TextBox 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "instituteName", 10000);
                UniTextBox.Click();
                UniTextBox.Clear();

                //Add Institution Name in UniversityName TextBox 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "instituteName", 10000);
                AddUniName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

                //Click on Country dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "country", 10000);
                CntryDrpdwn.Click();

                //Select Country name from dropdownlist
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "country", 10000);
                new SelectElement(CntryDrpdwn).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));

                //Click on Title Text dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
                TitleDrpdwn.Click();

                //Select  Title from Title Text dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
                new SelectElement(ChooseTitle).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));


                //Click on Degree TextBox
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "degree", 10000);
                DegreTextBox.Click();
                DegreTextBox.Clear();

                //Select Degree
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "degree", 10000);
                AddDegreName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

                //Click on Year of Graduation dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "yearOfGraduation", 10000);
                yearOfGradtndrpdwn.Click();

                //Select year from year from Year of Graduation list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "yearOfGraduation", 10000);
                new SelectElement(ChooseYrOfGrdtn).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation"));


                //Click on Add button
                AddBtn.Click();
                Base.test.Log(LogStatus.Pass, "education entered  successfully");

            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Enter Skill Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "education is not eneterd successfully");
            }
        }

        #endregion
    }

}