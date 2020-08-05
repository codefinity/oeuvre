Feature: Registration

Scenario: New user registers using valid credentials

	Given I am a new user of the product
	When I register the following valid details
	  | name | email            | password    |
	  | mark  | email@gmail.com | Passw0rd123 |
	Then a new account will be created for me
	And I should receive a registration mail containing the email verification link account

Scenario: New user register using Facebook

	Given I am a new user of the product 2
	When I choose to register through my Facebook account
	Then a new account will be created for me 2

Scenario: New user register using Google

	Given I am a new user of the product
	When I choose to register through my Google account
	Then a new account will be created for me

Scenario: New user registers using in-valid credentials

	Given I am a new user of the product
	When I register the following in-valid details
	  | name	| email            | password    |
	  | markX	| emailX@gmail.com | Passw0rd123 |
	Then a new account will be created for me
	And I should receive a registration mail containing the email verification link account


