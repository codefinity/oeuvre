Feature: ViewPublishedArticle


Scenario: Authenticated Reader can View an Article
	Given Given that I am logged In
	When I try to access an article
	Then I should be able to view It

Scenario: UnAuthenticated Reader can View an Article
	Given Given that I am not logged In
	When I try to access an article
	Then I should be able to view It