Feature: ApproveAnArticle


Scenario: Approve an Article
	Given That I have been Assigned as an Editor of an Article by its Author
	When I want to approve the article after I am Satisfied of its content
	Then the Article should be marked as Approved
	And the Author should get a notification through EMail
	And the Author should get a notification on the Web Application