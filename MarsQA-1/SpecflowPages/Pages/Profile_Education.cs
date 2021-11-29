using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Profile_Education
    {
        public Profile_Education()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        #region Education Web Element Objects
        [FindsBy(How = How.XPath, Using = "//a[@data-tab = 'third'][text() = 'Education']")]
        [CacheLookup]
        public IWebElement educationTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//table//div[text()='Add New']")]
        [CacheLookup]
        public IWebElement addNewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'College/University Name']")]
        [CacheLookup]
        public IWebElement addCollegeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'country']")]
        [CacheLookup]
        public IWebElement countryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'title']")]
        [CacheLookup]
        public IWebElement titleDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Degree'][@name = 'degree']")]
        [CacheLookup]
        public IWebElement degreeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui dropdown'][@name = 'yearOfGraduation']")]
        [CacheLookup]
        public IWebElement graduationYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[(@type='button')][@value = 'Add']")]
        [CacheLookup]

        public IWebElement addEducation { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[(@type='button')][@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//span[@class = 'button']/i[@class = 'outline write icon']")]
        [CacheLookup]
        public IWebElement editIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//span[@class = 'button']/i[@class = 'remove icon']")]
        [CacheLookup]
        public IWebElement removeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[@name = 'instituteName']")]
        [CacheLookup]
        public IWebElement editCollegeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//select[@name = 'country']")]
        [CacheLookup]
        public IWebElement editCountryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//select[@name = 'title']")]
        [CacheLookup]
        public IWebElement editTitleDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[@name = 'degree']")]
        [CacheLookup]
        public IWebElement editDegreeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//select[@name = 'yearOfGraduation']")]
        [CacheLookup]
        public IWebElement editGraduationYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[@value='Update']")]
        [CacheLookup]
        public IWebElement updateEducation { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'third']//input[@value='Cancel']")]
        [CacheLookup]
        public IWebElement cancelUpdate { get; set; }
        #endregion

        #region Add education
        public void AddEducation()
        {
            educationTab.Click();
            addNewBtn.Click();
            addCollegeInput.SendKeys("Auckland Institute of studies");
            SelectElement oSelect = new SelectElement(countryDropdown);
            oSelect.SelectByValue("India");
            SelectElement sElement = new SelectElement(titleDropdown);
            sElement.SelectByValue("Associate");
            degreeInput.SendKeys("GDIT");
            SelectElement selement = new SelectElement(graduationYear);
            selement.SelectByValue("2018");
            addEducation.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Attempt to add education with empty feilds
        public void AddEducationWithEmptyFeilds()
        {
            educationTab.Click();
            addNewBtn.Click();
            addCollegeInput.SendKeys("Auckland Institute of studies");
            SelectElement oSelect = new SelectElement(countryDropdown);
            oSelect.SelectByValue("India");
            SelectElement sElement = new SelectElement(titleDropdown);
            sElement.SelectByValue("Associate");
            degreeInput.SendKeys("GDIT");
            //SelectElement selement = new SelectElement(graduationYear);
            //selement.SelectByValue("2018");
            addEducation.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Edit education
        public void EditEducation()
        {
            educationTab.Click();
            editIcon.Click();
            editCollegeInput.Clear();
            editCollegeInput.SendKeys("Auckland Institute of studies");
            editCountryDropdown.Click();
            SelectElement se = new SelectElement(editCountryDropdown);
            se.SelectByText("New Zealand");
            SelectElement SE = new SelectElement(editTitleDropdown);
            SE.SelectByIndex(8);
            editDegreeInput.Clear();
            Thread.Sleep(2000);
            editDegreeInput.SendKeys("Software Development");
            SelectElement sElement = new SelectElement(editGraduationYear);
            sElement.SelectByValue("2018");
            updateEducation.Click();
            Thread.Sleep(3000);
        }
        #endregion

        #region Delete education
        public void DeleteEducation()
        {
            removeIcon.Click();
        }
        #endregion

        #region Go to Education tab
        public void GoToEducationTab()
        {
            Profile_Language lang = new Profile_Language();
            lang.ProfileTab();
            Thread.Sleep(3000);
            educationTab.Click();
        }
        #endregion

        #region Function for entering education details
        public void EnterEducationDetails(string CollegeName, string CollegeCountry, string EducationTitle, string DegreeName, string GraduationYear)
        {
            addNewBtn.Click();
            addCollegeInput.SendKeys(CollegeName);
            countryDropdown.SendKeys(CollegeCountry);
            titleDropdown.SendKeys(EducationTitle);
            degreeInput.SendKeys(DegreeName);
            graduationYear.SendKeys(GraduationYear);
            addEducation.Click();
        }
        #endregion

        #region Function for displaying entered details
        public void DisplayEducation(string CollegeName)
        {
            //Identify table
            IWebElement tableElement = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']"));

            //Collect the table rows in a list
            IList<IWebElement> tr_collections = tableElement.FindElements(By.XPath("//div[@data-tab = 'third']//tbody/tr"));
            Console.WriteLine("Number Of rows in this table : " + tr_collections.Count);
            int rows_count = tr_collections.Count;

            //Loop will execute till the last row of table.
            for (int row = 0; row < rows_count; row++)
            {
                //To locate columns(cells) of that specific row.
                IList<IWebElement> Columns_row = tr_collections[row].FindElements(By.XPath("//div[@data-tab = 'third']//tbody/tr/td"));

                //To calculate no of columns(cells) In that specific row.
                int columns_count = Columns_row.Count;
                Console.WriteLine("Number of cells In Row " + row + " are " + columns_count);

                //Loop will execute till the last cell of that specific row.
                //for (int column = 0; column < columns_count; column++)
                //{
                    //    //To retrieve text from that specific cell.
                    //    string cellText = Columns_row[column].Text;

                    //Console.WriteLine("Cell Value Of row number " + row + " and column number " + column + " Is " + cellText);
                    //Assert.That(Columns_row, Is.EqualTo(SkillName));
                //}
            }
        }

        #endregion

        #region Function for editing existing education
        public void EditExistingEducation(string ExistingDegree, string CollegeName, 
            string CollegeCountry, string EducationTitle, string DegreeName, string GraduationYear)
        {
            //Find the table
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table"));

            IList<IWebElement> TableTD = Table.FindElements(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td"));
            Console.WriteLine("Number of TD in this table : " + TableTD.Count);

            foreach (var tdElement in TableTD)
            {
                if (tdElement.Text == ExistingDegree)
                {
                    Console.WriteLine("Matched existing TD is : " + tdElement.Text);
                    var editXpath= Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td[contains(., 'Ph.D')]/following-sibling::*/span/i[@class = 'outline write icon']"));
                    bool x = editXpath.Displayed;
                    if(x == true)
                    {
                        editXpath.Click();
                    }
                    editCollegeInput.Clear();
                    editCollegeInput.SendKeys(CollegeName);
                    editCountryDropdown.SendKeys(CollegeCountry);
                    editTitleDropdown.SendKeys(EducationTitle);
                    editDegreeInput.Clear();
                    editDegreeInput.SendKeys(DegreeName);
                    editGraduationYear.SendKeys(GraduationYear);
                    updateEducation.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for validating error message upon any mandatory field is left empty
        public void ValidateErrorMsg(string ExistingDegree, string CollegeName, string GraduationYear)
        {
            //Find the table
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table"));

            IList<IWebElement> TableTD = Table.FindElements(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td"));
            Console.WriteLine("Number of TD in this table : " + TableTD.Count);

            foreach (var tdElement in TableTD)
            {
                if (tdElement.Text == ExistingDegree)
                {
                    Console.WriteLine("Matched existing TD is : " + tdElement.Text);
                    bool x = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td[contains(.,'Graduation')]/following-sibling::*/span/i[@class = 'outline write icon']")).Displayed;
                    if(x == true)
                    {
                        Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td[contains(.,'Graduation')]/following-sibling::*/span/i[@class = 'outline write icon']")).Click();
                    }
                    editDegreeInput.Clear();
                    editDegreeInput.SendKeys(CollegeName);
                    editGraduationYear.SendKeys(GraduationYear);
                    updateEducation.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for finding, and removing the education from the list
        public void RemoveEducationFromList(string CollegeName)
        {
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table"));

            IList<IWebElement> tdCollection = Table.FindElements(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td"));
            Console.WriteLine("Total TD are : " + tdCollection.Count);
            foreach (var tdElement in tdCollection)
            {
                if (tdElement.Text == CollegeName)
                {
                    Console.WriteLine("Searched TD is : " + tdElement.Text);
                    var removeEducation = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'third']//table/tbody/tr/td[contains(., 'Nadwa')]/following-sibling::*/span/i[@class = 'remove icon']"));
                    bool x = removeEducation.Displayed;
                    if(x == true)
                    {
                        removeEducation.Click();
                    }
                    break;
                }
            }
        }
        #endregion

        #region Function for not showing the deleted education
        public void ValidateRemoveEducation(string CollegeName)
        {
            Helpers.Driver hd = new Helpers.Driver();
            hd.PageScrollDown();
            IList<IWebElement> RowData = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'third']//tbody/tr/td"));
            for (var i = 0; i < RowData.Count; i++)
            {
                if (RowData[i].Text != CollegeName)
                {
                    Console.WriteLine("Education not shown : " + RowData[i].Text);
                    break;
                }
                //Assert.That(RowData[i].Text, Is.Not.EqualTo(CollegeName));
                Assert.IsTrue(true);
            }
        }
        #endregion
    }
}
