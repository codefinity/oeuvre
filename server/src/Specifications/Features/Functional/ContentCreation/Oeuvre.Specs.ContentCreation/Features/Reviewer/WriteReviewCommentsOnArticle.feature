Feature: WriteCommentsOnArticle


Scenario: Reviewers can write Review comments on the Article
	Given That I have been Assigned as an Reviewer of an Article by its Author
	When I try to Write review comments on the article
	Then I the comment should be added to the Article 