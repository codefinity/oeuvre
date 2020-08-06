Feature: ViewAllArticlesInThePublishQueue

Scenario: Publishers can View the list of all their articles Authors have submitted for publishing
	Given The Author(s) have submitted the Article for publishing 
	When I choose to view Articles submitted by all the authors
	Then Then I should be able to view a list of all my articles submitted for publishing