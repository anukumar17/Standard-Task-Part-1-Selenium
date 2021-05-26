using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SearchSkillFilterTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to Search Skill By Filter sucessfully")]
            public void SearchSkillFilter()
            {
                //create extent report
                test = extent.StartTest("SearchSkillFilter");
                SearchSkillFilter SearchSkillFilObj = new SearchSkillFilter();
                SearchSkillFilObj.SearchSkillFilters();
            }

        }
    }
}
