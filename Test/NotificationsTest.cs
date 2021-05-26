using NUnit.Framework;
using MarsFramework.Pages;

namespace MarsFramework.Test
{
    class NotificationsTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        class User : Global.Base
        {
            [Test, Order(1), Description("check if the user is able to See Notification Show Less  sucessfully")]
            public void Notifications()
            {
                //create extent report
                test = extent.StartTest("Notification");
                Notifications NotificationsObj = new Notifications();
                NotificationsObj.Notification();
            }
        }

    }
}
