Feature: RateAnArticle

Scenario: Authenticated Reader can rate an Article
	Given Given that I am logged in
	When I try to rate the article 
	Then My Rating should be applied to the article

Scenario: UnAuthenticated Reader cannot rate an Article
	Given Given that I am not logged in
	When I try to rate the article 
	Then My Rating should not be applied to the article