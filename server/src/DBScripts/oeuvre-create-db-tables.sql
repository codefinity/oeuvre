CREATE TABLE public."Registration"
(
    "Id" Uuid PRIMARY KEY,
    "TenantId" uuid,
    "FirstName" VARCHAR (50),
    "LastName" VARCHAR (50),
    "CountryCode" Varchar (50),
    "MobileNo" VARCHAR (50),
    "EMail" VARCHAR  (255),
    "Password" VARCHAR (255),
	"StatusCode" VARCHAR(50),
	"RegistrationDate" TIMESTAMP,
	"ConfirmedDate" TIMESTAMP
);

CREATE TABLE public."User"
(
    "Id" uuid PRIMARY KEY,
    "TenantId" uuid NOT NULL,
    "FirstName" VARCHAR (50) NOT NULL,
    "LastName" VARCHAR (50) NOT NULL,
    "CountryCode" Varchar (50) NOT NULL,
    "MobileNo" VARCHAR (50) NOT NULL,
    "EMail" VARCHAR  (255) NOT NULL,
    "Password" VARCHAR (255) NOT NULL,
    "IsActive" BOOLEAN NOT NULL 
);