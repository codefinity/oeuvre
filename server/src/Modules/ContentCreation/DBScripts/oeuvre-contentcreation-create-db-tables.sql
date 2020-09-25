PRINT N'Creating Table [contentcreation].[Members]...';

CREATE TABLE [contentcreation].[Members]
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [TenantId]      UNIQUEIDENTIFIER    NOT NULL,
    [EMailId]       NVARCHAR(255)       NOT NULL,
    [FirstName]     NVARCHAR(255)       NOT NULL,
    [LastName]      NVARCHAR(255)       NOT NULL,
    CONSTRAINT [PK_contentcreation_Members_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)


PRINT N'Creating Table [contentcreation].[Articles]...';


CREATE TABLE [contentcreation].[Articles]
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [TenantId]      UNIQUEIDENTIFIER    NOT NULL,
    [Topic]         NVARCHAR(50)        NOT NULL,
    [Body]          NVARCHAR (255)      NOT NULL,
    CONSTRAINT [PK_contentcreation_Articles_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)


PRINT N'Creating Table [contentcreation].[Collaborators]...';

CREATE TABLE [contentcreation].[Collaborators]
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [TenantId]      UNIQUEIDENTIFIER    NOT NULL,
    [Name]          NVARCHAR(50)        NOT NULL,
    [Email]         NVARCHAR (255)      NOT NULL,
    [CreatedDate]   DATETIME            NOT NULL,
    CONSTRAINT [PK_contentcreation_Collaborators_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
)

