set databaseName=oeuvre_dev

call oeuvre-create-db.bat %databaseName%
call oeuvre-recreate-db.bat %databaseName%