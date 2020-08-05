Feature: DeleteAnArticle


Scenario: Writers can Delete their Article
	Given I am a Writer of an Article
	And The article is not Published
	When I choose to Delete my Article
	Then The Article should be marked as Deleted