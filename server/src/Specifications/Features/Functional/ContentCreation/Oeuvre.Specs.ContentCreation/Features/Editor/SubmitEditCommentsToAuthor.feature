Feature: SubmitEditCommentsToAuthor


Scenario: Editors can select an article for Editing
	Given That I have been Assigned as an Editor of an Article by its Author
	And I have written all my Edit comments for an Article
	When I try to Submit my Edit coments to the Author of the Article
	Then I the edit comments should be submitted to the Author
	And The Author of the Article should get a notification through an EMail
	And The Author of the Article should get a notification on the Web Application