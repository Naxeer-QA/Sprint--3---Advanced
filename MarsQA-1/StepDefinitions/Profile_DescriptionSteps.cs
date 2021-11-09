using MarsQA_1.SpecflowPages.Pages;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_DescriptionSteps
    {
        Profile_Description profiledesc = new Profile_Description();

        [Given(@"the user clicks on Description tab under profile tab")]
        public void GivenTheUserClicksOnDescriptionTabUnderProfileTab()
        {
            profiledesc.GoToDescriptionTab();
        }

        [Given(@"enters new '(.*)' Description")]
        public void GivenEntersNewDescription(string Description)
        {
            profiledesc.EnterDescription(Description);
        }

        [Then(@"the added '(.*)' description is shown")]
        public void ThenTheAddedDescriptionIsShown(string Description)
        {
            profiledesc.ShowDescription(Description);
        }

        [Given(@"replace the existing details with new '(.*)' Description")]
        public void GivenReplaceTheExistingDetailsWithNewDescription(string Description)
        {
            profiledesc.EnterDescription(Description);
        }

        [Given(@"attempts to save the Description field empty")]
        public void GivenAttemptsToSaveTheDescriptionFieldEmpty()
        {
            profiledesc.EmptyDescription();
        }

        [Then(@"the edited description is shown '(.*)'")]
        public void ThenTheEditedDescriptionIsShown(string Description)
        {
            profiledesc.ShowDescription(Description);
        }
    }
}
