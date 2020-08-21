@ECHO OFF

ECHO Recreating Data Tables
ECHO
ECHO ==========================================IdentityAccess Module==========================================

sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables.sql
sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql
sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-test-data.sql

ECHO ==========================================ContentCreation Module==========================================

sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-drop-db-tables.sql
sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-create-db-tables.sql
sqlcmd -S (LocalDb)\MSSQLLocalDB -i ..\Modules\ContentCreation\DBScripts\oeuvre-contentcreation-add-test-data.sql

