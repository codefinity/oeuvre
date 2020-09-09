INSERT INTO [identityaccess].[Permissions] 
([Code],					[Name]) VALUES
-- Identity Access
('GetRegistrants', 'GetRegistrants'),
('CreateArticle', 'CreateArticle')
;

INSERT INTO [identityaccess].[RolesToPermissions]  
([RoleCode],		[PermissionCode]) VALUES
-- Identity Access
('Admin',			'GetRegistrants'),
('Member',			'CreateArticle')
;