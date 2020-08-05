Feature: ViewArticleSubmitedForEditing


Scenario: Editors can view the articles submitted to them for editing
	Given That an Author has submitted his article for review
	When I try to view the Article
	Then The article should be visible to me