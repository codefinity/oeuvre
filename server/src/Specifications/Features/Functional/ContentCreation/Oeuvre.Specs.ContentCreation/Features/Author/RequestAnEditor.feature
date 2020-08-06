Feature: RequestAnEditor
	Author can request one Editor at a time for their Article

Scenario: Authors can request an Editor to edit their articles
	Given I have written an Article
	And an Editor is not assigned to the Article
	And I want to request an Editor to edit my article
	Then Then I Should be able to select an Editor
	And Send an edit request to the Editor
	And The selected Editor should get a notification through an EMail
	And The selected Editor should get a notification on the Web Application


Scenario: Authors can request for only one Editor at a Time
	Given I have written an Article
	And an Editor already assigned to the Article
	And I want to request an Editor to edit my article
	Then Then I Should not be able to assign a Editor to the Article












