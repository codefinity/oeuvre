--USE [oeuvre]
--GO

PRINT N'Droping [identityaccess].[Tenants]...';

GO

DROP TABLE IF EXISTS [identityaccess].[Tenants];

PRINT N'Droping [identityaccess].[UserRoles]...';

GO

DROP TABLE IF EXISTS [identityaccess].[UserRoles];


PRINT N'Droping [identityaccess].[Registrations]...';

GO

DROP TABLE IF EXISTS [identityaccess].[Registrations];

PRINT N'Droping [identityaccess].[Users]...';

GO

DROP TABLE IF EXISTS [identityaccess].[Users];

PRINT N'Droping [identityaccess].[RolesToPermissions]...';

GO

DROP TABLE IF EXISTS [identityaccess].[RolesToPermissions];

PRINT N'Droping [identityaccess].[Permissions]...';

GO

DROP TABLE IF EXISTS [identityaccess].[Permissions];

PRINT N'Droping View [identityaccess].[v_UserPermissions]...';

GO

DROP VIEW IF EXISTS [identityaccess].[v_UserPermissions]

PRINT N'Droping Schema [identityaccess]...';

GO

DROP SCHEMA IF EXISTS [identityaccess]; 