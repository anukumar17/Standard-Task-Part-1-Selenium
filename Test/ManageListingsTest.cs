using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Pages;
using NUnit.Framework;
namespace MarsFramework.Test
{
    class ManageListingsTest
    {

        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to View ManageListings sucessfully")]
            public void ViewManageListings()
            {   //create extent report
                test = extent.StartTest("ViewManageListings");
                //View ManageListings
                ManageListings ManageLisObj = new ManageListings();
                ManageLisObj.ViewListings();
                //ManageLisObj.EditManageListings();
                //CertiObj.VerifyCertificate();

            }




            [Test, Order(2), Description("check if the user is able to Edit ManageListings sucessfully")]
            public void EditManageListings()
            {   //create extent report
                test = extent.StartTest("EditManageListings");
                //View ManageListings
                ManageListings ManageLisObj = new ManageListings();
                ManageLisObj.EditManageListings();
                //ManageLisObj.VerifyEditManageListings();


            }
            [Test, Order(3), Description("check if the user is able to Delete ManageListings sucessfully")]
            public void DeleteManageListings()
            {   //create extent report
                test = extent.StartTest("DeleteManageListings");
                //View ManageListings
                ManageListings ManageLisObj = new ManageListings();
                ManageLisObj.DeleteManageListings();
                ManageLisObj.VerifyDeleteManageListings();


            }
        }
    }
}