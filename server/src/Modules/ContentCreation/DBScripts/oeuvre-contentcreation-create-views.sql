CREATE VIEW [contentcreation].[v_Members]
AS
SELECT
    [Member].[Id],
    [Member].[EMailId],
    [Member].[FirstName],
    [Member].[LastName]
FROM contentcreation.Members AS [Member]
GO

--Split is required so that the unit testing code can split the view text and execute 
--them one by one. Unable to create all the views at once
--Split--

--CREATE VIEW [identityaccess].[v_Users]
--AS
--SELECT
--    [Id],
--    [EMail],
--	[FirstName],
--    [LastName],
--	[IsActive]
--FROM [identityaccess].[Users] AS [User];
--GO

