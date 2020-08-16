sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-identityaccess-create-db-tables.sql -d oeuvre -E
sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-identityaccess-add-seed-data.sql -d oeuvre -E
sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-identityaccess-add-test-data.sql -d oeuvre -E