CREATE DATABASE oeuvre;

CREATE TABLE public."UserRegistrations"
(
    Id serial PRIMARY KEY,
    Login VARCHAR (100) NOT NULL,
    Email VARCHAR  (255) NOT NULL,
    Password VARCHAR (255) NOT NULL,
    FirstName VARCHAR (50) NOT NULL,
    LastName VARCHAR (50) NOT NULL,
    Name VARCHAR  (255) NOT NULL,
	StatusCode VARCHAR(50) NOT NULL,
	RegisterDate TIMESTAMP  NOT NULL,
	ConfirmedDate TIMESTAMP  NULL
);