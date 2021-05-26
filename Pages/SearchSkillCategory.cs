using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SearchSkillCategory
    {
        #region

        public SearchSkillCategory()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Initialize Web Element

        //Click on Search Skill and enter  Category
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement SearchNewSkill { get; set; }

        //Click on search skill icon to search

        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement SearchSkillIcon { get; set; }

        //Click on All Categories and select Programming and tech
        [FindsBy(How = How.XPath, Using = "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input")]
        private IWebElement SearchSkills { get; set; }//*[@id="service-search-section"]/div[2]/div/section/div/div[1]/div[2]/input

        //Click on search user input and add username
        [FindsBy(How = How.XPath, Using = "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement SearchUser { get; set; }

        //click on Search User Icon
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span")]
        private IWebElement SearchUserIcon { get; set; }
       
        #endregion

        internal void SearchSkillByCatogories()
        {
            #region SearchSkill By Catogores

            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");

            //Refresh Page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on Search Skill and enter  Category
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/div[1]/div[1]/input", 1000);
            SearchNewSkill.Click();
            SearchNewSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkill"));

            //Click on search skill icon to search
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/div[1]/div[1]/i", 1000);
            SearchSkillIcon.Click();

            //Click on All Categories and select Programming and tech
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input", 1000);
            SearchSkills.Click();
            SearchSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkillCategory"));

            //Click on search user input and add username
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input", 1000);
            SearchUser.Click();
            SearchUser.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "User"));

            //click on Search User Icon
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span", 10000);
            //GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/i", 1000);
            SearchUserIcon.Click();
            GlobalDefinitions.driver.Navigate().Refresh();

           Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Skill search is successfull");

            #endregion
        }
    }
}
