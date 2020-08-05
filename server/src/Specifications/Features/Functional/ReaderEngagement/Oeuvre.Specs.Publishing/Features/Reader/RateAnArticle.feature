Feature: RateAnArticle

Scenario: Reader can rate an Article
	Given Given that I am logged in
	When I try to rate the article 
	Then My Rating should be applied to the article