Feature: DeleteAnArticle


Scenario: Writers can delete their article
	Given I am a Writer of an Article
	When I choose to delete my Article
	Then The Article should be deleted