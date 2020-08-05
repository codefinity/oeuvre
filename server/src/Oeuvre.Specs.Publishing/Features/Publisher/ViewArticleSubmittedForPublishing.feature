Feature: ViewArticleSubmittedForPublishing


Scenario: Publishers can view the Articles submitted to them for editing
	Given That an Author has submitted his article for Publishing
	When I try to view the Article
	Then The article should be visible to me