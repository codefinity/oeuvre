Feature: WriteArticle
	Users should be able to write articles

Scenario: Writer writes a new Article and saves article as draft
	Given I am a registered User
	When I wish to write an article 
	And I wish to save my Article
	Then the Article should be saved as Draft.

