CREATE TABLE public."Registration"
(
    "Id" serial PRIMARY KEY,
    "FirstName" VARCHAR (50) NOT NULL,
    "LastName" VARCHAR (50) NOT NULL,
    "CountryCode" Varchar (50) NOT NULL,
    "MobileNo" VARCHAR (50) NOT NULL,
    "EMail" VARCHAR  (255) NOT NULL,
    "Password" VARCHAR (255) NOT NULL,
	"StatusCode" VARCHAR(50) NOT NULL,
	"RegistrationDate" TIMESTAMP  NOT NULL,
	"ConfirmedDate" TIMESTAMP  NULL
);