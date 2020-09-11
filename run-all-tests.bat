::Integration Tests
ECHO OFF

ECHO ==========Running Integration Tests==========

dotnet test server\src\Tests\Oeuvre.API.IntegrationTests\Oeuvre.API.IntegrationTests.csproj

::Running all tests for IdentityAccessModule

ECHO ==========Identity Access - Running Domain Tests==========

dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests\Oeuvre.Modules.IdentityAccess.Domain.UnitTests.csproj

ECHO ==========Identity Access - Running Integration Tests==========

dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.IntegrationTests\Oeuvre.Modules.IdentityAccess.IntegrationTests.csproj

ECHO ==========Identity Access - Running Arch Tests=========

dotnet test server\src\Modules\IdentityAccess\Tests\Oeuvre.Modules.IdentityAccess.ArchTests\Oeuvre.Modules.IdentityAccess.ArchTests.csproj