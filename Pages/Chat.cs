using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class Chat
    {
        public Chat()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialize web elements
        //Click on Chat tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]")]
        private IWebElement clickChat { get; set; }

        //Select name
        [FindsBy(How = How.XPath, Using = "//div[@id='chatList']/div/div[2]/div[1]")]
        private IWebElement EnterChatSel { get; set; } 
        //Select chat box to enter data
        [FindsBy(How = How.XPath, Using = "//*[@id='chatTextBox']")]
        private IWebElement EnterChat { get; set; }

        //Click on Send tab
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement clickSend { get; set; }
        #endregion

        internal void Chats()
        {
            #region
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Chat");

            //Click on Chat tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]", 10000);
            clickChat.Click();

            //Select name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='chatList']/div/div[2]/div[1]", 10000);
            EnterChatSel.Click();

            //Select chat box to enter data
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='chatTextBox']", 10000);
            EnterChat.Click();
            EnterChat.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Message"));
            //EnterChat.SendKeys("Hi");

            //Click on Send tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='btnSend']", 10000);
            clickSend.Click();
            Base.test.Log(LogStatus.Info, "Chat message sent successfully");
            #endregion
        }


    }
}
