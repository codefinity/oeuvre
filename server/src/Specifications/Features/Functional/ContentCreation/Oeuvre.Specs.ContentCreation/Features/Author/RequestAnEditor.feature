Feature: RequestAnEditor
	Author can request an Editor for their Article

Scenario: Authors can request Editors to edit their articles
	Given I have written an Article
	And I want to request an Editor to edit my article
	Then Then I Should be able to select an Editor
	And Send an edit request to the Editor
	And The selected Editor should get a notification through an EMail
	And The selected Editor should get a notification on the Web Application











