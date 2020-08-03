Feature: Authentication

Scenario: Authentication with valid credentials should allow logging in
	Given I am logged out
	When I try to authenticate using valid
		| name | email            | password    |
		| mark  | email@gmail.com | Passw0rd123 |
	Then I should be authenticated.

Scenario: Authentication with in-valid credentials should not allow logging in
	Given I am logged out
	When I try to authenticate using valid
		| name | email            | password    |
		| mark  | email@gmail.com | Passw0rd123 |
	Then I should be authenticated.


