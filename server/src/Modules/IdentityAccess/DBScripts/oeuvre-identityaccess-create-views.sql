CREATE VIEW [identityaccess].[v_UserPermissions]
AS
SELECT DISTINCT
	[UserRole].UserId,
	[RolesToPermission].PermissionCode
FROM [identityaccess].UserRoles AS [UserRole]
	INNER JOIN [identityaccess].RolesToPermissions AS [RolesToPermission]
	ON [UserRole].RoleCode = [RolesToPermission].RoleCode;

GO

--Split is required so that the unit testing code can split the view text and execute 
--them one by one. Unable to create all the views at once
--Split--

CREATE VIEW [identityaccess].[v_Users]
AS
SELECT
    [Id],
    [EMail],
	[FirstName],
    [LastName],
	[IsActive]
FROM [identityaccess].[Users] AS [User];
GO

