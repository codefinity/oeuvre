Feature: AssignKeywordsToAnArticle


Scenario: Writers can assign multiple Keywords to an Atricle
	Given I am a Writer of an Article
	When I select multiple Keywords for my Article
	Then The selected Keywords should be assigned to my Article