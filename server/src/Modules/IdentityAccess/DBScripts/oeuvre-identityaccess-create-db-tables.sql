PRINT N'Creating [identityaccess].[Tenants]...';


CREATE TABLE [identityaccess].[Tenants] (
    [Id]            UNIQUEIDENTIFIER        NOT NULL,
    [Name]          VARCHAR (100)           NOT NULL,
    [IsActive]      BIT                     NOT NULL,
    CONSTRAINT [PK_identityaccess_Tenants_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


PRINT N'Creating [identityaccess].[UserRoles]...';


CREATE TABLE [identityaccess].[UserRoles] (
    [UserId]   UNIQUEIDENTIFIER NOT NULL,
    [RoleCode] NVARCHAR (50)    NULL
);


PRINT N'Creating [identityaccess].[Registrations]...';


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


CREATE TABLE [identityaccess].[Users] (
    [Id]                UNIQUEIDENTIFIER        NOT NULL,
    [TenantId]          UNIQUEIDENTIFIER        NOT NULL,
    [FirstName]         NVARCHAR (50)           NULL,
    [LastName]          NVARCHAR (50)           NULL,
    [BioText]           NVARCHAR (255)          NULL,
    [CountryCode]       NVARCHAR (10)           NULL,
    [MobileNo]          NVARCHAR (50)           NULL,
    [EMail]             NVARCHAR (255)          NOT NULL,
    [Password]          VARCHAR (255)           NOT NULL,
    [IsActive]          BIT                     NOT NULL,
    CONSTRAINT [PK_identityaccess_Users_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


PRINT N'Creating [identityaccess].[RolesToPermissions]...';


CREATE TABLE [identityaccess].[RolesToPermissions] (
    [RoleCode]       VARCHAR (50) NOT NULL,
    [PermissionCode] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_RolesToPermissions_RoleCode_PermissionCode] PRIMARY KEY CLUSTERED ([RoleCode] ASC, [PermissionCode] ASC)
);

PRINT N'Creating [identityaccess].[Permissions]...';


CREATE TABLE [identityaccess].[Permissions] (
    [Code]        VARCHAR (50)  NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [PK_identityaccess_Permissions_Code] PRIMARY KEY CLUSTERED ([Code] ASC)
);

PRINT N'Creating [identityaccess].[PasswordResetRequests]...';

CREATE TABLE [identityaccess].[PasswordResetRequests] (
    [Id]                UNIQUEIDENTIFIER       NOT NULL,
    [UserId]            UNIQUEIDENTIFIER       NOT NULL,
    [RequestedOn]       DATETIME               NOT NULL,
    [Status]            VARCHAR (50)           NOT NULL,
    CONSTRAINT [PK_identityaccess_PasswordResetRequests_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);