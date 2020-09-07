@ECHO OFF

ECHO Setting up Oeuvre Integration Test DB

:: -Q (uppercase) to run query and exit.
::sqlcmd -S DESKTOP-6DRE2VL -Q "USE oeuvre_integration_tests;"
set databaseName=oeuvre_integration_tests

ECHO
ECHO ==========================================IdentityAccess Module==========================================

sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables.sql
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-test-data.sql

ECHO
ECHO ==========================================ContentCreation Module==========================================

sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-drop-db-tables.sql
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-create-db-tables.sql
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-add-test-data.sql

