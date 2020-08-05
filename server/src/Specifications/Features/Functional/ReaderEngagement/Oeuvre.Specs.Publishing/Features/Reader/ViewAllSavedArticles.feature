Feature: ViewAllSavedArticles


Scenario: Readers Should be able to see the list of all the Saved Article
	Given I am a Authenticated Reader
	When I try see the list of all my saved Articles
	Then I should see the list of all my saved Articles

Scenario: UnAuthenticated Readers Should NOT be able to see the list of all the Saved Article
	Given I am a UnAuthenticated Reader
	When I try see the list of all my saved Articles
	Then I should NOT see the list of all my saved Articles