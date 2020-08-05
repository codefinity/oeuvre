using System;
using TechTalk.SpecFlow;

namespace Oeuvre.Specs.IdentityAccess.Steps
{
    [Binding]
    public class RegistrationStepsFacebook
    {
        [Given(@"I am a new user of the product 2")]
        public void GivenIAmANewUserOfTheProduct()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I choose to register through my Facebook account")]
        public void WhenIChooseToRegisterThroughMyFacebookAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new account will be created for me 2")]
        public void ThenANewAccountWillBeCreatedForMe()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
