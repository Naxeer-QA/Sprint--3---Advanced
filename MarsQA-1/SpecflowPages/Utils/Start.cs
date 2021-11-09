using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Utils
{
    [Binding]
    public class Start : Driver
    {

        [BeforeScenario]
        public void Setup()
        {
            //launch the browser
            Initialize();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Mars.xlsx", "Credentials");
            //call the SignIn class
            SignIn.SigninStep();
        }

        [AfterScenario]
        public void TearDown()
        {
            
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test = new ExtentTest("", "");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            //CommonMethods.Extent.EndTest(test);


            // calling Flush writes everything to the log file (Reports)
            //CommonMethods.Extent.Flush();

            //Close the browser
            Thread.Sleep(3000);
            Close();
        }
    }
}
