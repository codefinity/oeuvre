use oeuvre;

PRINT N'Creating [contentcreation]...';

GO
CREATE SCHEMA [contentcreation]
    AUTHORIZATION [dbo];

GO

PRINT N'Creating Table [contentcreation].[Collabarators]...';

GO

CREATE TABLE [contentcreation].[Collabarators]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [TenantId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_contentcreation_Collobarators_Id] PRIMARY KEY ([Id] ASC)
)
GO

