Feature: RequestAReviewer


@mytag
Scenario: Writers can select a reviewers for their Articles
	Given I have written my Article
	When I want to submit it to a Reviewer
	Then Then I Should be able to search for an Reviewer
	And Submit my article to the Reviewer
	And My selected Reviewer should get a notification through an EMail
	And My selected Reviewer should get a notification on the Web Application