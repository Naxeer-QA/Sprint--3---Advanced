using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Profile_Skills
    {
        public Profile_Skills()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        #region Properties for Skills table
        public class SkillDetails
        {
            public string Skillname { get; set; }
            public string SkillLevel { get; set; }
        }
        #endregion

        public void RemoveSkills()
        {
            if (addSkillInput != null)
            {
                addSkillInput.Clear();
                SelectElement se = new SelectElement(selectSkillLevel);
                se.SelectByIndex(0);
                //selectSkillLevel.SendKeys(SkillLevel);
            }
        }


        #region Skills Web Element Objects
        [FindsBy(How = How.XPath, Using = "//a[@data-tab = 'second'][text() = 'Skills']")]
        [CacheLookup]
        public IWebElement skillsTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//table//div[text()='Add New']")]
        [CacheLookup]
        public IWebElement addNewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Add Skill']")]
        [CacheLookup]
        public IWebElement addSkillInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [@class = 'ui fluid dropdown']")]
        [CacheLookup]
        public IWebElement selectSkillLevel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'second']//span/input[(@type='button')][@value = 'Add']")]
        [CacheLookup]
        public IWebElement addSkill { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'second']//span/input[(@type='button')][@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'second']//span[@class = 'button']/i[@class = 'outline write icon']")]
        [CacheLookup]
        public IWebElement editIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'second']//span[@class = 'button']/i[@class = 'remove icon']")]
        [CacheLookup]
        public IWebElement removeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'name']")]
        [CacheLookup]
        public IWebElement editSkillInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//select[@name = 'level']")]
        [CacheLookup]
        public IWebElement editProficiencyLevel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//span/input[@value = 'Update']")]
        [CacheLookup]
        public IWebElement updateSkill { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//span/input[@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelUpdate { get; set; }

        #endregion

        #region Add New Skill
        public void AddSkills()
        {
            skillsTab.Click();
            Actions action = new Actions(Helpers.Driver.driver);
            action.SendKeys(Keys.PageDown);
            System.Threading.Thread.Sleep(3000);
            addNewBtn.Click();
            addSkillInput.SendKeys("C#");
            SelectElement sElement = new SelectElement(selectSkillLevel);
            sElement.SelectByValue("Intermediate");
            addSkill.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Add New Skill without level
        public void AddSkillsWithoutLevel()
        {
            skillsTab.Click();
            Actions action = new Actions(Helpers.Driver.driver);
            action.SendKeys(Keys.PageDown);
            System.Threading.Thread.Sleep(3000);
            addNewBtn.Click();
            addSkillInput.SendKeys("Java");
            addSkill.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Update Skill
        public void EditSkills()
        {
            skillsTab.Click();
            editIcon.Click();
            editSkillInput.Clear();
            editSkillInput.SendKeys("Java");
            editProficiencyLevel.Click();
            SelectElement selectelement = new SelectElement(editProficiencyLevel);
            selectelement.SelectByIndex(3);
            updateSkill.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Update Skill without level
        public void EditSkillsWithNoLevel()
        {
            skillsTab.Click();
            editIcon.Click();
            editSkillInput.Clear();
            editSkillInput.SendKeys("C#");
            editProficiencyLevel.Click();
            SelectElement selectelement = new SelectElement(editProficiencyLevel);
            selectelement.SelectByIndex(0);
            updateSkill.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Delete Skill
        public void DeleteSkills(string Skillname)
        {
            //removeIcon.SendKeys(Skillname);
            removeIcon.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Go to Skills tab
        public void GoToSkillsTab()
        {
            Profile_Language lang = new Profile_Language();
            lang.ProfileTab();
            Thread.Sleep(3000);
            skillsTab.Click();
        }
        #endregion

        #region Function for finding, and removing the skill from the list
        public void RemoveSkillFromList(string SkillName)
        {
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'second']//table"));

            IList<IWebElement> tdCollection = Table.FindElements(By.XPath("//div[@data-tab = 'second']//table/tbody/tr/td"));
            Console.WriteLine("Total TD are : " + tdCollection.Count);
            foreach (var tdElement in tdCollection)
            {
                if (tdElement.Text == SkillName)
                {
                    Console.WriteLine("Searched TD is : " + tdElement.Text);
                    IWebElement removeBtn = Helpers.Driver.driver.FindElement(By.XPath("(//i[@class='remove icon'])[4]"));
                    removeBtn.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for skill display
        public void SkillDisplay(string SkillName)
        {
            //Find the table Object
            IWebElement tableElement = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'second']"));

            //Collect the table rows in a list
            IList<IWebElement> tr_collections = tableElement.FindElements(By.XPath("//div[@data-tab = 'second']//tbody/tr"));
            Console.WriteLine("Number Of rows in this table : " + tr_collections.Count);

            foreach (var trElement in tr_collections)
            {
                IList<IWebElement> td_collections = trElement.FindElements(By.XPath("//div[@data-tab = 'second']//tbody/tr/td"));
                Console.WriteLine("Number of Columns are : " + td_collections.Count);

                foreach (var tdElement in td_collections)
                {
                    for (int i = 0; i < td_collections.Count; i++)
                    {
                        if (td_collections[i].Text == SkillName)
                        {
                            Console.WriteLine("Matched TD is : " + td_collections[i].Text);
                            break;
                        }
                        Assert.That(td_collections[i].Text, Is.EqualTo(SkillName));
                    }
                }
            }
        }
        #endregion

        public void DisplaySkills(string SkillName)
        {
            //Identify table
            IWebElement tableElement = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'second']"));

            //Collect the table rows in a list
            IList<IWebElement> tr_collections = tableElement.FindElements(By.XPath("//div[@data-tab = 'second']//tbody/tr"));
            Console.WriteLine("Number Of rows in this table : " + tr_collections.Count);
            int rows_count = tr_collections.Count;

            //Loop will execute till the last row of table.
            for (int row = 0; row < rows_count; row++)
            {
                //To locate columns(cells) of that specific row.
                IList<IWebElement> Columns_row = tr_collections[row].FindElements(By.XPath("//div[@data-tab = 'second']//tbody/tr/td"));

                //To calculate no of columns(cells) In that specific row.
                int columns_count = Columns_row.Count;
                Console.WriteLine("Number of cells In Row " + row + " are " + columns_count);

                ////Loop will execute till the last cell of that specific row.
                //for (int column = 0; column < columns_count; column++)
                //{
                //    //To retrieve text from that specific cell.
                //    string cellText = Columns_row[column].Text;

                //    Console.WriteLine("Cell Value Of row number " + row + " and column number " + column + " Is " + cellText);
                //    //Assert.That(Columns_row, Is.EqualTo(SkillName));
                //}
            }
        }

        #region Function for entering skills details
        public void EnterSkillDetails(string SkillName, string SkillLevel)
        {
            addNewBtn.Click();
            addSkillInput.SendKeys(SkillName);
            selectSkillLevel.SendKeys(SkillLevel);
            addSkill.Click();
        }
        #endregion

        #region Function for editing existing skills
        public void EditExistingSkills(string ExistingSkill, string SkillName, string SkillLevel)
        {
            //Find the table
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'second']//table"));

            IList<IWebElement> TableTD = Table.FindElements(By.XPath("//div[@data-tab = 'second']//table/tbody/tr/td"));
            Console.WriteLine("Number of td in this table : " + TableTD.Count);
            foreach (var tdElement in TableTD)
            {
                if (tdElement.Text == ExistingSkill)
                {
                    Console.WriteLine("Matched Existing td : " + tdElement.Text);
                    IWebElement ew = tdElement.FindElement(By.XPath("(//i[@class='outline write icon'])[4]"));
                    ew.Click();
                    addSkillInput.Clear();
                    addSkillInput.SendKeys(SkillName);
                    selectSkillLevel.SendKeys(SkillLevel);
                    updateSkill.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for validating error message upon any mandatory field is left empty
        public void ValidateErrorMsg_Skills(string Existingskill, string SkillName, string SkillLevel)
        {
            //Find table object
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'second']"));

            IList<IWebElement> TableTD = Table.FindElements(By.XPath("//div[@data-tab = 'second']//table/tbody/tr/td"));
            foreach (var RowTD in TableTD)
            {
                if (RowTD.Text == Existingskill)
                {
                    Console.WriteLine("Matched Existing td: " + RowTD.Text);
                    IWebElement Clickeditrow = RowTD.FindElement(By.XPath("(//i[@class='outline write icon'])[5]"));
                    Clickeditrow.Click();
                    editSkillInput.Clear();
                    editSkillInput.SendKeys(SkillName);
                    editProficiencyLevel.SendKeys(SkillLevel);
                    updateSkill.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for validating error message
        public void SkillsErrorMsg(string ErrorMessage)
        {
            var Actmessage = Helpers.Driver.driver.FindElement(By.XPath("//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']/div[@class = 'ns-box-inner']")).Text;
            var Expmessage = ErrorMessage;
            var NoMessage = "";
            Console.WriteLine("First Message : " + Expmessage, "Second Message" + NoMessage);
            Assert.That(Actmessage, Is.AnyOf(Expmessage, NoMessage));
        }
        #endregion

        #region Function for validating success message
        public void SkillsSuccessMsg(string SuccessMessage)
        {
            var ActualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
            Console.WriteLine("Message was caught as : " + ActualMsg);
            var ExpectedMsg = SuccessMessage;
            var NoMsg = "";
            Assert.That(ActualMsg, Is.AnyOf(ExpectedMsg, NoMsg));
        }
        #endregion
    }
}
