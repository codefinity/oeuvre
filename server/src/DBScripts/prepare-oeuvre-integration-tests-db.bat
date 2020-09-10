::call oeuvre-recreate-db.bat oeuvre_integration_testing

set databaseName=oeuvre_integration_testing

call oeuvre-create-db.bat %databaseName%
call oeuvre-recreate-db.bat %databaseName%