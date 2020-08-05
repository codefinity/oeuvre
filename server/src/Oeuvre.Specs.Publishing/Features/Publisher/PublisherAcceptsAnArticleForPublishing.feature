Feature: PublisherAcceptsAnArticleForPublishing


Scenario: Publishers accept Articles to be published
	Given The Author has submitted the article for publishing
	When I try to publish the Atricle
	Then The article should be published