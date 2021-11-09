using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Profile_Description
    {
        public Profile_Description()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        public class DescriptionDetails
        {
            public string Description { get; set; }

            public string NoDescription { get; set; }
        }

        #region Description web element objects
        [FindsBy(How = How.XPath, Using = "//i[@class = 'outline write icon']")]
        [CacheLookup]
        public IWebElement descriptionEditBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[@name = 'value']")]
        [CacheLookup]
        public IWebElement descTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class = 'ui teal button'][@type = 'button']")]
        [CacheLookup]
        public IWebElement descSaveBtn { get; set; }
        #endregion

        #region Function to show Description
        internal void ShowDescription(string Description)
        {
            var actualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@class = 'eight wide column']//span[@style = 'padding-top: 1em;']")).Text;
            var expectedMsg = Description;
            Console.WriteLine(expectedMsg);
            Assert.That(actualMsg, Is.EqualTo(expectedMsg));
        }
        #endregion

        #region Function for empty Description
        internal void EmptyDescription()
        {
            ClearDescription();
            descSaveBtn.Click();
        }
        #endregion

        #region function to go to Description box
        internal void GoToDescriptionTab()
        {
            Profile_Language lang = new Profile_Language();
            lang.ProfileTab();
            Thread.Sleep(5000);
            descriptionEditBtn.Click();
        }
        #endregion

        #region Function for entering description
        public void EnterDescription(string Description)
        {
            ClearDescription();
            descTextArea.SendKeys(Description);
            descSaveBtn.Click();
        }
        #endregion

        #region Function to clear Description field
        public void ClearDescription()
        {
            Actions Act = new Actions(Helpers.Driver.driver);
            Act.Click(descTextArea)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Backspace)
                .Build()
                .Perform();
        }
        #endregion
    }
}
