using MarsQA_1.SpecflowPages.Pages;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_EducationSteps
    {
        Profile_Education profile_education = new Profile_Education();

        [Given(@"the user clicks on Education tab under profile tab")]
        public void GivenTheUserClicksOnEducationTabUnderProfileTab()
        {
            profile_education.GoToEducationTab();
        }

        [Given(@"enters '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' Education details")]
        public void GivenEntersEducationDetails(string CollegeName, string CollegeCountry, 
            string EducationTitle, string DegreeName, string GraduationYear)
        {
            profile_education.EnterEducationDetails(
                CollegeName, CollegeCountry, EducationTitle, DegreeName, GraduationYear);
        }

        [Then(@"the added '(.*)' Education is shown")]
        public void ThenTheAddedEducationIsShown(string CollegeName)
        {
            profile_education.DisplayEducation(CollegeName);
        }

        [Given(@"enters an existing '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' Education details")]
        public void GivenEntersAnExistingEducationDetails(string CollegeName, string CollegeCountry, 
            string EducationTitle, string DegreeName, string GraduationYear)
        {
            profile_education.EnterEducationDetails(
                CollegeName, CollegeCountry, EducationTitle, DegreeName, GraduationYear);
        }

        [Given(@"attempts to add a new Education '(.*)', '(.*)' with any mandatory field left empty")]
        public void GivenAttemptsToAddANewEducationWithAnyMandatoryFieldLeftEmpty(string CollegeName, 
            string CollegeCountry)
        {
            profile_education.addNewBtn.Click();
            profile_education.addCollegeInput.SendKeys(CollegeName);
            profile_education.countryDropdown.SendKeys(CollegeCountry);
            profile_education.addEducation.Click();
        }

        [Given(@"replace the existing '(.*)' details with new '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' Education details")]
        public void GivenReplaceTheExistingDetailsWithNewEducationDetails(
            string ExistingDegree, string CollegeName, string CollegeCountry, string EducationTitle, 
            string DegreeName, string GraduationYear)
        {
            profile_education.EditExistingEducation(ExistingDegree, CollegeName, CollegeCountry, EducationTitle,
                DegreeName, GraduationYear);
        }

        [Then(@"the edited Education '(.*)' is shown")]
        public void ThenTheEditedEducationIsShown(string CollegeName)
        {
            profile_education.DisplayEducation(CollegeName);
        }

        [Given(@"attempts to edit an existing '(.*)' Education '(.*)' with any mandatory field '(.*)'left empty")]
        public void GivenAttemptsToEditAnExistingEducationWithAnyMandatoryFieldLeftEmpty(string ExistingDegree, string CollegeName, string GraduationYear)
        {
            profile_education.ValidateErrorMsg(ExistingDegree, CollegeName, GraduationYear);
        }

        [Given(@"attempts to delete an existing '(.*)' Education")]
        public void GivenAttemptsToDeleteAnExistingEducation(string CollegeName)
        {
            profile_education.RemoveEducationFromList(CollegeName);
        }

        [Then(@"the deleted Education '(.*)' is not shown in my listings")]
        public void ThenTheDeletedEducationIsNotShownInMyListings(string CollegeName)
        {
            profile_education.ValidateRemoveEducation(CollegeName);
        }

    }
}
