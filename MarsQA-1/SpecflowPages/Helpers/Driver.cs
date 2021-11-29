using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MarsQA_1.Helpers
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();
            TurnOnWait();

            //Maximise the window
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(45);
            NavigateUrl();
        }

        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }


        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }
        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }
        //Close the browser
        public static void Close()
        {
            TurnOnWait();
            driver.Quit();
        }

        #region PageScrollDown
        public void PageScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 350)");
        }

        //Give an element locator to be viewed and scrolled to
        public void PageScroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(), element");
        }

        public void PageDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
        #endregion
    }
}
