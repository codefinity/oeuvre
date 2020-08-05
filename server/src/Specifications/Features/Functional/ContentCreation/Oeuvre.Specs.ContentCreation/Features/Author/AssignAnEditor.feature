Feature: AssignAnEditor
	Articles can be assigned an Editor

Scenario: Writers can assign editors to their articles
	Given I have written my Article
	When I want to submit it to an editor
	Then Then I Should be able to search for an Editor
	And Submit my article to the editor
	And My selected Editor should get a notification through an EMail
	And My selected Editor should get a notification on the Web Application











