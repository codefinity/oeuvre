Feature: SubmitEditCommentsToAuthor


Scenario: Reviewers can send Review comments to the Author 
	Given That I have been Assigned as an Reviewer of the Article
	And I have written all my Review comments for the Article
	When I try to Submit my Review coments to the Author of the Article
	Then I the Review comments should be submitted to the Author
	And The Author of the Article should get a notification through an EMail
	And The Author of the Article should get a notification on the Web Application