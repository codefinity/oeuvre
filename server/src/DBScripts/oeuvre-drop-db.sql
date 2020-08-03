-- Forcing al the open connections to close and then droping the database
-- Reference: https://dba.stackexchange.com/questions/11893/force-drop-db-while-others-may-be-connected

--UPDATE pg_database SET datallowconn = 'true' WHERE datname = 'oeuvre';

SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'oeuvre';

DROP DATABASE oeuvre;