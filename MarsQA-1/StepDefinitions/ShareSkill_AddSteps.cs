using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class ShareSkill_AddSteps
    {
        ShareSkill_Add AddSkill = new ShareSkill_Add();

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
        
        [Then(@"the added service/skill shown on the Listings page")]
        public void ThenTheAddedServiceSkillShownOnTheListingsPage()
        {
            AddSkill.ValidateSuccessMessage();
        }
    }
}
