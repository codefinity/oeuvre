PRINT N'Droping Tables...';
PRINT N'Droping [identityaccess].[Tenants]...';
DROP TABLE IF EXISTS [identityaccess].[Tenants];

PRINT N'Droping [identityaccess].[UserRoles]...';
DROP TABLE IF EXISTS [identityaccess].[UserRoles];

PRINT N'Droping [identityaccess].[Registrations]...';
DROP TABLE IF EXISTS [identityaccess].[Registrations];

PRINT N'Droping [identityaccess].[Users]...';
DROP TABLE IF EXISTS [identityaccess].[Users];

PRINT N'Droping [identityaccess].[RolesToPermissions]...';
DROP TABLE IF EXISTS [identityaccess].[RolesToPermissions];

PRINT N'Droping [identityaccess].[Permissions]...';
DROP TABLE IF EXISTS [identityaccess].[Permissions];

PRINT N'Droping [identityaccess].[Permissions]...';
DROP TABLE IF EXISTS [identityaccess].[Permissions];

PRINT N'Droping [identityaccess].[PasswordResetRequests]...';
DROP TABLE IF EXISTS [identityaccess].[PasswordResetRequests];

PRINT N'Droping Views...';
PRINT N'Droping View [identityaccess].[v_UserPermissions]...';
DROP VIEW IF EXISTS [identityaccess].[v_UserPermissions]

PRINT N'Droping View [identityaccess].[v_UserPermissions]...';
DROP VIEW IF EXISTS [identityaccess].[v_Users]


PRINT N'Droping Schema...';
PRINT N'Droping Schema [identityaccess]...';
DROP SCHEMA IF EXISTS [identityaccess]; 