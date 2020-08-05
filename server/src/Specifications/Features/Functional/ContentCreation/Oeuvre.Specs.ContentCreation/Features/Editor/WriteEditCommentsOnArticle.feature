Feature: WriteEditCommentsOnArticle

Scenario: Editors can write Edit comments on the Article
	Given That I have been Assigned as an Editor of an Article
	When I try to Write edit comments on the article
	Then My Edit comment should be added to the Article