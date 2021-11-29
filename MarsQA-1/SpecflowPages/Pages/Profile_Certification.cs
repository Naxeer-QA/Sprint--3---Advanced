using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Profile_Certification
    {
        public Profile_Certification()
        {
            PageFactory.InitElements(Helpers.Driver.driver, this);
        }

        public class certicationDetails
        {
            public string Certificationname { get; set; }
            public string Certificationfrom { get; set; }
            public int CertificationYear { get; set; }
        }
        #region Certification Web element object
        [FindsBy(How = How.XPath, Using = "//a[@data-tab = 'fourth'][text() = 'Certifications']")]
        [CacheLookup]
        public IWebElement certificationTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//table//div[text()='Add New']")]
        [CacheLookup]
        public IWebElement addNewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'certification-award capitalize']")]
        [CacheLookup]
        public IWebElement AddCertificateInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'received-from capitalize']")]
        [CacheLookup]
        public IWebElement awardedFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui fluid dropdown'][@name = 'certificationYear']")]
        [CacheLookup]
        public IWebElement awardedYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//input[(@type='button')][@value = 'Add']")]
        [CacheLookup]
        public IWebElement addAward { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//input[(@type='button')][@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//i[@class = 'outline write icon']")]
        [CacheLookup]
        public IWebElement editIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//i[@class = 'remove icon']")]
        [CacheLookup]
        public IWebElement removeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'certification-award capitalize']")]
        [CacheLookup]
        public IWebElement editCertificateInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class = 'received-from capitalize']")]
        [CacheLookup]
        public IWebElement editAwardedFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui fluid dropdown'][@name = 'certificationYear']")]
        [CacheLookup]
        public IWebElement editAwardedYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//input[(@type='button')][@value = 'Update']")]
        [CacheLookup]
        public IWebElement updateAward { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']//input[(@type='button')][@value = 'Cancel']")]
        [CacheLookup]
        public IWebElement cancelUpdate { get; set; }
        #endregion

        #region Add Certification
        public void AddCertification()
        {
            certificationTab.Click();
            addNewBtn.Click();
            AddCertificateInput.SendKeys("ISTQB");
            awardedFrom.SendKeys("MindQ");
            SelectElement sElement = new SelectElement(awardedYear);
            sElement.SelectByIndex(4);
            addAward.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        public void EnterCertDetails(string Certificationname, string Certificationfrom/*, int CertificationYear*/)
        {
            AddCertificateInput.SendKeys(Certificationname);
            awardedFrom.SendKeys(Certificationfrom);
            //awardedYear.SendKeys(CertificationYear);
        }

        public void ClearCertDetails(string CertificationName, string CertificationFrom/*, int CertificationYear*/)
        {
            AddCertificateInput.Clear();
            Thread.Sleep(2000);
            awardedFrom.Clear();
            SelectElement sElement = new SelectElement(awardedYear);
            sElement.SelectByIndex(0);
        }

        #region Edit Certification
        public void EditCertificate()
        {
            certificationTab.Click();
            editIcon.Click();
            editCertificateInput.Clear();
            editCertificateInput.SendKeys("Selenium");
            editAwardedFrom.Clear();
            editAwardedFrom.SendKeys("MindQ");
            editAwardedYear.Click();
            SelectElement se = new SelectElement(editAwardedYear);
            se.SelectByIndex(5);
            updateAward.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Attempt to Edit Certification with empty field
        public void EditCertificateWithEmptyField()
        {
            certificationTab.Click();
            editIcon.Click();
            editCertificateInput.Clear();
            editCertificateInput.SendKeys("Selenium");
            editAwardedFrom.Clear();
            editAwardedFrom.SendKeys("MindQ");
            editAwardedYear.Click();
            //SelectElement se = new SelectElement(editAwardedYear);
            //se.SelectByIndex(5);
            updateAward.Click();
            System.Threading.Thread.Sleep(3000);
        }
        #endregion

        #region Delete Certification
        public void DeleteCertificate()
        {
            removeIcon.Click();
        }
        #endregion

        #region Go to Certification tab
        public void GoToCertificationTab()
        {
            Profile_Language lang = new Profile_Language();
            lang.ProfileTab();
            Thread.Sleep(3000);
            certificationTab.Click();
        }
        #endregion

        #region Function for entering Certification details
        public void EnterCertificationDetails(string CertificationName, string CertificationFrom, string CertificationYear)
        {
            addNewBtn.Click();
            AddCertificateInput.SendKeys(CertificationName);
            awardedFrom.SendKeys(CertificationFrom);
            awardedYear.SendKeys(CertificationYear);
            addAward.Click();
        }
        #endregion

        #region Function for validating the award list is displaying
        public void ShowAwardList(string CertificationName)
        {
            //var actualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//tbody/tr/td[1]")).Text;
            //System.Console.WriteLine("Certification as : " + CertificationName);
            //var expectedMsg = CertificationName;
            //var NoMsg = "";
            //Assert.That(actualMsg, Is.AnyOf(expectedMsg, NoMsg));

            //Find the table Object
            IWebElement tableElement = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']"));

            //Collect the table rows in a list
            IList<IWebElement> tr_collections = tableElement.FindElements(By.XPath("//div[@data-tab = 'fourth']//tbody/tr"));
            Console.WriteLine("Number Of rows in this table : " + tr_collections.Count);

            foreach (var trElement in tr_collections)
            {
                IList<IWebElement> td_collections = trElement.FindElements(By.XPath("//div[@data-tab = 'fourth']//tbody/tr/td[1]"));
                Console.WriteLine("Number of Columns are : " + td_collections.Count);

                foreach (var tdElement in td_collections)
                {
                    for (int i = 0; i < td_collections.Count; i++)
                    {
                        if (td_collections[i].Text == CertificationName)
                        {
                            Console.WriteLine("Matched TD is : " + td_collections[i].Text);
                            break;
                        }
                        var Actual = td_collections[i].Text;
                        var expected = CertificationName;
                        Assert.That(Actual, Is.EqualTo(expected));
                    }
                }
            }
        }
        #endregion

        #region Function for editing existing Certification
        public void EditExistingAward(string ExistingAward, string CertificationName, string CertificationFrom, string CertificationYear)
        {
            //Find the table
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//table"));

            IList<IWebElement> TableTD = Table.FindElements(By.XPath("//div[@data-tab = 'fourth']//table/tbody/tr/td"));
            Console.WriteLine("Number of td in this table : " + TableTD.Count);
            foreach (var tdElement in TableTD)
            {
                if (tdElement.Text == ExistingAward)
                {
                    Console.WriteLine("Matched Existing td : " + tdElement.Text);
                    //IWebElement ew = tdElement.FindElement(By.XPath("(//i[@class='outline write icon'])[5]"));
                    //ew.Click();
                    bool x = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//table/tbody/tr/td[contains(., 'C')]/following-sibling::*/span/i[@class = 'outline write icon']")).Displayed;
                    if(x == true)
                    {
                        Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//table/tbody/tr/td[contains(., 'C')]/following-sibling::*/span/i[@class = 'outline write icon']")).Click();
                    }
                    editCertificateInput.Clear();
                    editCertificateInput.SendKeys(CertificationName);
                    editAwardedFrom.Clear();
                    editAwardedFrom.SendKeys(CertificationFrom);
                    editAwardedYear.SendKeys(CertificationYear);
                    updateAward.Click();
                    break;
                }
            }
        }
        #endregion

        #region Function for finding, and removing the award from the list
        public void RemoveAwardFromList(string ExistingAward)
        {
            IWebElement Table = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//table"));

            IList<IWebElement> tdCollection = Table.FindElements(By.XPath("//div[@data-tab = 'fourth']//table/tbody/tr/td"));
            Console.WriteLine("Total TD are : " + tdCollection.Count);
            foreach (var tdElement in tdCollection)
            {
                if (tdElement.Text == ExistingAward)
                {
                    Console.WriteLine("Searched TD is : " + tdElement.Text);
                    //IWebElement removeBtn = Helpers.Driver.driver.FindElement(By.XPath("(//i[@class='remove icon'])[4]"));
                    //removeBtn.Click();
                    var removeXpath = Helpers.Driver.driver.FindElement(By.XPath("//div[@data-tab = 'fourth']//table/tbody/tr/td[contains(., 'Cypress')]/following-sibling::*/span/i[@class = 'remove icon']"));
                    bool x = removeXpath.Displayed;
                    if(x == true)
                    {
                        removeXpath.Click();
                    }
                    break;
                }
            }
        }
        #endregion

    }
}
