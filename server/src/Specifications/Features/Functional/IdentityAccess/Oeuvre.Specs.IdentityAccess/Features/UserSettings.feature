﻿Feature: UserSettings



Scenario: Member can update his Settings
	Given I am a Registered Member
	When I try to update my Settings
	Then My user Settings should be updated