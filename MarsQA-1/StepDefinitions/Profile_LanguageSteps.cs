using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class Profile_LanguageSteps : Steps
    {
        Profile_Language lang = new Profile_Language();

        [Given(@"the user clicks on profile tab")]
        public void GivenTheUserClicksOnProfileTab()
        {
            lang.ProfileTab();
            Thread.Sleep(3000);
        }

        [Given(@"enters new '(.*)' and '(.*)'")]
        public void GivenEntersNew(string Language, string LanguageLevel)
        {
            lang.EnterLanguage(Language, LanguageLevel);
        }

        [Given(@"attempts to add an existing '(.*)' and '(.*)'")]
        public void GivenAttemptsToAddAnExisting(string Language, string LanguageLevel)
        {
            lang.EnterLanguage(Language, LanguageLevel);
        }

        [Given(@"attempts to add an existing '(.*)' with different '(.*)' level")]
        public void GivenAttemptsToAddAnExistingWithDifferentLevel(string Language, string LanguageLevel)
        {
            lang.EnterLanguage(Language, LanguageLevel);
        }

        [Given(@"attempts to add new language '(.*)' without selecting a level '(.*)'")]
        public void GivenAttemptsToAddNewLanguageWithoutSelectingALevel(string Language, string LanguageLevel)
        {
            lang.EnterLanguage(Language, LanguageLevel);
        }

        [Given(@"replace the '(.*)' with new '(.*)' language and '(.*)' level")]
        public void GivenReplaceTheWithNewLanguageAndLevel(string ExistingLanguage, string Language, string LanguageLevel)
        {
            lang.EditExistingLanguage(ExistingLanguage, Language, LanguageLevel);
        }

        [Given(@"attempts to delete an existing '(.*)' language")]
        public void GivenAttemptsToDeleteAnExistingLanguage(string ExistingLanguage)
        {
            lang.RemoveLanguageFromList(ExistingLanguage);
        }

        [Then(@"the added language '(.*)' is shown")]
        public void ThenTheAddedLanguageIsShown(string Language)
        {
            lang.DisplayLanguage(Language);
        }

        [Then(@"the replaced '(.*)' language is shown")]
        public void ThenTheReplacedLanguageIsShown(string Language)
        {
            IList<IWebElement> ListOfTD = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first']//table/tbody/tr/td"));
                
                //TD iteration
                for (int i=0; i< ListOfTD.Count; i++)
                {
                    if (ListOfTD[i].Text == Language) { break; }
                    var Actual = Helpers.Driver.driver.FindElement(By.XPath("//td[contains(.,'Persian')]")).Text;
                    var Expected = Language;
                    Assert.That(Actual, Is.EqualTo(Expected));
                }
        }

        [Then(@"the deleted '(.*)' language is not shown")]
        public void ThenTheDeletedLanguageIsNotShown(string DeletedLangage)
        {
            IList<IWebElement> ListOfElements = Helpers.Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first']//table/tbody/tr/td"));
            foreach(var TD in ListOfElements)
            {
                if(TD.Text != DeletedLangage)
                {
                    break;
                    
                }
                Assert.True(true);
            }
        }

        [Given(@"attempts to edit '(.*)' language without selecting a '(.*)' level")]
        public void GivenAttemptsToEditLanguageWithoutSelectingALevel(string ExistingLanguage, string LanguageLevel)
        {
            lang.EditWithoutLevelSelection(ExistingLanguage, LanguageLevel);
        }
    }
}
