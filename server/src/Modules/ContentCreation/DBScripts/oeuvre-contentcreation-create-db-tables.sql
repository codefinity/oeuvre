use oeuvre;

PRINT N'Creating [contentcreation]...';

GO
CREATE SCHEMA [contentcreation]
    AUTHORIZATION [dbo];

GO

PRINT N'Creating Table [contentcreation].[Articles]...';

GO

CREATE TABLE [contentcreation].[Articles]
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [TenantId]      UNIQUEIDENTIFIER    NOT NULL,
    [Topic]         NVARCHAR(50)        NOT NULL,
    [Body]          NVARCHAR (255)      NOT NULL,
    CONSTRAINT [PK_contentcreation_Articles_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO


PRINT N'Creating Table [contentcreation].[Collaborators]...';

GO

CREATE TABLE [contentcreation].[Collaborators]
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [TenantId]      UNIQUEIDENTIFIER    NOT NULL,
    [Name]          NVARCHAR(50)        NOT NULL,
    [Email]         NVARCHAR (255)      NOT NULL,
    [CreatedDate]   DATETIME            NOT NULL,
    CONSTRAINT [PK_contentcreation_Collaborators_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

