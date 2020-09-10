-- $(dbname) is a variable received from the bat file.

--CREATE DATABASE $(dbname);

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '$(dbname)')
BEGIN
  CREATE DATABASE $(dbname)
END;
--GO