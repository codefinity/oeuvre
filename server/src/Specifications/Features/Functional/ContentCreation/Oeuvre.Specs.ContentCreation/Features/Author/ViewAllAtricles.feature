Feature: ViewAllAtricles
		Authors can View a list of all their articles

Scenario: Authors can View a list of all their articles
	Given I have written Article(s)
	When I choose to view all my Articles
	Then Then I should be able to view a list of all my articles