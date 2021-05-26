using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System.Threading;


namespace MarsFramework.Pages
{
    class Notifications
    {

        public Notifications()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region

        //Initialize Web Element

        //Select Notification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement NotificationsClick { get; set; }

        //Click on See all
        [FindsBy(How = How.LinkText, Using = "See All...")]
        private IWebElement ClickSeeAll { get; set; }


        //Click on select all
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Select all']")]
        private IWebElement SelectAll { get; set; }

        //UnSelect All
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")]
        private IWebElement UnSelectAll { get; set; }

        //Select one
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input")]
        private IWebElement SelectOne { get; set; }

        //Mark Selction as read
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]")]
        private IWebElement MarkSelection { get; set; }

        //Delete
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]/i")]
        private IWebElement Delete { get; set; }


        #endregion


        internal void Notification()
        {

            #region
            //populate excel data 
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Notifications");

            //Refresh window page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Select Notifications
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10000);
            NotificationsClick.Click();

            //Click on See all
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "See All...", 10000);
            ClickSeeAll.Click();

            // //Click on select all
            // // Wait 
             GlobalDefinitions.WaitForElementClickable(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']//" +
             "div[last()-1]/div/div/div[3]/input", 1000);
             GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@data-tooltip='Select all']", 10000);
            SelectAll.Click();
            Thread.Sleep(1000);
            Base.test.Log(LogStatus.Info, "Successfully selected all notifications");

            //UnSelect All
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]", 10000);
            UnSelectAll.Click();
            Base.test.Log(LogStatus.Info, "Successfully Unselected all notifications");

            //Select one
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 10000);
            SelectOne.Click();
            Thread.Sleep(1000);

            //Mark Selction as read
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]", 10000);
            MarkSelection.Click();
            //Thread.Sleep(1000);

            //Delete Notification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]/i", 10000);
            Delete.Click();
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Delete notification successfull");

            #endregion
        }
    }
}
