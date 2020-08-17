use oeuvre;

PRINT N'Creating [identityaccess]...';

GO
CREATE SCHEMA [identityaccess]
    AUTHORIZATION [dbo];

GO


PRINT N'Creating [identityaccess].[Tenants]...';

GO
CREATE TABLE [identityaccess].[Tenants] (
    [Id]            UNIQUEIDENTIFIER        NOT NULL,
    [Name]          VARCHAR (100)           NOT NULL,
    CONSTRAINT [PK_identityaccess_Tenants_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


PRINT N'Creating [identityaccess].[UserRoles]...';

GO
CREATE TABLE [identityaccess].[UserRoles] (
    [UserId]   UNIQUEIDENTIFIER NOT NULL,
    [RoleCode] NVARCHAR (50)    NULL
);


PRINT N'Creating [identityaccess].[Registrations]...';

GO
CREATE TABLE [identityaccess].[Registrations] (
    [Id]                UNIQUEIDENTIFIER        NOT NULL,
    [TenantId]          UNIQUEIDENTIFIER		NOT NULL,
    [FirstName]         NVARCHAR (50)           NULL,
    [LastName]          NVARCHAR (50)           NULL,
    [CountryCode]       NVARCHAR (10)           NULL,
    [MobileNo]          NVARCHAR (50)           NULL,
    [EMail]             NVARCHAR (255)          NOT NULL,
    [Password]          VARCHAR (255)           NOT NULL,
    [StatusCode]        VARCHAR (50)            NOT NULL,
    [RegistrationDate]  DATETIME                NOT NULL,
    [ConfirmedDate]     DATETIME                NULL,
    CONSTRAINT [PK_identityaccess_Registrations_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


PRINT N'Creating [identityaccess].[Users]...';

GO
CREATE TABLE [identityaccess].[Users] (
    [Id]                UNIQUEIDENTIFIER        NOT NULL,
    [TenantId]          UNIQUEIDENTIFIER        NOT NULL,
    [FirstName]         NVARCHAR (50)           NULL,
    [LastName]          NVARCHAR (50)           NULL,
    [CountryCode]       NVARCHAR (10)           NULL,
    [MobileNo]          NVARCHAR (50)           NULL,
    [EMail]             NVARCHAR (255)          NOT NULL,
    [Password]          VARCHAR (255)           NOT NULL,
    [IsActive]          BIT                     NOT NULL,
    CONSTRAINT [PK_identityaccess_Users_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


PRINT N'Creating [identityaccess].[RolesToPermissions]...';

GO
CREATE TABLE [identityaccess].[RolesToPermissions] (
    [RoleCode]       VARCHAR (50) NOT NULL,
    [PermissionCode] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_RolesToPermissions_RoleCode_PermissionCode] PRIMARY KEY CLUSTERED ([RoleCode] ASC, [PermissionCode] ASC)
);

PRINT N'Creating [identityaccess].[Permissions]...';

GO
CREATE TABLE [identityaccess].[Permissions] (
    [Code]        VARCHAR (50)  NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [PK_identityaccess_Permissions_Code] PRIMARY KEY CLUSTERED ([Code] ASC)
);


--CREATE TABLE public."Registration"
--(
--    "Id" Uuid PRIMARY KEY,-
--    "TenantId" uuid,-
--    "FirstName" VARCHAR (50),-
--    "LastName" VARCHAR (50),-
--    "CountryCode" Varchar (50),-
--    "MobileNo" VARCHAR (50),-
--    "EMail" VARCHAR  (255),-
--    "Password" VARCHAR (255),-
--	"StatusCode" VARCHAR(50),-
--	"RegistrationDate" TIMESTAMP,
--	"ConfirmedDate" TIMESTAMP
--);

--CREATE TABLE public."User"
--(
--    "Id" uuid PRIMARY KEY,
--    "TenantId" uuid NOT NULL,
--    "FirstName" VARCHAR (50) NOT NULL,
--    "LastName" VARCHAR (50) NOT NULL,
--    "CountryCode" Varchar (50) NOT NULL,
--    "MobileNo" VARCHAR (50) NOT NULL,
--    "EMail" VARCHAR  (255) NOT NULL,
--    "Password" VARCHAR (255) NOT NULL,
--    "IsActive" BOOLEAN NOT NULL 
--);