using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class ShareSkill_AddSteps
    {
        ShareSkill_Add AddSkill = new ShareSkill_Add();
        ManageListing manageskilllist = new ManageListing();

        [Given(@"the user is on a shareskill page")]
        public void GivenTheUserIsOnAShareskillPage()
        {
            AddSkill.GoToShareSkillPage();
        }
        
        [When(@"the user adds skill along with all the mandatory relevant details")]
        public void WhenTheUserAddsSkillAlongWithAllTheMandatoryRelevantDetails()
        {
            AddSkill.EnterSkillRelevantItems();
        }

        [Then(@"the added service/skill is listed on the Listings page")]
        public void ThenTheAddedServiceSkillIsListedOnTheListingsPage()
        {
            AddSkill.ValidateAddedSkillIsListed();
        }


        [Given(@"the user on a listings page")]
        public void GivenTheUserOnAListingsPage()
        {
            manageskilllist.GoToListingsTab();
        }

        [When(@"the user clicks on edit icon for any existing lisings")]
        public void WhenTheUserClicksOnEditIconForAnyExistingLisings()
        {
            manageskilllist.EditListing();
        }

        [Then(@"the shareSkill page is shown")]
        public void ThenTheShareSkillPageIsShown()
        {
            string url = Helpers.Driver.driver.Url;
            Assert.AreEqual(url, "http://localhost:5000/Home/ServiceListing/?id=618d101726489400012f84a3");
        }

        [When(@"the user updates skill along with all the mandatory relevant details")]
        public void WhenTheUserUpdatesSkillAlongWithAllTheMandatoryRelevantDetails()
        {
            AddSkill.UpdateSkill();
        }

        [Then(@"the updated service/skill shown on the Listings page")]
        public void ThenTheUpdatedServiceSkillShownOnTheListingsPage()
        {
            AddSkill.ValidateUpdatedSkillIsListed();
        }

        [When(@"the user clicks on remove icon")]
        public void WhenTheUserClicksOnRemoveIcon()
        {
            manageskilllist.RemoveSkills();
        }

        [When(@"selects '(.*)' to delete the skill")]
        public void WhenSelectsToDeleteTheSkill(string p0)
        {
            //manageskilllist.ClickCancelRemove();
            manageskilllist.ConfirmRemove();
        }
    }
}
