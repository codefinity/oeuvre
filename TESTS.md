### Running Tests

All **Integration Tests** are done on a separate database "oeuvre_integration_testing". All the tables and seed data are added before the test and removed after the tests.

  ```powershell
  # 1. Running All Tests
  
  C:\...oeuvre> run-all-tests.bat
  

  # 2. Integration Tests
  
  C:\...oeuvre> dotnet test server\src\Tests\Oeuvre.API.IntegrationTests\Oeuvre.API.IntegrationTests.csproj
  
  
  # 3. Domain Tests for a Specific Module
  
  C:\...oeuvre> dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests\Oeuvre.Modules.<ModuleName>.Domain.UnitTests.csproj
  
  # Example: For IdentityAccess Module
  
  C:\...oeuvre> dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests.csproj
  
  
  # 4. Integration Tests for a Specific Module
  
  C:\...oeuvre> dotnet test server\src\Modules\<ModuleName>\Tests\Oeuvre.Modules.<ModuleName>.IntegrationTests\Oeuvre.Modules.<ModuleName>.IntegrationTests.csproj
  
  # Example: For IdentityAccess Module
  
  C:\...oeuvre> dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.IntegrationTests\Oeuvre.Modules.IdentityAccess.IntegrationTests.csproj
  
  
  # 5. ArchUnit Tests for a Specific Module
  
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
