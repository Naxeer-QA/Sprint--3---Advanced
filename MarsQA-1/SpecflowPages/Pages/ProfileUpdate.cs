using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ProfileUpdate
    {
        public ProfileUpdate()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        #region  Initialize Web Elements 
        //Edit profile title
        [FindsBy(How = How.XPath, Using = "//div[@class = 'title']/i[@class = 'dropdown icon']")]

        public IWebElement editTitle { get; set; }

        //Edit First Name
        [FindsBy(How = How.XPath, Using = "//input[@name = 'firstName']")]

        public IWebElement editFirstName { get; set; }

        //Edit Last Name
        [FindsBy(How = How.XPath, Using = "//input[@name = 'lastName']")]

        public IWebElement editLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Save']")]
        public IWebElement saveBtn { get; set; }

        //Click on edit icon for Availability
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Availability']/../div/span/i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForAvailability { get; set; }

        //Click on remove icon for Availability
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Availability']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForAvailability { get; set; }

        //Click to select availability dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyType']")]

        public IWebElement availabilityDropdown { get; set; }

        //Click on edit icon for Hours
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Hours']/../div//i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForHours { get; set; }

        //Click on remove icon for Hours
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Hours']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForHours { get; set; }

        //Click to select Hour dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyHour']")]

        public IWebElement hourDropdown { get; set; }

        //Click on edit icon for EarnTarget
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Earn Target']/../div//i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForEarnTarget { get; set; }

        //Click on remove icon for Earn Target
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Earn Target']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForEarnTarget { get; set; }

        //Click to select Earn Target dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyTarget']")]

        public IWebElement earnTargetDropdown { get; set; }

        #endregion

        #region Function to update profile title
        public void UpdateProfileTitle(string FirstName, string LastName)
        {
            Helpers.Driver hd = new Helpers.Driver();
            hd.PageScrollDown();
            editTitle.Click();
            Thread.Sleep(2000);
            editFirstName.Clear();
            editFirstName.SendKeys(FirstName);
            editLastName.Clear();
            editLastName.SendKeys(LastName);
            saveBtn.Click();
        }
        #endregion

        #region Function for updated title
        public void UpdatedTitleShown(string Title)
        {
            var ActualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@class = 'title']")).Text;
            Console.WriteLine("The updated details are : " + ActualMsg);
            var ExpectedMsg = Title;
            var NoMsg = "";
            Assert.That(ActualMsg, Is.AnyOf(ExpectedMsg, NoMsg));
        }
        #endregion

        #region Function for availability
        public void UpdateAvailability()
        {
            editIconForAvailability.Click();
            SelectElement se = new SelectElement(availabilityDropdown);
            se.SelectByIndex(2);
            var Actualmsg = Helpers.Driver.driver.FindElement(By.XPath("//i[@class = 'large calendar icon']/../../div")).Text;
            var Expectedmsg = "Full Time";
            Assert.That(Actualmsg, Is.EqualTo(Expectedmsg));
        }
        #endregion

        #region Update Hours
        public void UpdateHours()
        {
            editIconForHours.Click();
            SelectElement oSelect = new SelectElement(hourDropdown);
            oSelect.SelectByIndex(3);
            var ActualMsg = Helpers.Driver.driver.FindElement(By.XPath("//i[@class = 'large clock outline check icon']/../../div")).Text;
            var ExpectedMsg = "As needed";
            Assert.That(ActualMsg, Is.EqualTo(ExpectedMsg));
        }
        #endregion

        #region Update EarnTarget
        public void UpdateEarnTarget()
        {
            editIconForEarnTarget.Click();
            SelectElement oS = new SelectElement(earnTargetDropdown);
            oS.SelectByIndex(1);
            var actualMsg = Helpers.Driver.driver.FindElement(By.XPath("//i[@class = 'large dollar icon']/../../div")).Text;
            var expectedMsg = "Less than $500 per month";
            Assert.That(actualMsg, Is.EqualTo(expectedMsg));
        }
        #endregion

        #region Update Message confirmation

        public void MessageValication()
        {
            var ActualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
            Console.WriteLine("Actual message is : " + ActualMsg);
            var ExpectedMsg = "Availability updated";
            //var NoMessage = string.Empty;
            var nomessage = "";
            Assert.That(ActualMsg, Is.AnyOf(ExpectedMsg, nomessage));
        }
        #endregion

    }
}
