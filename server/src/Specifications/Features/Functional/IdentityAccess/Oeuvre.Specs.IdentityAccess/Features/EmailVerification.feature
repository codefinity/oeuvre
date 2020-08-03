Feature: Email Verification

Scenario: Email verification from the link sent in the EMail

	Given I have registered on Oeuvre portal
	And I have received an EMail verification link in my EMail
	When I click on the EMail verification link
	Then my EMail should be verified on the portal