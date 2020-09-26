PRINT N'Adding Data To [identityaccess].[Tenants]...';

INSERT INTO [identityaccess].[Tenants]
([Id],										[Name],			[IsActive]) VALUES
('42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Tenant One',	1)
;



PRINT N'Adding Data To [identityaccess].[Registrations]...';

INSERT INTO [identityaccess].[Registrations]
 ([Id],										[TenantId],								[FirstName],	[LastName],		[CountryCode],	[MobileNo],		[EMail],					[Password],																[StatusCode],				[RegistrationDate],			[ConfirmedDate]) VALUES
 ('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'42D60457-5A80-4C83-96B6-890A5E5E4D22', 'Axl',			'Rose',			'+1',			'2145794522',	'axl.rose@gunsnroses.com',	'ANH0LuHONHrJNi+7LXu0eGD4lsbN1nfXe6usyWbW3z8Zo8brXgd2zOou4BBRIaRX0Q==',	'Confirmed',				'2020-08-16 07:47:17.710',	'2020-08-16 07:49:07.973'), --Password: GunsNRoses 
 ('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Elvis',		'Presley',		'+1',			'2154624889',	'elvis@presley.com',		'AJpkzuFs6EWc+vyfpyWnEo3rmyvsOyVS7ovUjtuut4k6zwpGAL+gx4CrPcku5zVhtA==',	'Confirmed',				'2020-08-16 18:26:40.990',	'2020-08-16 18:27:45.370'),	--Password: music
 --UnConformed User
 ('EB6ED728-E644-4762-B1C9-B01725A1FD74',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Bryan',		'Adams'	,		'+1',			'2145678992',	'Bryan@BryanAdams.com',		'ACP/SyUlfscAMNg5tUa9//pBqdp2IeKCbTO52Z7NOi970nvd5Btfc8oHb5xf/29SFw==',	'WaitingForConfirmation',	CURRENT_TIMESTAMP,			NULL)						--Password: IDoItForYou
 ;



PRINT N'Adding Data To [identityaccess].[Users]...';

INSERT INTO [identityaccess].[Users]
([Id],										[TenantId],								[FirstName],	[LastName],		[BioText],	[CountryCode],	[MobileNo],		[EMail],						[Password],																[IsActive]) VALUES
('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Axl',			'Rose',			NULL,		'+1',			'2145794522',	'axl.rose@gunsnroses.com',		'ANH0LuHONHrJNi+7LXu0eGD4lsbN1nfXe6usyWbW3z8Zo8brXgd2zOou4BBRIaRX0Q==',	1),
('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',	'Elvis',		'Presley',		NULL,		'+1',			'2154624889',	'elvis@presley.com',			'AJpkzuFs6EWc+vyfpyWnEo3rmyvsOyVS7ovUjtuut4k6zwpGAL+gx4CrPcku5zVhtA==',	1)
;



PRINT N'Adding Data To [identityaccess].[UserRoles]...';

INSERT INTO [identityaccess].[UserRoles]
([UserId],									[RoleCode]) VALUES
('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'Admin'),
('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'Member')
;
