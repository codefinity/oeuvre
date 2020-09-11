using System;
using TechTalk.SpecFlow;

namespace Oeuvre.Specs.IdentityAccess.Steps.Registration
{
    [Binding]
    public class RegistrationSteps
    {
        [Given(@"I am not a User of Oeuvre")]
        public void GivenIAmNotAUserOfOeuvre()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I register the following invalid details")]
        public void WhenIRegisterTheFollowingInvalidDetails(Table table)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new account will not be created for me")]
        public void ThenANewAccountWillNotBeCreatedForMe()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should not receive a registration mail containing the email verification link account")]
        public void ThenIShouldNotReceiveARegistrationMailContainingTheEmailVerificationLinkAccount()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
