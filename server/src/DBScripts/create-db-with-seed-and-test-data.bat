sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-create-db-tables.sql -d oeuvre -E
sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-add-seed-data.sql -d oeuvre -E
sqlcmd -S (LocalDb)\MSSQLLocalDB -i oeuvre-add-test-data.sql -d oeuvre -E