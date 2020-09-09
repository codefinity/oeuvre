@ECHO OFF

ECHO Recreating Oeuvre Data Tables

:: -Q (uppercase) to run query and exit.
::sqlcmd -S DESKTOP-6DRE2VL -Q "USE oeuvre_integration_tests;"
set databaseName=%1

ECHO ==
ECHO ==========================================IdentityAccess Module==========================================
ECHO Dropping Tables and Schema

sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables-and-views-and-schema.sql

ECHO Creating Schema
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-schema.sql

ECHO Creating Tables
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql

ECHO Creating Views
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-views.sql

ECHO Adding Seed Data
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-seed-data.sql

ECHO Adding Test Data
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-test-data.sql

ECHO
ECHO ==========================================ContentCreation Module==========================================

sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-drop-db-tables.sql
ECHO
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-create-db-tables.sql
ECHO
sqlcmd -S DESKTOP-6DRE2VL -d %databaseName% -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-add-test-data.sql

