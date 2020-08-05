Feature: SubmitArticleEditsToEditor


Scenario: After receiving the edit comments from the Editor, the Author can submit his Edits to Editor
	Given I have implemented the editing recommendations of the Editor
	When I try to submit the the Edits
	Then The new version of the Article should be submitted to the Editor
	And the version number of the article will be incremented by 1
	And The selected Editor should get a notification through an EMail
	And The selected Editor should get a notification on the Web Application