Feature: WriteCommentsOnArticle


Scenario: Reader can Comment on the Article
	Given Given that I am logged in
	When I comment on an Article
	Then My comment should be applied to the article