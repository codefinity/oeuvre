# Oeuvre

**The Theater Of Evolutionary Architecture**

### Oeuvre
/ˈəːvr(ə)/

**Pronounced as:**  *uh·vruh* | **noun:** oeuvre; **plural noun**: oeuvres

**Meaning:** The body of work of a painter, composer, or author. A work of art, music, or literature.

## A Note

This project is in design and analysis phase. Please feel free to go through the code and if you have any Questions or Suggestions, you can use the [Issues](https://github.com/codefinity/oeuvre/issues) tab. 

## News

- Migration from Postgres to Sql Server in progress on branch evolution-one-migration-sqlserver. Merged to branch evolution-one.
- Integration Tests Written.
- IdentityAccess Module appears to be stable.
- Documenting the process.

## Table of Contents

[TOC might not work - Sections under constant re-arrangement]

[1. Introducing Oeuvre](#Introducing-Oeuvre)

[2. Setup Instructions](#Setup-Instructions)

[3. A Need for a Project Like Oeuvre](#A-Need-for-a-Project-Like-Oeuvre)

[4. Development Methodologies](#Development-Methodologies)

[5. Testing and Code Coverage](#Testing-and-Code-Coverage)

[6. Requirement Discussion](#Requirement-Discussion)

[8. Technology Stack](#Technology-Stack)

[9. Requirement Analysis](#Requirement-Analysis)

[10. Features](#Features)

[11. Analysis and Design](#Analysis-and-Design)

[12. Test Driven Design Methodology](#Test-Driven-Design-Methodology)

[13. Inspiration](#Inspiration)

[14. Issue Resolutions and Workarounds](#Issue-Resolutions-and-Workarounds)

## Introducing Oeuvre

Oeuvre is a social article publishing portal that enables users to write and publish and share their articles. 
At some level Oeuvre is an Experimental Test-Bed for Evolutionary Architecture. This project will also demonstrate how quickly and efficiently DDD aligns to the changes in business.

The technology stack used is .Net, but the concept can be applied to all the programming language that supports OOPS.

## Setup Instructions

SetUp instructions for this project can be found [here](SETUP.md).

## A Need for a Project Like Oeuvre

**Oeuvre is not a demonstration, it is Software Evolution in motion.**

[Section Under Development]

It is a well known fact, often inconvenient, that in the long run the many of the projects become unmaintainable. New requirements come in, new capabilities are demanded due to changes in the market, the technology landscape becomes better, and the softwares is expected to accommodate these things without software rewrites.

Oeuvre is a quest to find answers to whether the software can be constructed in such a way that it evolves with new requirements over time.

### The Architectral Quanta

### How Evolution Works

### How To Make Principles Of Evolution Work for Architecture

[Diagram to apply evolution to code - Gherkin - Fitness Function - Domain Change - Test]


### Importance of Boundaries

https://medium.com/swlh/all-you-might-really-need-is-a-monolith-disguised-as-microservices-4b099da3fa8f

### Requirement is the King

Key to a good architecture is getting requirements right. Requirement is where everything starts from.

### Fitness Functions Used

#### Arch Unit


#### BDD


#### Integration Tests


### Quantas Used In This Architecture

#### Command


#### Query


#### Domain Events


#### Aggregates


#### Modules/Bonded Contexts - Deployment Quantas







## Development Methodologies

#### Architecture Decision Logs

[Michael Nygard's template](https://cognitect.com/blog/2011/11/15/documenting-architecture-decisions) will be used to record Architectural Decisions. The logs can be found in this [folder](design/architecture-decision-logs). 

#### Event Storming


#### Behaviour Driven Development


#### Test Driven Development


#### Modular Monolith


#### Domain Driven Design


#### Command Query Responsibility Segregation (CQRS)


#### Event Driven Architecture


#### The Reactive Manifesto


#### Continuous Integration and Deployment (CI/CD)


#### Code Coverage



## Requirement Discussion








## Technology Stack

#### Discussion


#### Expectation


#### Selection


## Requirement Analysis and Design


### Event Stroming Boards


#### Big Picture Event-Storming 

![](design/EventStorming-IdentityAccess-BigPictureEventStorming.png)

#### Design Level  Event-Storming 

![](design/EventStorming-IdentityAccess-DesignLevelEventStorming.png)


#### Boundary Analysis


#### Process Discovery


#### Ubiquitous Language Discovery

##### Identity Access

```text
Registrant : 	One who has just registred to Oeuvre Portal through registration page, but will not qualify 
		as a user unless they verify their EMail through the link sent in his EMail.

User : 		One who has registered and verified his EMail. 

```


#### Example Mapping


#### Arranged Design Level  Event-Storming 

![](design/EventStorming-IdentityAccess-DesignLevelEventStorming-Arranged.png)


##### Miro - Section to be removed later

- [Big Picture Event Sorming](https://miro.com/app/board/o9J_knjMlGU=/)
- [Design Level Event Storming](https://miro.com/app/board/o9J_kniwpWE=/)
- [More Design Level Event Storming](https://miro.com/app/board/o9J_knmsmnU=/)

## Feature Files Creation

##### [Registration.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Registration.feature)
```gherkin

Feature: Registration

Scenario: New Registrant registers using an EMail Id that does not belong to any Oeuvre user

	Given I have not registered at Oeuvre 
	And there is no other user registered with my EMailId "Mary@TheCarpenters.com"
	When I register using the following valid details
		|TenantId				|FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		|47d60457-5a80-4c83-96b6-890a5e5e4d22	|Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should be a Registrant on Oeuvre
	And I should receive a registration EMail containing an email verification link account

Scenario: New Registrant registers with an EMail Id that belongs to an existing Oeuvre User

	Given That a User with my EMail Id "Mary@TheCarpenters.com" already exists
	When I register with the following details
		| TenantId				| FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		| 47d60457-5a80-4c83-96b6-890a5e5e4d22	| Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should not be able to register
	And I should not receive a registration mail containing the email verification link


#Not Complete - Working On Them
Scenario: New Member register using Facebook

	Given I am not a User of Oeuvre 
	When I choose to register through my Facebook account
	Then a new account will be created for me 2

Scenario: New Member register using Google

	Given I am not a User of Oeuvre
	When I choose to register through my Google account
	Then a new account will be created for me


```

##### [EmailVerification.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/EmailVerification.feature)
```gherkin

Feature: Email Verification

Scenario: Email verification from the link sent in the EMail

	Given I have registered on Oeuvre portal
	And I have received an EMail verification link in my EMail
	When I click on the EMail verification link
	Then my EMail should be verified by the Oeuvre portal

```

##### [Authentication.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Authentication.feature)
```gherkin

Feature: Authentication

Scenario: Authentication with valid credentials should allow logging in
	Given I am logged out
	When I try to authenticate using valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should be authenticated

Scenario: Authentication with in-valid credentials should not allow logging in
	Given I am logged out
	When I try to authenticate using in-valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should not be authenticated

Scenario: Authentication should not be allowed if the User has not verified his EMail using the link sent to him in the EMail 
	Given I am logged out
	And I have Registered on the Oeuvre Portal
	When I try to authenticate using valid
		|email				| password    |
		|email@gmail.com	| Passw0rd123 |
	Then I should not be authenticated

```

##### [DeActivateUser.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/DeActivateUser.feature)

```gherkin

Feature: DeActivate A User

Scenario: Admin can DeActivate a User
	Given I an Admin of Oeuvre Portal
	When I DeActivate a User
	Then that user should not be allowed to login

Scenario: Admin can DeActivate a User while the user is Logged-In
	Given I an Admin of Oeuvre Portal
	When I DeActivate a User who is already Logged-In
	Then the user should be logged-out
	And that user should not be allowed to login again

```

##### [ActivateUser.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/ActivateUser.feature)

```gherkin

Feature: Admin can Activate A DeActivated User

Scenario: Admin can Activate a User who is DeActivated
	Given I am the Admin of Oeuvre Portal
	And a User is DeActivated
	When I Activate that User
	Then that user should be allowed to login

```

##### [ForgotPasswordRequest.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/ForgotPasswordRequest.feature)
```gherkin

Feature: ForgotPasswordRequest
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

```

##### [ResetPassword.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/ResetPassword.feature)

```gherkin

Feature: ResetPassword

Scenario: Reset password on clicking the link in the Reset password EMail sent and supplying the new password and retype password
	Given that I have received the reset password EMail with the reset link
	When I click on the link
	And supply the new password
	And the retype password
	Then my password should be reset to the new password

```

##### [UserProfile.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/UserProfile.feature)
```gherkin

Feature: UserProfile

Scenario: Member can Update the User Profile
	Given I am a Registered User
	When I try to update my User Profile
	Then My user Profile should be Updated

```

##### [UserSettings.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/UserSettings.feature)

```gherkin

Feature: UserSettings

Scenario: Member can update his Settings
	Given I am a Registered User
	When I try to update my Settings
	Then My user Settings should be updated

```

## API Design

<!---Table Begin-->

|Feature					|URL											|Method						|Request JSON																																																							|Response JSON					|Success Code					|Failure Code
|:--						|:---											|:---						|:---																																																									|:---							|:---							|:---
|**Register**				|http://localhost:5000/identityaccess/register	|POST						|{TenantId" : "47d60457-5a80-4c83-96b6-890a5e5e4d22", "FirstName" : "Mary", "LastName" : "Carpenter", "Password" : "topoftheworld", "MobileNoCountryCode" : "+1", "MobileNumber" : "4387790052", "EMail" : "Mary@TheCarpenters.com" }	|								|200							|400											
|**Confirm Registration**	|												|							|																																																										|								|								|



<!---Table End-->


## Creating Fitness Functions

Test Driven Design will be followed

#### Architecture/Structural Integrity Fitness

Arch Unit Tests

#### Domain Fitness

Write Domain Unit Tests

#### BoundedContext/Module Fitness

Write Module Integration Unit Tests

#### Application Process Fitness

Write Application Integration Test


## Development

#### Event Storming - Component Map

<!---Table Begin-->
|User Story			|Feature																																						|View 					|Command 																																													|Rules	 																																																																											|Aggregate 																														|Event 																																																																																																																																																			|Policy									|Command 																																																												| Aggregate 																													|Event
|:---         		|:---																																							|:---					|:---          																																												|:--- 																																																																												|:---																															|:---																																																																																																																																																			|:---									|:---																																																													|:---																															|:---
|**Registration**  	|Feature File																																					|Registration Form		|Register    																																												|1. EMail Id must be unique																																																																							|Registration																													|User Registered																																																																																																																																																|Email with confirm URL must be sent	|Send Registration Email																																																								|Registration																													|User Verification Email Sent
|**Components** 	|[Registration.feature](server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Registration/Registration.feature)	|						|[RegisterNewUserCommandHandler.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Application/UserRegistrations/RegisterNewUser/RegisterNewUserCommandHandler.cs)  		|[Registration.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Domain/UserRegistrations/Registration.cs), [UserEmailIdLoginMustBeUniqueRule.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Domain/UserRegistrations/Rules/UserEmailIdLoginMustBeUniqueRule.cs)				|[Registration.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Domain/UserRegistrations/Registration.cs)	|[Registration.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Domain/UserRegistrations/Registration.cs), [NewUserRegisteredEnqueueEmailConfirmationHandler.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Application/UserRegistrations/RegisterNewUser/NewUserRegisteredEnqueueEmailConfirmationHandler.cs), [SendUserRegistrationConfirmationEmailCommandHandler.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Application/UserRegistrations/SendUserRegistrationConfirmationEmail/SendUserRegistrationConfirmationEmailCommandHandler.cs)  	|										|[SendUserRegistrationConfirmationEmailCommandHandler.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Application/UserRegistrations/SendUserRegistrationConfirmationEmail/SendUserRegistrationConfirmationEmailCommandHandler.cs)	|[Registration.cs](server/src/Modules/IdentityAccess/Oeuvre.Modules.IdentityAccess.Domain/UserRegistrations/Registration.cs)	|Not Implemented - Not Required
|**Tests**			|																																								|						|																																															|																																																																													|																																|																																																																																																																																																				|										|																																																														|																																|																		


<!---Table End-->



## Testing and Code Coverage

All **Integration Tests** are done on a separate database "oeuvre_integration_testing". All the tables and seed data are added before the test and removed after the tests. 
Instructions for running tests and code coverage can be found [here](TESTS.md).

## Continuous Integration and Deployment (CI/CD)


## Inspiration

#### Special Thanks

- [kgrzybek/modular-monolith-with-ddd](https://github.com/kgrzybek/modular-monolith-with-ddd)

#### Evolutionary Architectures

##### Talks
- [Talks](http://evolutionaryarchitecture.com/talks.html)
- [Evolutionary Architecture with Patrick Kua](https://www.youtube.com/watch?v=7e6Ww8b2hzQ)
- [Manchester Geek Nights - Principles and Techniques of Evolutionary Architecture with Dr. Rebecca Parsons](https://www.youtube.com/watch?v=ZIsgHs0w44Y)
- [Principles of Evolutionary Architecture - Rebecca Parsons](https://www.youtube.com/watch?v=T1kwuP_JWrk)
- [Microservices & Evolutionary Architecture - Rebecca Parsons](https://www.youtube.com/watch?v=WhHtVUlJNA0)
- [The Evolution of Evolutionary Architecture - Rebecca Parsons](https://www.youtube.com/watch?v=dgxr4nEjaFw)
- [Voxxed Days Vienna - Evolutionary Software Architectures - Neal Ford](https://www.youtube.com/watch?v=CglSFhwbI3s)
- [SATURN2016 - Evolutionary Architecture with Patrick Kua](https://www.youtube.com/watch?v=XSrLU4TOoxA)
- [SDDConf 2016 - Keynote on Evolutionary Architectures](https://vimeo.com/user28557683/review/169995132/8468bd9321)

##### Articles
- [scottwd9/building-evolutionary-architectures.md](https://gist.github.com/scottwd9/ada88f963aac95893e1eba10d4ad8f6d)


##### Books
- [Building Evolutionary Architectures: Support Constant Change](https://www.amazon.com/Building-Evolutionary-Architectures-Support-Constant/dp/1491986360)


#### Event Storming References

- [mariuszgil/awesome-eventstorming](https://github.com/mariuszgil/awesome-eventstorming)
- [ddd-crew
/
eventstorming-glossary-cheat-sheet](https://github.com/ddd-crew/eventstorming-glossary-cheat-sheet)


#### Worthy Clones 

- [ddd-by-examples/library](https://github.com/ddd-by-examples/library)

#### Interesting Reads

- [Simple Domain Events with EFCore and MediatR](https://cfrenzel.com/domain-events-efcore-mediatr/)
- [Avoid In-Memory Databases for Tests](https://jimmybogard.com/avoid-in-memory-databases-for-tests/)
- [Julie Lerman talks about DDD and EF Core 3](https://www.youtube.com/watch?v=9XeazTD5AwY&feature=emb_title)
- [DeactivateUser](https://udidahan.com/2009/09/01/dont-delete-just-dont/)
- [Avoid Soft Deletes](https://ayende.com/blog/4157/avoid-soft-deletes)

#### Insightful Videos

- [Julie Lerman talks about DDD and EF Core 3](https://www.youtube.com/watch?v=9XeazTD5AwY)
- [Julie LERMAN: Mapping DDD Domain Models with EF Core 2.1 @ Update Conference Prague 2018](https://www.youtube.com/watch?v=Z62cbp61Bb8)

##### BDD

- [SpecFlow - Getting Started](https://specflow.org/getting-started/)


##### Event Stroming 

- [Whirlpool-of-Events](https://github.com/codefinity/whirlpool-of-events)

##### Code Coverage

- [Measuring .NET Core Test Coverage with Coverlet](https://www.tonyranieri.com/blog/2019/07/31/Measuring-.NET-Core-Test-Coverage-with-Coverlet/)
- [Use code coverage for unit testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)

##### Architecture Decision Log

- [joelparkerhenderson/architecture_decision_record](https://github.com/joelparkerhenderson/architecture_decision_record)
- [DOCUMENTING ARCHITECTURE DECISIONS](https://cognitect.com/blog/2011/11/15/documenting-architecture-decisions)


#### Books

- [Implementing Domain-Driven Design](https://www.oreilly.com/library/view/implementing-domain-driven-design/9780133039900/)
- [Patterns, Principles, and Practices of Domain-Driven Design](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
- [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.oreilly.com/library/view/domain-driven-design-tackling/0321125215/)
- [Hands-On Domain-Driven Design with .NET Core](https://www.packtpub.com/in/application-development/hands-domain-driven-design-net-core)
- [Writing Great Specifications](https://www.manning.com/books/writing-great-specifications)

## Issue Resolutions and Workarounds

Issues encountered diring development of this application and their workarounds can be found [here](IssueResolutionsAndWorkarounds.md).


