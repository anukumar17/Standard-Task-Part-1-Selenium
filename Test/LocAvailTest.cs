using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture, Description("this fixture contains mars framework")]
        [Category("Sprint1")]
        class User : Global.Base
        { 

            [Test, Description("check if the user is able to add the profile detail sucessfully")]
            public void ProfileDetail()
            {
                //create extent report
                test = extent.StartTest("Add Profile");
                //Add Profile
                Profile profileObj = new Profile();
                profileObj.AddProfile();


            }

        }
    }
}
