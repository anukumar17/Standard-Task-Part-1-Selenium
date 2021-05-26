using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class CertificateTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to add Certificate sucessfully")]
            public void AddCertifications()
            {   //create extent report
                test = extent.StartTest("AddCertificate");
                //Add Certification
                Certificate CertiObj = new Certificate();
                CertiObj.EnterCertificate();
                CertiObj.VerifyCertificate();

            }


            [Test, Order(2), Description("check if the user is able to edit Certificate sucessfully")]
            public void editCertifications()
            {
                //create extent report
                test = extent.StartTest("EditCertificate");
                //edit Certificate
                Certificate EditCertiObj = new Certificate();
                EditCertiObj.EditCertificate();
                EditCertiObj.VerifyEditCertificate();

            }


            [Test, Order(3), Description("check if the user is able to delete Certificate sucessfully")]
            public void DeleteCertifications()
            {   //create extent report
                test = extent.StartTest("DeleteCertificate");
                //Add Education
                Certificate DeleteCertiObj = new Certificate();
                DeleteCertiObj.DeleteCertificate();

            }

        }
    }
}

