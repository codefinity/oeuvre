Feature: WriteCommentsOnArticle


Scenario: Reviewers can write Review comments on the Article
	Given That I have been Assigned as an Reviewer of the Article
	When I try to Write review comments on the Article
	Then I the comment should be added to the Article