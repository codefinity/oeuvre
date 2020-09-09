# Oeuvre

The Theater Of Evolutionary Architecture

### Oeuvre
/ˈəːvr(ə)/

**Pronounced as:** uh·vruh | noun: oeuvre; plural noun: oeuvres

**Meaning:** The body of work of a painter, composer, or author. A work of art, music, or literature.

### Introducing Oeuvre

Oeuvre is a social article publishing portal that enables users to write and publish and share their articles. 
At some level Oeuvre is an Experimental Test-Bed for Evolutionary Architecture. This project will also demonstrate how quickly and efficiently DDD aligns to the changes in business.

The technology stack used is .Net, but the concept can be applied to all the programming language that supports OOPS.

## News

- Migration from Postgres to Sql Server in progress on branch evolution-one-migration-sqlserver. Merged to branch evolution-one.
- Integration Tests Written.

## Setup Instructions

### Setting-up the Database

#### Clone the Repository

  ```
  git clone https://github.com/codefinity/oeuvre.git
  ```

#### Enable Running Scripts in Console

1. Open SQL Server Management Studio.

2. Go to -> Tools > Options > Query Execution > SQL Server > General 

3. Ensure this is checked -> "By default, open new queries in SQLCMD mode"

#### Creating the DB

1. In Sql Server Management Studio Create a DB named "oeuvre"

2. In the windows console go to this location -> "oeuvre\server\src\DBScripts" and run the batch file

  ```
  C:\...oeuvre\server\src\DBScripts>oeuvre-recreate-db-tables-with-test-and-seed-data.bat
  ```

### Setting-up the Project

