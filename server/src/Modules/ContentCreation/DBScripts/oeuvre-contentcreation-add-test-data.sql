USE [oeuvre]
GO


PRINT N'Adding Data To [contentcreation].[Collaborators]...';

GO

INSERT INTO [contentcreation].[Collaborators]
([Id],										[TenantId],									[Name],				[EMail],					[CreatedDate]) VALUES
('2BAE8A7B-1DCD-4D4C-9878-72A768470EBF',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',		'Axl Rose',			'Axl.Rose@GunsNRoses.com',	GETDATE()),
('A7D9B254-0EB7-4B0C-8B82-B0919BFB5E3A',	'42D60457-5A80-4C83-96B6-890A5E5E4D22',		'Elvis Presley',	'elvis@presley.com',		GETDATE())
;
GO

