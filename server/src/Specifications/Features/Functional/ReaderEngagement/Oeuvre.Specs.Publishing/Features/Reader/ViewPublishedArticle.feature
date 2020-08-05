Feature: ViewPublishedArticle


@mytag
Scenario: Reader can View an Article
	Given Given that I am logged In
	When I try to access an article
	Then I should be able to view It