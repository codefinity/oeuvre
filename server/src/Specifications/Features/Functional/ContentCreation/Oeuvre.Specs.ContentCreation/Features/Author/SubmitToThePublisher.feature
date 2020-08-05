Feature: SubmitToThePublisher

Scenario: Writers can submit their articles for publishing
	Given I have written my Article
	When I try to submit it to for Publishing
	Then Then My Article should be submitted for Publishing
	And The Publisher should get a notification through an EMail
	And The Publisher should get a notification on the Web Application