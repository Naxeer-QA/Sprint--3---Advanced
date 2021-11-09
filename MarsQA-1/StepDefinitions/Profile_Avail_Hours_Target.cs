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
        ProfileUpdate profileupdate = new ProfileUpdate();

        [Given(@"the trader updates '(.*)' first name and '(.*)' last name")]
        public void GivenTheTraderUpdatesFirstNameAndLastName(string FirstName, string LastName)
        {
            profileupdate.UpdateProfileTitle(FirstName, LastName);
        }

        [Given(@"the trader selects desired option for availability")]
        public void GivenTheTraderSelectsDesiredOptionForAvailability()
        {
            profileupdate.UpdateAvailability();
        }

        [Given(@"the trader selects desired option for Hours")]
        public void GivenTheTraderSelectsDesiredOptionForHours()
        {
            profileupdate.UpdateHours();
        }
        
        [Given(@"the trader selects desired option for EarnTarget")]
        public void GivenTheTraderSelectsDesiredOptionForEarnTarget()
        {
            profileupdate.UpdateEarnTarget();
        }

        [Then(@"the changes are shown in the '(.*)'")]
        public void ThenTheChangesAreShownInThe(string Title)
        {
            profileupdate.UpdatedTitleShown(Title);
        }
    }
}
