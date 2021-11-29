using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using MarsQA_1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ManageListing
    {
        public ManageListing()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        #region Web Element objects of Manage Listings tab

        //Open Manage Listings tab
        [FindsBy (How = How.XPath, Using = "//a[text()='Manage Listings']")]
        [CacheLookup]
        public IWebElement ManageListingsTab { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        [CacheLookup]
        public IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        [CacheLookup]
        public IWebElement deleteListings { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        [CacheLookup]
        public IWebElement editListings { get; set; }

        //Click on No button
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button[@class = 'ui negative button']")]
        [CacheLookup]
        public IWebElement NoButton { get; set; }

        //Click on Yes button
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']//i[@class = 'checkmark icon']")]
        [CacheLookup]
        public IWebElement YesButton { get; set; }

        #endregion

        #region Function to go to Manage listings tab
        public void GoToListingsTab()
        {
            ManageListingsTab.Click();
        }
        #endregion

        #region Function to find and edit the listing
        public void EditListing()
        {
            //find the table element
            IWebElement Table = Driver.driver.FindElement(By.XPath("//table[@class = 'ui striped table']/tbody"));

            //find the table row
            IList<IWebElement> tableRow = Table.FindElements(By.XPath("tr"));
            
            foreach(var row in tableRow)
            {
                bool x = row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Selenium Web Driver')]/following-sibling::*[5]/div/button/i[@class = 'outline write icon']")).Displayed;
                if(x == true)
                {
                    row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Selenium Web Driver')]/following-sibling::*[5]/div/button/i[@class = 'outline write icon']")).Click();
                    break;
                }
            }
        }
        #endregion

        #region Function to remove skills
        public void RemoveSkills()
        {
            //find the table element
            IWebElement Table = Driver.driver.FindElement(By.XPath("//table[@class = 'ui striped table']/tbody"));

            //find the table row
            IList<IWebElement> tableRow = Table.FindElements(By.XPath("tr"));

            foreach (var row in tableRow)
            {
                bool x = row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Automation using Selenium')]/following-sibling::*[5]/div/button/i[@class = 'remove icon']")).Displayed;
                if (x == true)
                {
                    row.FindElement(By.XPath("//table/tbody/tr/td[contains(., 'Automation using Selenium')]/following-sibling::*[5]/div/button/i[@class = 'remove icon']")).Click();
                    break;
                }
            }
        }

        #endregion

        #region Function to select Yes from remove module
        public void ConfirmRemove()
        {
            YesButton.Click();
        }
        #endregion

        #region Function to select Yes from remove module
        public void ClickCancelRemove()
        {
            NoButton.Click();
        }
        #endregion
    }
}
