using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    class Login
    {
        
        [Given(@"I login to the website Successfully")]
        public void GivenILoginToTheWebsiteSuccessfully()
        {
            System.Console.WriteLine("Closing browser");
        }

    }
}
