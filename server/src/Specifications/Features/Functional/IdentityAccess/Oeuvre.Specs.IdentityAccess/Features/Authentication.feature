Feature: Authentication

Scenario: Authentication with valid credentials should allow logging in
	Given I am logged out
	When I try to authenticate using valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should be authenticated

Scenario: Authentication with in-valid credentials should not allow logging in
	Given I am logged out
	When I try to authenticate using in-valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should not be authenticated

Scenario: Authentication should not be allowed if the User has not verified his EMail using the link sent to him in the EMail 
	Given I am logged out
	And I have Registered on the Oeuvre Portal
	When I try to authenticate using valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should not be authenticated


