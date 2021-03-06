﻿Feature: ForgotPasswordRequest
	As a Member who has forgotten his Oeuvre password
	In order to login again
	I want to be able to reset my password

Scenario: Send reset password link when the EMail provided is correct
	Given I am a regestered Member
	And For reseting my password I am asked my EMail-Id I had provided at the time of registration
	When I provide my Correct EMail-Id
	Then I should get the Password Reset Link in my email

Scenario: Do not Send reset password link when the EMail provided is in-correct
	Given I am a regestered Member
	And For reseting my password I am asked my EMail-Id at the time of registration
	When I provide my InCorrect EMail-Id
	Then No Email should be sent