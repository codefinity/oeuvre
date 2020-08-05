Feature: SaveAnArticle

Scenario: Reader can save an article for later reading
	Given I am a Authenticated Reader
	When I try to save an article
	Then the Article should be saved for me


Scenario: UnAuthenticated Reader can NOT save an article for later reading
	Given I am a UnAuthenticated Reader
	When I try to save an article
	Then the Article should NOT be saved for me