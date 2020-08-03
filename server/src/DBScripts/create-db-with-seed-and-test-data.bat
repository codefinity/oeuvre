set PGPASSWORD=admin
psql -h localhost -U postgres -f oeuvre-create-db.sql
psql -h localhost -U postgres -f oeuvre-create-db-tables.sql -d oeuvre
psql -h localhost -U postgres -f oeuvre-add-seed-data.sql -d oeuvre
psql -h localhost -U postgres -f oeuvre-add-test-data.sql -d oeuvre