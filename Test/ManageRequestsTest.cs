using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class ManageRequestsTest
    {

        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to Received ManageRequests sucessfully")]
            public void ReceivedManageRequests()
            {
                //create extent report
                test = extent.StartTest("ReceivedManageRequests");
                ManageRequests manageRequestObj = new ManageRequests();
                manageRequestObj.ReceviedRequests();
            }



            [Test, Order(2), Description("check if the user is able to Sent ManageRequests sucessfully")]
            public void SentManageRequests()
            {
                //create extent report
                test = extent.StartTest("SentManageRequests");
                ManageRequests manageRequestObj = new ManageRequests();
                manageRequestObj.SentRequests();
            }
        }
    }
}   

