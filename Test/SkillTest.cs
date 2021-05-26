using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SkillTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to add Skill sucessfully")]
            public void AddSkill()
            {
                //create extent report
                test = extent.StartTest("AddSkill");
                Skill SkillObj = new Skill();
                SkillObj.AddSkill();
                SkillObj.VerifySkill();

            }

            [Test, Order(2), Description("check if the user is able to Edit Skill sucessfully")]
            public void EditSkill()
            {
                //create extent report
                test = extent.StartTest("EditSkill");
                Skill EditSkillObj = new Skill();
                EditSkillObj.EditSkill();
                EditSkillObj.VerifyEditSkill();
            }

            [Test, Order(3), Description("check if the user is able to Edit Skill sucessfully")]
            public void DeleteSkill()
            {
                //create extent report
                test = extent.StartTest("EditSkill");
                Skill DeleteSkillObj = new Skill();
                DeleteSkillObj.DeleteSkill();
               
            }
        }
    }
}
