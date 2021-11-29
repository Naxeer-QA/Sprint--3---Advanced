using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MarsQA_1.Helpers;
using AutoItX3Lib;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
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
        //[FindsBy(How = How.XPath, Using = "//input[contains(@name,'skillTrades')])[1]")]
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

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[2]")]
        public IWebElement CreditOption { get; set; }

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
            Title.SendKeys(ReadData(2, "Title"));
            Description.SendKeys(ReadData(2, "Description"));
            CategoryDropDown.SendKeys(ReadData(2, "Category"));
            SubCategoryDropDown.SendKeys(ReadData(2, "SubCategory"));
            Tags.SendKeys(ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            hd.PageScrollDown();
            ServiceTypeOptions_HourlyBasis.SendKeys(ReadData(2, "ServiceType"));
            LocationType.SendKeys(ReadData(2, "LocationType"));
            StartDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //StartDateDropDown.SendKeys(ReadData(2, "Startdate"));
            StartDateDropDown.SendKeys("12/12/2021");
            EndDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //EndDateDropDown.SendKeys(ReadData(2, "Enddate"));
            EndDateDropDown.SendKeys("12/12/2022");
            EnterAvailableDays();
            //SkillTrade.SendKeys(ReadData(3, "SkillTrade"));
            //EnterSkillExchange();
            ExchangeSkills();
            FileUpload();
            ChooseActiveOrHidden();
            Thread.Sleep(3000);
            Save.Click();

        }
        #endregion

        #region Function for Exchange Skills
        public void ExchangeSkills()
        {
            if (ReadData(2, "SkillTrade") == "Skill-Exchange")
            {
                SkillTrade.Click();
                SkillExchange.SendKeys(ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                SkillTrade.Click();
                CreditAmount.Clear();
                CreditAmount.SendKeys(ReadData(2, "Credit"));
            }
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
            
        }
        #endregion 

        #region Function to upload file
        public void FileUpload()
        {
            hd.PageScrollDown();
            uploadFileBtn.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinWaitActive("[CLASS:Open]", "", 3);
            autoIT.Send(@"C:\Users\Admin\Desktop\IC_DummyFile.txt");
            autoIT.Send("{Enter}");
        }
        #endregion

        #region Function to update file upload
        public void UpdateFileUpload()
        {
            hd.PageScrollDown();
            uploadFileBtn.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinWaitActive("[CLASS:Open]", "", 3);
            autoIT.Send(@"C:\Users\Admin\Desktop\Update_IC.txt");
            autoIT.Send("{Enter}");
        }
        #endregion

        #region Function to choose Active/Hidden option
        public void ChooseActiveOrHidden()
        {
            if (ReadData(2, "Active") != "Hidden")
            {
                ActiveOption.Click();
            }
            else
            {
                hiddenOption.Click();
            }
        }
        #endregion

        #region Function to enter skill exchange
        public void EnterSkillExchange()
        {
            Actions act = new Actions(Driver.driver);
            SkillExchange.SendKeys(ReadData(2, "Skill-Exchange"));
            act.Click(SkillExchange)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
           }
        #endregion

        #region Function to enter tags
        public void EnterTags()
        {
            if(Tags != null)
            {
                Actions action = new Actions(Driver.driver);
                action.Click(Tags)
                    .SendKeys(Keys.Backspace)
                    .Build()
                    .Perform();
                Tags.SendKeys(ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);
                hd.PageScrollDown();
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Function to Update existing skill
        public void UpdateSkill()
        {
            PopulateInCollection(@"D:\Internship\ThirdSprint\onboarding.specflow-master\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "UpdateSkill");
            Title.Clear();
            Title.SendKeys(ReadData(2, "Title"));
            Description.Clear();
            Description.SendKeys(ReadData(2, "Description"));
            CategoryDropDown.SendKeys(ReadData(2, "Category"));
            SubCategoryDropDown.SendKeys(ReadData(2, "SubCategory"));
            EnterTags();
            ServiceTypeOptions_HourlyBasis.SendKeys(ReadData(2, "ServiceType"));
            LocationType.SendKeys(ReadData(2, "LocationType"));
            StartDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //StartDateDropDown.SendKeys(ReadData(2, "Startdate"));
            StartDateDropDown.SendKeys("12/12/2021");
            EndDateDropDown.Clear();
            //TODO : Below statement wrongly pick the row data
            //EndDateDropDown.SendKeys(ReadData(2, "Enddate"));
            EndDateDropDown.SendKeys("12/12/2022");
            EnterAvailableDays();
            CreditOption.Click();
            CreditAmount.SendKeys("5");
            UpdateFileUpload();
            ChooseActiveOrHidden();
            Thread.Sleep(3000);
            Save.Click();
        }
        #endregion

        #region Funtion to show added skill on the manage listings page
        public void ValidateAddedSkillIsListed()
        {
            //Find table
            IWebElement Table = Driver.driver.FindElement(By.XPath("//table[@class = 'ui striped table']/tbody"));

            //find Table row
            IList<IWebElement> TableRow = Table.FindElements(By.XPath("tr"));

            foreach(var row in TableRow)
            {
                bool x = row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Selenium Web Driver')]")).Displayed;
                if(x == true)
                {
                    System.Console.WriteLine("Capture Title dispalyed as : " + row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Selenium Web Driver')]")).Text);
                    break;
                }
            }
            var Actual = Driver.driver.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Selenium Web Driver')]")).Text;
            var Expected = "Selenium Web Driver";
            Assert.That(Actual, Is.EqualTo(Expected));
        }
        #endregion

        #region Funtion to show updated skill on the manage listings page
        public void ValidateUpdatedSkillIsListed()
        {
            //Find table
            IWebElement Table = Driver.driver.FindElement(By.XPath("//table[@class = 'ui striped table']/tbody"));

            //find Table row
            IList<IWebElement> TableRow = Table.FindElements(By.XPath("tr"));

            foreach (var row in TableRow)
            {
                bool x = row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Automation using Selenium')]")).Displayed;
                if (x == true)
                {
                    System.Console.WriteLine("Capture Title dispalyed as : " + row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Automation using Selenium')]")).Text);
                    break;
                }
            }
            var Actual = Driver.driver.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Automation using Selenium')]")).Text;
            var Expected = "Automation using Selenium";
            Assert.That(Actual, Is.EqualTo(Expected));
        }
        #endregion

    }
}
