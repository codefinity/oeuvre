Feature: SelectAArticleForEditing

Scenario: Editors can select an article for Editing
	Given That I have been Assigned as an Editor of an Article by its Author
	When I try to Edit a particular Article
	Then I should be able to edit it
