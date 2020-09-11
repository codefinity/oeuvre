# Oeuvre

The Theater Of Evolutionary Architecture

### Oeuvre
/ˈəːvr(ə)/

**Pronounced as:** uh·vruh | noun: oeuvre; plural noun: oeuvres

**Meaning:** The body of work of a painter, composer, or author. A work of art, music, or literature.

## A Note

This project is in design and analysis phase. Please feel free to go through the code and if you have any Questions aor Suggestions, you can use the [Issues](https://github.com/codefinity/oeuvre/issues) tab. 

## Table of Contents

[1. Introducing Oeuvre](#Introducing-Oeuvre)

[2. News](#News)

[3. Setup Instructions](#Setup-Instructions)

[4. Logs](#Logs)

[5. Running Tests](#Running-Tests)

[6. Running Code Coverage](#Running-Code-Coverage)

[7. Features](#Features)

[8. Analysis and Design](#Analysis-and-Design)

[9. Inspiration](#Inspiration)

[10. Issue Resolutions and Workarounds](#Issue-Resolutions-and-Workarounds)

## Introducing Oeuvre

Oeuvre is a social article publishing portal that enables users to write and publish and share their articles. 
At some level Oeuvre is an Experimental Test-Bed for Evolutionary Architecture. This project will also demonstrate how quickly and efficiently DDD aligns to the changes in business.

The technology stack used is .Net, but the concept can be applied to all the programming language that supports OOPS.

## News

- Migration from Postgres to Sql Server in progress on branch evolution-one-migration-sqlserver. Merged to branch evolution-one.
- Integration Tests Written.



## Setup Instructions


### Clone the Repository

  ```
  git clone https://github.com/codefinity/oeuvre.git
  ```

### Setting-up the Database

1. Install [SQL Server Developer Edition](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads)

2. Install [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

#### Enable Running Scripts in Console

1. Open SQL Server Management Studio.

2. Go to -> Tools > Options > Query Execution > SQL Server > General 

3. Ensure this is checked -> "By default, open new queries in SQLCMD mode"

#### Creating the DB

In the windows console go to this location -> "oeuvre\server\src\DBScripts" and run the batch file

  ```
  C:\...oeuvre\server\src\DBScripts>oeuvre-recreate-dev-db-tables-with-test-and-seed-data.bat
  ```

### Setting-up and Running the Project

1. Install [.Net Core 3.1 LTS](https://dotnet.microsoft.com/download/dotnet-core/3.1)

2. Install [Visual Studio](https://visualstudio.microsoft.com/)  

3. Install [SpecFlow for Visual Studio 2019](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio)

4. Open the project in Visual Studio.

5. Select "Oeuvre.API" from Run Dropdown and then Click on Run

![](design/RunningOeuvre.png)


## Logs

Logs are stored in the following locations in their respective modules folder.

  ```
  C:\Users\<Windows-Account>\OeuvreLogs
  ```
## Running Tests

#### Running All Tests

  ```
  C:\...oeuvre>run-all-tests.bat
  ```

#### Integration Tests

  ```
  C:\...oeuvre>dotnet test server\src\Tests\Oeuvre.API.IntegrationTests\Oeuvre.API.IntegrationTests.csproj
  ```
  
#### Domain Tests for a Specific Module

  ```
  C:\...oeuvre>dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests.csproj
  
  Example: For IdentityAccess Module
  
  C:\...oeuvre>dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests.csproj
  
  ```

#### Integration Tests for a Specific Module

  ```
  C:\...oeuvre>dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.IntegrationTests\Oeuvre.Modules.<ModuleName>.IntegrationTests.csproj
  
  Example: For IdentityAccess Module
  
  C:\...oeuvre>dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.IntegrationTests\Oeuvre.Modules.IdentityAccess.IntegrationTests.csproj
  
  ```

#### ArchUnit Tests for a Specific Module

  ```
  C:\...oeuvre>dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.ArchTests\Oeuvre.Modules.<ModuleName>.ArchTests.csproj
  
  Example: For IdentityAccess Module
  
  C:\...oeuvre>dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.ArchTests\Oeuvre.Modules.IdentityAccess.ArchTests.csproj
  
  ```
  
## Running Code Coverage

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

##### [Registration.feature](https://github.com/codefinity/oeuvre/blob/master/server/src/Specifications/Features/Functional/IdentityAccess/Oeuvre.Specs.IdentityAccess/Features/Registration.feature)
```gherkin

Feature: Registration

Scenario: New Member registers using valid credentials

	Given I am not a User of Oeuvre
	When I register using the following valid details
		|TenantId				|FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		|47d60457-5a80-4c83-96b6-890a5e5e4d22	|Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then I should be registered on the Oeuvre portal
	And I should receive a registration mail containing the email verification link account 

Scenario: New Member registers using invalid credentials

	Given I am not a User of Oeuvre
	When I register the following invalid details
		| TenantId				| FirstName			|LastName		|EMail					|Password		|MobileNoCountryCode	|MobileNumber	|
		| 47d60457-5a80-4c83-96b6-890a5e5e4d22	| Mary				|Carpenter		|Mary@TheCarpenters.com	|topoftheworld	|+1						|4387790052		|
	Then a new account will not be created for me
	And I should not receive a registration mail containing the email verification link account


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


## Analysis and Design

### Ubiquitous Language

```text
Registrant : 	One who has just registred to Oeuvre Portal through registration page, but will not qualify 
		as a user unless they verify their EMail through the link sent in his EMail.

User : 		One who has registered and verified his EMail. 

```

### Event Stroming Boards

#### IdentityAccess Module

##### Big Picture Event-Storming 

![](design/EventStorming-IdentityAccess-BigPictureEventStorming.png)

##### Design Level  Event-Storming 

![](design/EventStorming-IdentityAccess-DesignLevelEventStorming.png)

##### Arranged Design Level  Event-Storming 

![](design/EventStorming-IdentityAccess-DesignLevelEventStorming-Arranged.png)

##### Miro

- [Big Picture Event Sorming](https://miro.com/app/board/o9J_knjMlGU=/)
- [Design Level Event Storming](https://miro.com/app/board/o9J_kniwpWE=/)
- [More Design Level Event Storming](https://miro.com/app/board/o9J_knmsmnU=/)

## Inspiration

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

##### BDD

- [SpecFlow - Getting Started](https://specflow.org/getting-started/)

##### Event Stroming 

- [Whirlpool-of-Events](https://github.com/codefinity/whirlpool-of-events)

##### Code Coverage

- [Measuring .NET Core Test Coverage with Coverlet](https://www.tonyranieri.com/blog/2019/07/31/Measuring-.NET-Core-Test-Coverage-with-Coverlet/)
- [Use code coverage for unit testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)


#### Books

- [Implementing Domain-Driven Design](https://www.oreilly.com/library/view/implementing-domain-driven-design/9780133039900/)
- [Patterns, Principles, and Practices of Domain-Driven Design](https://www.oreilly.com/library/view/patterns-principles-and/9781118714706/)
- [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.oreilly.com/library/view/domain-driven-design-tackling/0321125215/)
- [Hands-On Domain-Driven Design with .NET Core](https://www.packtpub.com/in/application-development/hands-domain-driven-design-net-core)

## Issue Resolutions and Workarounds

"The instance of entity type 'UserRegistrationStatus' with the key value '{RegistrationId: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Modified', but the instance of entity type 'Registration' with the key value '{Id: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Added' and both are mapped to the same row."

[Allow optional dependents to be added later when using table splitting](https://github.com/dotnet/efcore/issues/17422)
