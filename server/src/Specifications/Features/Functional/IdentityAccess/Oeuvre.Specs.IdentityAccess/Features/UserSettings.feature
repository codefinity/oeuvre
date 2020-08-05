Feature: UserSettings



Scenario: User can update his Settings
	Given I am a Registered User
	When I try to update my Settings
	Then My user Settings should be updated