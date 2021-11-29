using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsQA_1.SpecflowPages.Pages
{
    class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        #region  Initialize Web Elements for Registration Module
        //Finding the Join from home page
        [FindsBy(How = How.XPath, Using = "//button[contains (text(), 'Join')]")]
        private IWebElement Join { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui page modals dimmer transition visible active']//a[text() = ' Join']")]
        public IWebElement JoinFromLoginFailure { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'firstName']")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'lastName']")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'email']")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'terms']")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        #region Method for Registration
        public void register()
        {
            //Populate the excel data
            Helpers.ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Mars.xlsx", "SignUp");

            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(Helpers.ExcelLibHelper.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(Helpers.ExcelLibHelper.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(Helpers.ExcelLibHelper.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(Helpers.ExcelLibHelper.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(Helpers.ExcelLibHelper.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();
            #endregion
        }
    }
}
