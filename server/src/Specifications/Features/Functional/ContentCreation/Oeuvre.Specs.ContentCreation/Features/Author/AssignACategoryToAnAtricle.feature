Feature: AssignACategoryToAnAtricle


Scenario: Writers Assign A Category To An Atricle
	Given I am a Writer of an Article
	When I Select a category for my article
	Then The selected category should be assigned to my article