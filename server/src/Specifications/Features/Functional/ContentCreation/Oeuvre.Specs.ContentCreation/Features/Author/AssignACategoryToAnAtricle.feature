Feature: AssignACategoryToAnAtricle


Scenario: Writers Assign A Category To their Atricle
	Given I am a Writer of an Article
	When I select a Category for my Article
	Then The selected Category should be assigned to my Article