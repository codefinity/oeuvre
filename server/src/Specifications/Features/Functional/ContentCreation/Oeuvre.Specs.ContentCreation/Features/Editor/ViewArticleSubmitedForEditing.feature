Feature: ViewArticleSubmitedForEditing


Scenario: Editors can view the Articles submitted to them for Editing
	Given That an Author has submitted his article for review
	When I try to view the Article
	Then The article should be visible to me