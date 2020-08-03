Feature: ResetPassword

Scenario: Reset password on clicking the link in the Reset password EMail sent and supplying the new password and retype password
	Given that I have received the reset password EMail
	When I click on the link
	And supply the new password
	And the retype password
	Then my password should be reset