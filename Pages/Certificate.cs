
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
    class Certificate
    {

        public Certificate()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        //Initialize web elements

        #region

        //Click on Certification tab
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement CertiTab { get; set; }

        //Click on Add New Certification Button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddCertiBtn { get; set; }

        //Click on Certificate or Award Text Box
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement CertiText { get; set; }

        //Select Certification Name in the text box
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement AddCertiName { get; set; }

        //Click on Certification From Text Box
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement CertiFromText { get; set; }

        //Add on Certification From Text 
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement AddCertiFrom { get; set; }

        //Click on Year Dropdown List
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement YearCertiDrpdwn { get; set; }

        //Choose Year from Year Dropdown List
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement ChooseCertiYear { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddBtn { get; set; }


        //Edit certification
        //Certification to edit
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement CertiToSel { get; set; }

        //Click on edit certification button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i")]
        private IWebElement EditCertiBtn { get; set; }

        //Click on update certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")]
        private IWebElement UpdateCertiBtn { get; set; }

        //Delete Action
        //Delete Certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]")]
        private IWebElement DeleteCertiBtn { get; set; }


        #endregion


        internal void EnterCertificate()
        {
            #region Verify Updated Education 
            //Populate Saved excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Refresh window
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {
                //Click on Certification tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertiTab.Click();

                //Click on Add New Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 10000);
                AddCertiBtn.Click();

                //Click on Certificate or Award Text Box
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationName", 10000);
                CertiText.Click();
                CertiText.Clear();

                //Select or Add Certification Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationName", 10000);
                AddCertiName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

                //Click on Certification From Text On
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationFrom", 10000);
                CertiFromText.Click();
                //CertiFromText.Clear();

                //Add on Certification From Text 
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationFrom", 10000);
                AddCertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

                //Click on Year Dropdown List
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationYear", 10000);
                YearCertiDrpdwn.Click();

                //Choose Certificate year from year dropdown list
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationYear", 10000);
                new SelectElement(ChooseCertiYear).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfCertification"));

                //click on Add Button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Add']", 10000);
                AddBtn.Click();
                Base.test.Log(LogStatus.Pass, "enter certification successfully");

            }
            catch (Exception ex)
            {
                Assert.Fail("Test Failed to Enter Certification Details", ex.Message);
                Base.test.Log(LogStatus.Fail, "certificationis not entered successfully");
            }

            #endregion
        }

        internal void VerifyCertificate()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            #region VerifyCeritificate
            //verify certification
            try
            {

                //Jump to Certification tab

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertiTab.Click();

                //Verify Certificate Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowCertificateName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowCertificateName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate")));

                //Verify Certificate Issuing Place
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowCertificateFrom = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowCertificateFrom, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom")));

                //Verify Certificate Year
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowCertificateYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowCertificateYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfCertification")));
                Base.test.Log(LogStatus.Pass, "Added Certification verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Added Certification is not verified successfully");
            }
            #endregion
        }
        
        internal void EditCertificate()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            #region EditCertificate

            //Click on Certifications
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
            CertiTab.Click();

            //Click on certification to be edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            CertiToSel.Click();

            //Click on edit certification button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i", 10000);
            EditCertiBtn.Click();

            //Update certification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationYear", 10000);
            YearCertiDrpdwn.Click();
            new SelectElement(ChooseCertiYear).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "YearOfCertification")); ;

            //Click on update certification button            
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 10000);
            UpdateCertiBtn.Click();
            Base.test.Log(LogStatus.Info, "Certification edited successfully");

            #endregion
        }

        internal void DeleteCertificate()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            #region DeleteCertificate

            //Delete Certification

            try
            {
                //Click on certification
                //Click on Certifications
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertiTab.Click();

                //Click on certification to be deleted
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                CertiToSel.Click();

                //Click on delete certification button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]", 20000);
                DeleteCertiBtn.Click();
                Base.test.Log(LogStatus.Pass, "Certification deleted successfully");

            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Certification is not deleted successfully");
            }
            #endregion
        }

        internal void VerifyEditCertificate()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //verify updated certification
            //verify certification
            try
            {

                //Jump to Certification tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertiTab.Click();

                //Verify Certificate Year
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowCertificateYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowCertificateYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "YearOfCertification")));
                Base.test.Log(LogStatus.Pass, "Certification edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Certification edited is not verified successfully");
            }
        }
    }

}