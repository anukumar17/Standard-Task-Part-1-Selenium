using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
  
        class ShareSkillTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to add ShareSkill sucessfully")]
            public void AddShareSkill()
            {   //create extent report
                test = extent.StartTest("AddShareSkill");
                //Add ShareSkill
                ShareSkill ShareSkillObj = new ShareSkill();
                ShareSkillObj.EnterShareSkill();
                //ShareSkillObj.VerifyShareSkill();

        }  }

    }
}
