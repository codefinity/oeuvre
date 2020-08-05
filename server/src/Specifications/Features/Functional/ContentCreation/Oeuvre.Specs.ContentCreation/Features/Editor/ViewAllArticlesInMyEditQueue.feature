Feature: ViewAllArticlesInMyEditQueue

Scenario: Editors can View the list of all their articles for which they have been Assigned as Editors
	Given I have been assigned as Editor for Article(s)
	When I choose to view Articles for which I have been assigned as Editor
	Then Then I should be able to view a list of all my articles for which I have been assigned as Editor