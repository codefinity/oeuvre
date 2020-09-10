Feature: Registration

Scenario: New Member registers using valid credentials

	Given I am not a User of Oeuvre
	When I register using the following valid details
		|TenantId								|FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		|47d60457-5a80-4c83-96b6-890a5e5e4d22	|Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should be registered on the Oeuvre portal
	And I should receive a registration mail containing the email verification link account 

Scenario: New Member registers using invalid credentials

	Given I am not a User of Oeuvre
	When I register the following invalid details
		| TenantId								| FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		| 47d60457-5a80-4c83-96b6-890a5e5e4d22	| Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then a new account will not be created for me
	And I should not receive a registration mail containing the email verification link account


#Not Complete - Working On Them
Scenario: New Member register using Facebook

	Given I am not a User of Oeuvre 
	When I choose to register through my Facebook account
	Then a new account will be created for me 2

Scenario: New Member register using Google

	Given I am not a User of Oeuvre
	When I choose to register through my Google account
	Then a new account will be created for me




