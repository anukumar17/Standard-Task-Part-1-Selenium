using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class EducationTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to add Education sucessfully")]
            public void AddEducation()
            {   //create extent report
                test = extent.StartTest("AddEducation");
                //Add Education
                Education EduObj = new Education();
                EduObj.EnterEducation();
                EduObj.VerifyEducation();

            }

            [Test, Order(2), Description("check if the user is able to add Education sucessfully")]
            public void EditEducation()
            {
                test = extent.StartTest("EditEducation");
                //Edit Education
                Education EditEduObj = new Education();
                EditEduObj.EditEducation();
                //EditEduObj.VerifyEditEducation();
            }

            [Test, Order(3), Description("check if user is able to Delete Education sucessfully")]
            public void DeleteEducation()
            {    
                //create extent report
                test= extent.StartTest("DeleteEducation");
                //Delete Education
                Education DelEduObj = new Education();
                DelEduObj.DeleteLanguage();
             }
        }
    }
}
