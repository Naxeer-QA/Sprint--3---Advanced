using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsQA_1.Helpers
{
    public class ConstantHelpers
    {
        //Base Url
        public static string Url = "http://localhost:5000";

        //ScreenshotPath
        public static string ScreenshotPath = @"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\TestReports\Screenshots\";

        //ExtentReportsPath
        public static string ReportsPath = @"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\TestReports\Test_files\";

        //ReportXML Path
        public static string ReportXMLPath = @"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\TestReports\Test_files\";

        #region Wait Function for an element to be visible
        public static void WaitForElementToBeVisible(IWebDriver driver, string LocatoryType, string LocatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (LocatoryType == "Xpath")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LocatorValue)));
            }
            if (LocatoryType == "Id")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocatorValue)));
            }
            if (LocatoryType == "CSSSelector")
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorValue)));
            }
        }
        public static void WaitUntilClickable(IWebDriver driver, string element, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(element)));

        }
        #endregion
    }
}
