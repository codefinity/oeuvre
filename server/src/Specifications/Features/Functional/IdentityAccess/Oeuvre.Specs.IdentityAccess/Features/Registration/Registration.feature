Feature: Registration

Scenario: New Registrant registers using an EMail Id that does not belong to any Oeuvre user

	Given I have not registered at Oeuvre 
	And there is no other user registered with my EMailId "Mary@TheCarpenters.com"
	When I register using the following valid details
		|TenantId								|FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		|47d60457-5a80-4c83-96b6-890a5e5e4d22	|Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should be a Registrant on Oeuvre
	And I should receive a registration EMail containing an email verification link account

Scenario: New Registrant registers with an EMail Id that belongs to an existing Oeuvre User

	Given That a User with my EMail Id "Mary@TheCarpenters.com" already exists
	When I register with the following details
		|TenantId								| FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		|47d60457-5a80-4c83-96b6-890a5e5e4d22	| Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should not be able to register
	And I should not receive a registration mail containing the email verification link


#Not Complete - Working On Them
Scenario: New Member register using Facebook

	Given I am not a User of Oeuvre 
	When I choose to register through my Facebook account
	Then a new account will be created for me 2

Scenario: New Member register using Google

	Given I am not a User of Oeuvre
	When I choose to register through my Google account
	Then a new account will be created for me




