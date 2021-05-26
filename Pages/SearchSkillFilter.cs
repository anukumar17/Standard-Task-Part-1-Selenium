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
    class SearchSkillFilter
    {
        public SearchSkillFilter()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region
        //Click on Search Skill and enter  Category
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement SearchNewSkill { get; set; }

        //Click on search skill icon to search

        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement SearchSkillIcon { get; set; }


        //Select Filter By Online
        [FindsBy(How = How.XPath, Using = "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement OnlineFilter { get; set; }

        //Select Filter By OnSite
        [FindsBy(How = How.XPath, Using = "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]")]
        private IWebElement OnSiteFilter { get; set; }

        //Select Filter By ShowAll
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]")]
        private IWebElement ShowAllFilter { get; set; }


        #endregion

        internal void SearchSkillFilters()
        {
            
            #region
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchFilter");
            GlobalDefinitions.driver.Navigate().Refresh();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/div[1]/div[1]/input", 1000);
            SearchNewSkill.Click();
            SearchNewSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchFilter"));

            //Click on search skill icon to search
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/div[1]/div[1]/i", 1000);
            SearchSkillIcon.Click();

            //Select Filter By Online
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]" ,1000);
            OnlineFilter.Click();
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Skill search using Online is successfull");

            //Select Filter By Onsite
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]",1000);
            OnSiteFilter.Click();
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Skill search using OnSite is successfull");

            //Select Filter By ShowAll
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]", 1000);
            ShowAllFilter.Click();
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "Skill search using ShowAll is successfull");


            #endregion
        }
    }
}
