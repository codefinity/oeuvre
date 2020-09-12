# Running Tests and Code Coverage

### Table of Contents

[1. Running Tests](#Running-Tests)

&nbsp;&nbsp;[1.1 All Tests](#All-Tests)

&nbsp;&nbsp;[1.2 Integration Tests](#Integration-Tests)

&nbsp;&nbsp;[1.3 Domain Tests for a Specific Module](#Domain-Tests-for-a-Specific-Module)

&nbsp;&nbsp;[1.4 Integration Tests for a Specific Module](#Integration-Tests-for-a-Specific-Module)

&nbsp;&nbsp;[1.5 ArchUnit Tests for a Specific Module](#ArchUnit-Tests-for-a-Specific-Module)

[2. Running Code Coverage](Running-Code-Coverage)


### Running Tests 

#### All Tests

  ```powershell
  C:\...oeuvre> run-all-tests.bat
  ```

#### Integration Tests
  
  ```powershell
  C:\...oeuvre> dotnet test server\src\Tests\Oeuvre.API.IntegrationTests\Oeuvre.API.IntegrationTests.csproj
  ```
  
#### Domain Tests for a Specific Module
  
  ```powershell
  C:\...oeuvre> dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests.csproj
  
  # Example: For IdentityAccess Module
  
  C:\...oeuvre> dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests.csproj
  ```
  
#### Integration Tests for a Specific Module
  
  ```powershell
  C:\...oeuvre> dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.IntegrationTests\Oeuvre.Modules.<ModuleName>.IntegrationTests.csproj
  
  # Example: For IdentityAccess Module
  
  C:\...oeuvre> dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.IntegrationTests\Oeuvre.Modules.IdentityAccess.IntegrationTests.csproj
  ```
  
 #### ArchUnit Tests for a Specific Module
  
  ```powershell
  C:\...oeuvre> dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.ArchTests\Oeuvre.Modules.<ModuleName>.ArchTests.csproj
  
  # Example: For IdentityAccess Module
  
  C:\...oeuvre> dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.ArchTests\Oeuvre.Modules.IdentityAccess.ArchTests.csproj
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
