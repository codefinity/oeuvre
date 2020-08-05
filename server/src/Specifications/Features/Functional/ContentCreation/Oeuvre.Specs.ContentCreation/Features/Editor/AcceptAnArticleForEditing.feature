Feature: AcceptAnArticleForEditing

Scenario: Editors can accept an article for Editing
	Given That I have been Requested to Edit an Article by its Author
	When I try to Accept the Editing request
	Then I should be assigned as an Editor of the Article
