Feature: UserProfile


Scenario: Member can Update the User Profile
	Given I am a Registered Member
	When I try to update my User Profile
	Then My user Profile should be Updated