Feature: RequestAReviewer


Scenario: Authors can request Reviewers to Review their Articles
	Given I have written an Article
	And I want to request a Reviewer to Review my Article
	Then Then I Should be able to select a Reviewer
	And Send an review request to the Reviewer
	And The selected Reviewer should get a notification through an EMail
	And The selected Reviewer should get a notification on the Web Application