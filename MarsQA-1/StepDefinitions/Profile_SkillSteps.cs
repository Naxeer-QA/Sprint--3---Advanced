using MarsQA_1.SpecflowPages.Pages;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_SkillSteps : Steps
    {
        Profile_Skills profileskills = new Profile_Skills();

        [Given(@"the user clicks on Skills tab under profile tab")]
        public void GivenTheUserClicksOnSkillsTabUnderProfileTab()
        {
            profileskills.GoToSkillsTab();
        }

        [Given(@"enters '(.*)' and '(.*)'")]
        public void GivenEntersAnd(string SkillName, string SkillLevel)
        {
            profileskills.EnterSkillDetails(SkillName, SkillLevel);
        }

        [Given(@"enters an existing '(.*)' Skill and '(.*)'")]
        public void GivenEntersAnExistingSkillAnd(string SkillName, string SkillLevel)
        {
            profileskills.EnterSkillDetails(SkillName, SkillLevel);
        }

        [Given(@"enters an existing '(.*)' Skill with different '(.*)' level")]
        public void GivenEntersAnExistingSkillWithDifferentLevel(string SkillName, string SkillLevel)
        {
            profileskills.EnterSkillDetails(SkillName, SkillLevel);
        }

        [Then(@"the added '(.*)' is shown")]
        public void ThenTheaddedIsShown(string SkillName)
        {
            profileskills.DisplaySkills(SkillName);
        }

        [Then(@"the toast message '(.*)' is shown")]
        public void ThenTheToastMessageIsShown(string SuccessMessage)
        {
            profileskills.SkillsSuccessMsg(SuccessMessage);
        }

        [Then(@"the user should see the'(.*)' message displayed on my listings")]
        public void ThenTheUserShouldSeeTheMessageDisplayedOnMyListings(string ErrorMessage)
        {
            profileskills.SkillsErrorMsg(ErrorMessage);
        }

        [Given(@"adds new '(.*)' skill without selecting level '(.*)'")]
        public void GivenAddsNewSkillWithoutSelectingLevel(string SkillName, string SkillLevel)
        {
            profileskills.EnterSkillDetails(SkillName, SkillLevel);
        }

        [Given(@"replace the '(.*)' with new '(.*)' Skill and '(.*)' level")]
        public void GivenReplaceTheWithNewSkillAndLevel(string ExistingSkill, string SkillName, string SkillLevel)
        {
            profileskills.EditExistingSkills(ExistingSkill, SkillName, SkillLevel);
        }

        [Given(@"replaces '(.*)' with new '(.*)' skill without selecting '(.*)' level")]
        public void GivenReplacesWithNewSkillWithoutSelectingLevel(string Existingskill, string SkillName, string SkillLevel)
        {
            profileskills.ValidateErrorMsg_Skills(Existingskill, SkillName, SkillLevel);
        }

        [Given(@"attempts to delete '(.*)' skill")]
        public void GivenAttemptsToDeleteSkill(string SkillName)
        {
            profileskills.RemoveSkillFromList(SkillName);
        }
    }
}
