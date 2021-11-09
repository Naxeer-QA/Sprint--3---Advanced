using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Profile_Language
    {
        public Profile_Language()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }
        public class LanguageDetails
        {
            public string Language { get; set; }
            public string LanguageLevel { get; set; }
        }
        
        #region Language WebElement objects
        [FindsBy(How = How.XPath, Using = "//a[text()='Profile']")]
        [CacheLookup]
        public IWebElement profileTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//table//div[text()='Add New']")]
        [CacheLookup]
        public IWebElement addNewBtn { get; set; }

        //Language Tab related web element object identifications
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Add Language']")]
        [CacheLookup]
        public IWebElement addLanguageInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'level']")]
        [CacheLookup]
        public IWebElement selectLanguageLevel { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'ui teal button']")]
        [CacheLookup]
        public IWebElement addLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'ui button'][@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class = 'ui fixed table']//i[@class = 'outline write icon']")]
        [CacheLookup]
        public IWebElement editIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class = 'ui fixed table']//i[@class = 'remove icon']")]
        [CacheLookup]
        public IWebElement removeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'name']")]
        public IWebElement editLanguageInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//select[@name = 'level']")]
        public IWebElement editProficiencyLevel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//span/input[@value = 'Update']")]
        public IWebElement updateLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//span/input[@value = 'Cancel']")]

        public IWebElement cancelUpdate { get; set; }
        #endregion

        #region Click Profile Tab
        public void ProfileTab()
        {
            profileTab.Click();
        }
        #endregion

        #region Add Language
        public void AddLanguage()
        {
            addNewBtn.Click();
            addLanguageInput.SendKeys("English");
            selectLanguageLevel.Click();
            SelectElement level = new SelectElement(selectLanguageLevel);
            level.SelectByValue("Native/Bilingual");
            addLanguage.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Add Language without level selection
        public void AddLanguageWithNoLevel()
        {
            addNewBtn.Click();
            addLanguageInput.SendKeys("Persian");
            addLanguage.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Update Language
        public void EditLanguage()
        {
            editIcon.Click();
            editLanguageInput.Clear();
            editLanguageInput.SendKeys("Persian");
            editProficiencyLevel.Click();
            SelectElement level = new SelectElement(editProficiencyLevel);
            level.SelectByValue("Fluent");
            updateLanguage.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Update Language with level selection
        public void EditLanguagewithNoLevel()
        {
            editIcon.Click();
            editLanguageInput.Clear();
            editLanguageInput.SendKeys("Persian");
            editProficiencyLevel.Click();
            SelectElement level = new SelectElement(editProficiencyLevel);
            level.SelectByText("Language Level");
            updateLanguage.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Delete Language
        public void DeleteLanguage()
        {
            removeIcon.Click();
        }
        #endregion

        #region Function for entering new language
        public void EnterLanguage(string Language, string LanguageLevel)
        {
            addNewBtn.Click();
            addLanguageInput.SendKeys(Language);
            selectLanguageLevel.SendKeys(LanguageLevel);
            addLanguage.Click();
        }
        #endregion

        #region Function for editing existing language
        public void EditExistingLanguage(string ExistingLanguage, string Language, string LanguageLevel)
        {
            IList<IWebElement> ListOfElements = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first']//table/tbody/tr/td"));
            foreach (var item in ListOfElements)
            {
                Console.WriteLine(item.Text);
                //Console.WriteLine(ListOfElements.Count);
                if (item.Text == ExistingLanguage)
                {
                    Console.WriteLine("Selected Language is : " + item.Text);
                    IWebElement ew = item.FindElement(By.XPath("(//i[@class='outline write icon'])[3]"));
                    ew.Click();
                    Thread.Sleep(2000);
                    addLanguageInput.Clear();
                    addLanguageInput.SendKeys(Language);
                    selectLanguageLevel.SendKeys(LanguageLevel);
                    addLanguage.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for finding, and removing the language from the list
        public void RemoveLanguageFromList(string ExistingLanguage)
        {
            IList<IWebElement> ListOfElements = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first']//table/tbody/tr/td"));
            foreach (var Row in ListOfElements)
                if (Row.Text == ExistingLanguage)
                {
                    IWebElement rmBtn = Row.FindElement(By.XPath("(//i[@class='remove icon'])[3]"));
                    rmBtn.Click();
                    break;
                }
        }
        #endregion

        #region Function for validating the values are shown
        public void DisplayLanguage(string Language)
        {
            //Identify table
            IWebElement tableElement = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']"));

            //Collect the table rows in a list
            IList<IWebElement> tr_collections = tableElement.FindElements(By.XPath("//div[@data-tab = 'first']//tbody/tr"));
            Console.WriteLine("Number Of rows in this table : " + tr_collections.Count);
            int rows_count = tr_collections.Count;

            //Loop will execute till the last row of table.
            for (int row = 0; row < rows_count; row++)
            {
                //To locate columns(cells) of that specific row.
                IList<IWebElement> Columns_row = tr_collections[row].FindElements(By.XPath("//div[@data-tab = 'first']//tbody/tr/td"));

                //To calculate no of columns(cells) In that specific row.
                int columns_count = Columns_row.Count;
                Console.WriteLine("Number of cells In Row " + row + " are " + columns_count);

                //Loop will execute till the last cell of that specific row.
                //for (int column = 0; column < columns_count; column++)
                //{
                    //To retrieve text from that specific cell.
                    //string cellText = Columns_row[column].Text;

                    //Console.WriteLine("Cell Value Of row number " + row + " and column number " + column + " Is " + cellText);
                    //Assert.That(Columns_row, Is.EqualTo(SkillName));
                //}
            }
        }
        #endregion

        #region Function for Modifying without level selection
        public void EditWithoutLevelSelection(string ExistingLanguage, string LanguageLevel)
        {
            IList<IWebElement> ListOfElements = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first']//table/tbody/tr/td"));
            foreach (var item in ListOfElements)
            {
                Console.WriteLine(item.Text);
                //Console.WriteLine(ListOfElements.Count);
                if (item.Text == ExistingLanguage)
                {
                    Console.WriteLine("Selected Language is : " + item.Text);
                    IWebElement ew = item.FindElement(By.XPath("(//i[@class='outline write icon'])[4]"));
                    ew.Click();
                    Thread.Sleep(2000);
                    addLanguageInput.Clear();
                    addLanguageInput.SendKeys(ExistingLanguage);
                    selectLanguageLevel.SendKeys(LanguageLevel);
                    addLanguage.Click();
                    break;
                }
            }
        }
        #endregion


    }
}
