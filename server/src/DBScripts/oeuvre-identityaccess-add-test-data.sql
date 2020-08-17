USE [oeuvre]
GO

PRINT N'Adding Data To [identityaccess].[Tenants]...';

GO

INSERT INTO [identityaccess].[Tenants]
([Id],										[Name]) VALUES
('42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Tenant One')
;

PRINT N'Adding Data To [identityaccess].[Registrations]...';

GO

INSERT INTO [identityaccess].[Registrations]
 ([Id],										[TenantId],								[FirstName],	[LastName],	[CountryCode],	[MobileNo],		[EMail],					[Password],																[StatusCode],	[RegistrationDate],			[ConfirmedDate]) VALUES
 ('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'42D60457-5A80-4C83-96B6-890A5E5E4D22', 'Axl',			'Rose',		01,				9999999999,		'Axl.Rose@GunsNRoses.com',	'ANH0LuHONHrJNi+7LXu0eGD4lsbN1nfXe6usyWbW3z8Zo8brXgd2zOou4BBRIaRX0Q==',	'Confirmed',	'2020-08-16 07:47:17.710',	'2020-08-16 07:49:07.973'), --Password: music
 ('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Elvis',		'Presley',	01,				12345678,		'elvis@presley.com',		'AJpkzuFs6EWc+vyfpyWnEo3rmyvsOyVS7ovUjtuut4k6zwpGAL+gx4CrPcku5zVhtA==',	'Confirmed',	'2020-08-16 18:26:40.990',	'2020-08-16 18:27:45.370')	--Password: GunsNRoses
 ;
GO

PRINT N'Adding Data To [identityaccess].[Users]...';

GO

INSERT INTO [identityaccess].[Users]
([Id],										[TenantId],								[FirstName],	[LastName],		[CountryCode],	[MobileNo],		[EMail],						[Password],																[IsActive]) VALUES
('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Axl',			'Rose',			01,				'9999999999',	'Axl.Rose@GunsNRoses.com',		'ANH0LuHONHrJNi+7LXu0eGD4lsbN1nfXe6usyWbW3z8Zo8brXgd2zOou4BBRIaRX0Q==',	1),
('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Elvis',		'Presley',		01,				'12345678',		'elvis@presley.com',			'AJpkzuFs6EWc+vyfpyWnEo3rmyvsOyVS7ovUjtuut4k6zwpGAL+gx4CrPcku5zVhtA==',	1)
;
GO

PRINT N'Adding Data To [identityaccess].[UserRoles]...';

GO

INSERT INTO [identityaccess].[UserRoles]
([UserId],									[RoleCode]) VALUES
('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'Admin'),
('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'Member')
;

GO

INSERT INTO [identityaccess].[Permissions] 
([Code],					[Name]) VALUES
-- Identity Access
('GetRegistrants', 'GetRegistrants')
;

INSERT INTO [identityaccess].[RolesToPermissions]  
([RoleCode],		[PermissionCode]) VALUES
-- Identity Access
('Admin',			'GetRegistrants')
;