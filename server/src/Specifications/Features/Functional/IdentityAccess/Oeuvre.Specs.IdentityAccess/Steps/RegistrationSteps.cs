using System;
using TechTalk.SpecFlow;

namespace Oeuvre.Specs.IdentityAccess.Steps
{
    [Binding]
    public class RegistrationSteps
    {
        [Given(@"I am a new user of the product")]
        public void GivenIAmANewUserOfTheProduct()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I register the following valid details")]
        public void WhenIRegisterTheFollowingValidDetails(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new account will be created for me")]
        public void ThenANewAccountWillBeCreatedForMe()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should receive a registration mail containing the email verification link account")]
        public void ThenIShouldReceiveARegistrationMailContainingTheEmailVerificationLinkAccount()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
