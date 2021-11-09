using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_Avail_Hours_TargetSteps
    {
        [Given(@"the trader updates first and last name")]
        public void GivenTheTraderUpdatesFirstAndLastName()
        {
            ProfileUpdate pu = new ProfileUpdate();
            pu.UpdateFirstnLastName();
        }
        
        [Given(@"the trader selects desired option for availability")]
        public void GivenTheTraderSelectsDesiredOptionForAvailability()
        {
            ProfileUpdate pu = new ProfileUpdate();
            pu.UpdateAvailability();
        }
        
        [Given(@"the trader selects desired option for Hours")]
        public void GivenTheTraderSelectsDesiredOptionForHours()
        {
            ProfileUpdate pu = new ProfileUpdate();
            pu.UpdateHours();
        }
        
        [Given(@"the trader selects desired option for EarnTarget")]
        public void GivenTheTraderSelectsDesiredOptionForEarnTarget()
        {
            ProfileUpdate pu = new ProfileUpdate();
            pu.UpdateEarnTarget();
        }
        
        [Then(@"the changes are shown in the title")]
        public void ThenTheChangesAreShownInTheTitle()
        {
            var actualMsg = Helpers.Driver.driver.FindElement(By.XPath("//div[@class = 'title']")).Text;
            Console.WriteLine("The updated details are : " + actualMsg);
            var expectedMsg = "Naxeer Khan";
            Assert.That(actualMsg, Is.EqualTo(expectedMsg));
        }
        
        [Then(@"the successful message is shown")]
        public void ThenTheSuccessfulMessageIsShown()
        {
            ProfileUpdate pu = new ProfileUpdate();
            pu.MessageValication();
        }
    }
}
