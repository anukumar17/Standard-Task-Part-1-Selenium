using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SearchSkillTest
    {

        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to search Skill sucessfully")]
            public void SearchSkillByCategories()
            {
                //create extent report
                test = extent.StartTest("SearchSkillByCategories");
                SearchSkillCategory SearchSkillObj = new SearchSkillCategory();
                SearchSkillObj.SearchSkillByCatogories();
            }

        }
    }
}
