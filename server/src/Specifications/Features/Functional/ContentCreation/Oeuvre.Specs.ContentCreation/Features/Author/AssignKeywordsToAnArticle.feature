Feature: AssignKeywordsToAnArticle


Scenario: Writers Assign multiple Keywords To An Atricle
	Given I am a Writer of an Article
	When I Select multiple Keywords for my article
	Then The selected Keywords should be assigned to my article