1. Install [.Net Core 3.1 LTS](https://dotnet.microsoft.com/download/dotnet-core/3.1)


2. Open the project in Visual Studio.


### Logs

Logs are stored in the following locations in their respective modules folder.

  ```
  C:\Users\<Windows-Account>\OeuvreLogs
  ```
### Running Tests

#### Integration Tests

  ```
  C:\...oeuvre>dotnet test server\src\Tests\Oeuvre.API.IntegrationTests\Oeuvre.API.IntegrationTests.csproj
  ```
  
### Running Code Coverage

1. On console make sure you are in the test project folder

2. Run this command to generate report in XML format. The Report is saved in /TestResults Folder.
```
  dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./TestResults/"
```
3. Run this command to generate HTML report from the XML report. The Report is saved in /TestResults/html Folder. To view the report, open the index.html file in the browser.
```
  reportgenerator "-reports:TestResults\coverage.cobertura.xml" "-targetdir:TestResults\html" -reporttypes:HTML;
```

## Features

### IdentityAccess Module

##### [Authentication.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Authentication.feature)
```gherkin
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

```

##### [EmailVerification.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/EmailVerification.feature)
```gherkin
Feature: Email Verification

Scenario: Email verification from the link sent in the EMail

	Given I have registered on Oeuvre portal
	And I have received an EMail verification link in my EMail
	When I click on the EMail verification link
	Then my EMail should be verified on the portal

```

##### [ForgotPasswordRequest.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/ForgotPasswordRequest.feature)
```gherkin
Feature: ForgotPasswordRequest
	As a Member who has forgotten his Oeuvre password
	In order to login again
	I want to be able to reset my password

Scenario: Send reset password link when the EMail provided is correct
	Given I am a regestered Member
	And For reseting my password I am asked my EMail Id at the time of registration
	When I provide my Correct EMail Id
	Then I should get the Password Reset Link in my email.

Scenario: Send reset password link when the EMail provided is in-correct
	Given I am a regestered Member
	And For reseting my password I am asked my EMail Id at the time of registration
	When I provide my InCorrect EMail Id
	Then No Email should be sent.

```

##### [Registration.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Registration.feature)
```gherkin
Feature: Registration

Scenario: New Member registers using valid credentials

	Given I am a new Member of the product
	When I register the following valid details
	  | name | email            | password    |
	  | mark  | email@gmail.com | Passw0rd123 |
	Then a new account will be created for me
	And I should receive a registration mail containing the email verification link account

Scenario: New Member register using Facebook

	Given I am a new Member of the product 2
	When I choose to register through my Facebook account
	Then a new account will be created for me 2

Scenario: New Member register using Google

	Given I am a new Member of the product
	When I choose to register through my Google account
	Then a new account will be created for me

Scenario: New Member registers using in-valid credentials

	Given I am a new Member of the product
	When I register the following in-valid details
	  | name	| email            | password    |
	  | markX	| emailX@gmail.com | Passw0rd123 |
	Then a new account will be created for me
	And I should receive a registration mail containing the email verification link account

```


##### [ResetPassword.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/ResetPassword.feature)
```gherkin
Feature: ResetPassword

Scenario: Reset password on clicking the link in the Reset password EMail sent and supplying the new password and retype password
	Given that I have received the reset password EMail
	When I click on the link
	And supply the new password
	And the retype password
	Then my password should be reset

```

##### [UserProfile.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/UserProfile.feature)
```gherkin
Feature: UserProfile


Scenario: Member can Update the User Profile
	Given I am a Registered Member
	When I try to update my User Profile
	Then My user Profile should be Updated

```

##### [UserSettings.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/UserSettings.feature)
```gherkin
Feature: UserSettings

Scenario: Member can update his Settings
	Given I am a Registered Member
	When I try to update my Settings
	Then My user Settings should be updated

```




## Analysis and Design

### Event Stroming Boards

#### IdentityAccess Module

##### Big Picture Event-Storming 

![](design/EventStorming-IdentityAccess-BigPictureEventStorming.png)

##### Design Level  Event-Storming 

![](design/EventStorming-IdentityAccess-DesignLevelEventStorming.png)

##### Miro

- [Big Picture Event Sorming](https://miro.com/app/board/o9J_knjMlGU=/)
- [Design Level Event Storming](https://miro.com/app/board/o9J_kniwpWE=/)
- [More Design Level Event Storming](https://miro.com/app/board/o9J_knmsmnU=/)

### Evolution - One

- **Current Working Branch:** evolution-one 
- [Requirements for Phase One published](https://github.com/codefinity/oeuvre/tree/evolution-one/server/src/Specifications/Features)
- [Ubiquitous Language](https://github.com/codefinity/oeuvre/tree/evolution-one/server/src/Specifications/Features)

## Inspired By

#### Event Storming References

- [mariuszgil/awesome-eventstorming](https://github.com/mariuszgil/awesome-eventstorming)
- [ddd-crew
/
eventstorming-glossary-cheat-sheet](https://github.com/ddd-crew/eventstorming-glossary-cheat-sheet)

#### Special Thanks

- [kgrzybek
/
modular-monolith-with-ddd](https://github.com/kgrzybek/modular-monolith-with-ddd)

#### Worthy Clones 

#### Interesting Reads

- [Simple Domain Events with EFCore and MediatR](https://cfrenzel.com/domain-events-efcore-mediatr/)
- [Avoid In-Memory Databases for Tests](https://jimmybogard.com/avoid-in-memory-databases-for-tests/)
- [Julie Lerman talks about DDD and EF Core 3](https://www.youtube.com/watch?v=9XeazTD5AwY&feature=emb_title)
- [DeactivateUser](https://udidahan.com/2009/09/01/dont-delete-just-dont/)
- [Avoid Soft Deletes](https://ayende.com/blog/4157/avoid-soft-deletes)

#### Insightful Videos

- [Julie Lerman talks about DDD and EF Core 3](https://www.youtube.com/watch?v=9XeazTD5AwY)
- [Julie LERMAN: Mapping DDD Domain Models with EF Core 2.1 @ Update Conference Prague 2018](https://www.youtube.com/watch?v=Z62cbp61Bb8)

##### Code Coverage

- [Measuring .NET Core Test Coverage with Coverlet](https://www.tonyranieri.com/blog/2019/07/31/Measuring-.NET-Core-Test-Coverage-with-Coverlet/)
- [Use code coverage for unit testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)

##### Issue Resolutions and Workarounds

"The instance of entity type 'UserRegistrationStatus' with the key value '{RegistrationId: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Modified', but the instance of entity type 'Registration' with the key value '{Id: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Added' and both are mapped to the same row."

[Allow optional dependents to be added later when using table splitting](https://github.com/dotnet/efcore/issues/17422)



#### Books

- [Implementing Domain-Driven Design](https://www.oreilly.com/library/view/implementing-domain-driven-design/9780133039900/)
- [Patterns, Principles, and Practices of Domain-Driven Design](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
- [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.oreilly.com/library/view/domain-driven-design-tackling/0321125215/)
- [Hands-On Domain-Driven Design with .NET Core](https://www.packtpub.com/in/application-development/hands-domain-driven-design-net-core)
