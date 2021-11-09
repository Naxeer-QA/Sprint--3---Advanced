using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static MarsQA_1.SpecflowPages.Pages.Profile_Certification;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_CertificationSteps
    {
        Profile_Certification profilecert = new Profile_Certification();

        [Given(@"the user clicks on Certification tab under profile tab")]
        public void GivenTheUserClicksOnCertificationTabUnderProfileTab()
        {
            profilecert.GoToCertificationTab();
        }

        [Given(@"enters new Certification '(.*)', '(.*)', '(.*)' details")]
        public void GivenEntersNewCertificationDetails(string CertificationName, string CertificationFrom, string CertificationYear)
        {
            profilecert.EnterCertificationDetails(CertificationName, CertificationFrom, CertificationYear);
        }

        [Then(@"the added '(.*)' Certification is shown")]
        public void ThenTheAddedCertificationIsShown(string CertificationName)
        {
            profilecert.ShowAwardList(CertificationName);
        }

        [Given(@"attempts to add an existing '(.*)', '(.*)', '(.*)' Certification")]
        public void GivenAttemptsToAddAnExistingCertification(string CertificationName, string CertificationFrom, string CertificationYear)
        {
            profilecert.EnterCertificationDetails(CertificationName, CertificationFrom, CertificationYear);
        }

        [Given(@"attempts to add a new Certification '(.*)', '(.*)' with any mandatory field '(.*)' left empty")]
        public void GivenAttemptsToAddANewCertificationWithAnyMandatoryFieldLeftEmpty(string CertificationName, string CertificationFrom, string CertificationYear)
        {
            profilecert.EnterCertificationDetails(CertificationName, CertificationFrom, CertificationYear);
        }

        [Given(@"replace the existing '(.*)' certification with new '(.*)', '(.*)', '(.*)' details")]
        public void GivenReplaceTheExistingCertificationWithNewDetails(string ExistingAward, string CertificationName, string CertificationFrom, string CertificationYear)
        {
            profilecert.EditExistingAward(ExistingAward, CertificationName, CertificationFrom, CertificationYear);
        }

        [Given(@"attempts to replace existing '(.*)' Certification with new '(.*)', '(.*)' award with any mandatory field  '(.*)' left empty")]
        public void GivenAttemptsToReplaceExistingCertificationWithNewAwardWithAnyMandatoryFieldLeftEmpty(string ExistingAward, string CertificationName, string CertificationFrom, string CertificationYear)
        {
            profilecert.EditExistingAward(ExistingAward, CertificationName, CertificationFrom, CertificationYear);
        }

        [Given(@"attempts to delete an existing '(.*)' Certification")]
        public void GivenAttemptsToDeleteAnExistingCertification(string ExistingAward)
        {
            profilecert.RemoveAwardFromList(ExistingAward);
        }

        [Then(@"the deleted Certification '(.*)' is not shown in my listings")]
        public void ThenTheDeletedCertificationIsNotShownInMyListings(string ExistingAward)
        {
            Helpers.Driver hd = new Helpers.Driver();
            hd.PageScrollDown();
            IList<IWebElement> RowData = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'fourth']//tbody/tr[1]/td[1]"));
            for (var i = 0; i < RowData.Count; i++)
            {
                break;
                //Console.WriteLine(RowData[i].Text);
            }
            Assert.That(RowData, Is.Not.EqualTo(ExistingAward));
        }

    }
}
