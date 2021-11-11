using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MarsQA_1.Helpers;
using System;
using AutoItX3Lib;
using System.Threading;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ShareSkill_Add : ExcelLibHelper
    {
        Driver hd = new Driver();

        //Create constructor to initiate the web element objects
        public ShareSkill_Add()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region Web element objects for Shareskill
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        [FindsBy(How = How.XPath, Using = "//h3[@id = 'requiredField'][text()='Tags']/../..//input[@class = 'ReactTags__tagInputField']")]
        private IWebElement Tags { get; set; }

        //Remove Tags 
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ReactTags__selected']/../../../../div[2]/div/div/div[@class = 'ReactTags__selected']")]
        private IWebElement removeTags { get; set; }

        //Select the Service type
        //[FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'serviceType'][@value = 0]")]
        private IWebElement ServiceTypeOptions_HourlyBasis { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'serviceType'][@value = 1]")]
        public IWebElement ServiceTypeOptions_OneOff { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType']")]
        private IWebElement LocationType { get; set; }

        //Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = 1]")]
        //private IWebElement LocationTypeOption_Online { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        [FindsBy(How = How.XPath, Using = "//div[@class = 'twelve wide column']/div[@class = 'form-wrapper']")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'StartTime'][@index = '1']")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        //[FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        //[FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value = 'true']")]
        //private IWebElement SkillTradeOption_exchange { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades']")]
        private IWebElement SkillTrade { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[1]//div[1]//input[1]")]
        private IWebElement ActiveOption { get; set; }

        //Click on Hidden option
        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        //[FindsBy(How = How.XPath, Using = "//label[text()='Hidden']")]
        public IWebElement hiddenOption { get; set; }

        //Upload file button
        [FindsBy(How = How.XPath, Using = "//i[@class = 'huge plus circle icon padding-25']")]
        public IWebElement uploadFileBtn { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
        #endregion

        #region Function for navigating to shareskill page
        public void GoToShareSkillPage()
        {
            ShareSkillButton.Click();
        }
        #endregion

        #region Function to enter skill related details
        public void EnterSkillRelevantItems()
        {
            PopulateInCollection(@"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "AddSkill");
            Title.SendKeys(ReadData(3, "Title"));
            Description.SendKeys(ReadData(3, "Description"));
            CategoryDropDown.SendKeys(ReadData(2, "Category"));
            SubCategoryDropDown.SendKeys(ReadData(2, "SubCategory"));
            Tags.SendKeys(ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);
            hd.PageScrollDown();
            ServiceTypeOptions_HourlyBasis.SendKeys(ReadData(2, "ServiceType"));
            LocationType.SendKeys(ReadData(2, "LocationType"));
            Thread.Sleep(4000);
            StartDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //StartDateDropDown.SendKeys(ReadData(2, "Startdate"));
            StartDateDropDown.SendKeys("12/12/2021");
            EndDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //EndDateDropDown.SendKeys(ReadData(2, "Enddate"));
            EndDateDropDown.SendKeys("12/12/2022");
            EnterAvailableDays();
            SkillTrade.SendKeys(ReadData(2, "SkillTrade"));
            SkillExchange.SendKeys(ReadData(2, "Skill-Exchange"));
            Actions act = new Actions(Driver.driver);
            act.Click(SkillExchange)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
            uploadFileBtn.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinWait("[CLASS:Open]", "", 4);
            autoIT.WinActivate("Open");
            autoIT.Send(@"C:\Users\Admin\Desktop\IC_DummyFile.txt");
            autoIT.Send("{Enter}");
            hd.PageScrollDown();
            Driver.TurnOnWait();

            if (ReadData(2, "Active") != "Hidden")
            {
                ActiveOption.Click();
            }
            else
            {
                hiddenOption.Click();
            }
            Save.Click();

        }
        #endregion

        #region Function to find available days and select
        private void EnterAvailableDays()
        {
            PopulateInCollection(@"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "AddSkill");
            switch (ReadData(2, "Selectday"))
            {
                case "Sun":
                    IWebElement CheckSun = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[1]//div[1]/input[@name = 'Available']"));
                    CheckSun.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Mon":
                    IWebElement CheckMon = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckMon.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Tue":
                    IWebElement CheckTue = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckTue.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Wed":
                    IWebElement CheckWed = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckWed.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Thu":
                    IWebElement CheckThu = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckThu.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Fri":
                    IWebElement CheckFri = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckFri.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;

                case "Sat":
                    IWebElement CheckSat = Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[8]//div[1]/div[1]/input[@name = 'Available']"));
                    CheckSat.Click();
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[8]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(ReadData(2, "Starttime"));
                    Driver.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[8]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(ReadData(2, "Endtime"));
                    break;
            }
            #endregion
        }
        public void ValidateSuccessMessage()
        {
            PopulateInCollection(@"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "AddSkill");
            var ActualMsg = Driver.driver.FindElement(By.XPath(
                "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
            Console.WriteLine("Captured message is : " + ActualMsg);
            var ExpectedMsg = ReadData(2, "SuccessMessage");
            var NoMsg = "";
            Assert.That(ActualMsg, Is.AnyOf(ExpectedMsg, NoMsg));
        }
    }
}
