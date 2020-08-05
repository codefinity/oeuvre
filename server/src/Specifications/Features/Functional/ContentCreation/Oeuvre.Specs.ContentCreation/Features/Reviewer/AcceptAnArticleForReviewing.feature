Feature: AcceptAnArticleForEditing

Scenario: Reviewers can Accept an Article for Reviewing
	Given That I have been Requested to Review an Article by its Author
	When I try to Accept the Reviewing request
	Then I should be assigned as a Reviewer of the Article
