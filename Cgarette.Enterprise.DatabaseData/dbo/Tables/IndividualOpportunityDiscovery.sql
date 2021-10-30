CREATE TABLE [dbo].[IndividualOpportunityDiscovery] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (500) NULL,
    [CurrentPosition] NVARCHAR (500) NULL,
    [Company]         NVARCHAR (500) NULL,
    [Email]           NVARCHAR (500) NULL,
    [Phone]           NVARCHAR (500) NULL,
    [DateCreate]      DATETIME       NULL,
    [Description]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_IndividualOpportunity] PRIMARY KEY CLUSTERED ([Id] ASC)
);

