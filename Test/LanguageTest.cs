using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class LanguageTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to add Language sucessfully")]
            public void AddLanguage()
            {   //create extent report
                test = extent.StartTest("AddLanguage");
                //Add Profile
                Language LanObj = new Language();
                LanObj.EnterLanguage();
                LanObj.VerifyLanguage();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Language Sucessfully ")]
            public void EditLanguage()
            {
                //Create extent report
                test = extent.StartTest("EditLanguage");
                //Edit Language
                Language EditLanObj = new Language();
                EditLanObj.EditLanguage();
                EditLanObj.VerifyEditLanguage();

            }

            [Test, Order(3), Description("Check if the user is able to Edit Language Sucessfully ")]
            public void DeleteLanguage()
            {
                //Create extent report
                test = extent.StartTest("EditLanguage");
                //Edit Language
                Language DeleteLanObj = new Language();
                DeleteLanObj.DeleteLanguage();
            }

        }
    }
}
