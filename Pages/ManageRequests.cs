
using System;
using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class ManageRequests
    {

        public ManageRequests()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region initialize web elements

        //Click on /manage Listing tab
        [FindsBy(How = How.XPath, Using = "//div[text()='Manage Requests']")]
        private IWebElement ManageReqTab {get; set;}

        //click on Received Request dropdown

        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")]
        private IWebElement ReceivedReq { get; set; }

        //click on Action Accept Request
        [FindsBy(How = How.XPath, Using = "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]")]
        private IWebElement Accept { get; set; }

        //Click on Decline Request
        [FindsBy(How = How.XPath, Using = "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]")]
        private IWebElement DeclineRequest { get; set; }

        //Complete Request
        [FindsBy(How = How.XPath, Using = "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button")]
        private IWebElement CompleteRequest { get; set; }




        //Sent Request..Select Sent Request dropdown link

        //Click on /manage Listing tab
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentRequestDrpdwn { get; set; }

        //Click on search input and type name
        [FindsBy(How = How.XPath, Using = "//div[@id='sent-request-section']/div[1]/div[1]/input")]
        private IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='sent-request-section']/div[1]/div[1]/input")]
        private IWebElement SearchInputName { get; set; }

        //click search icon
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[1]/div[1]/i")]
        private IWebElement Searchicon { get; set; }


        #endregion

        internal void SentRequests()
        {
            #region
            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequest");

            //Refresh page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on ManageRequest Tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();
            
            //Click on Sent 
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Sent Requests", 1000);
            SentRequestDrpdwn.Click();

            //Click on search input and type name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='sent-request-section']/div[1]/div[1]/input", 1000);
            SearchInput.Click();
            SearchInput.Clear();
            SearchInputName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchName"));

            //click on search icon
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='sent-request-section']/div[1]/div[1]/i", 1000);
            Searchicon.Click();
            
            #endregion
        }


        internal void ReceviedRequests()
        {
            #region
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequest");
            //GlobalDefinitions.driver.Navigate().Refresh();

            //Click on ManageRequest Tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]", 1000);
            ReceivedReq.Click();

            //Accept or decline
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ReceivedRequests") == "Accept")
            {

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]", 1000);
                Accept.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ReceivedRequests") == "Decline")
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]", 1000);
                 DeclineRequest.Click();
             }

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button", 1000);
            CompleteRequest.Click();

            #endregion
        }
    }
    
}
