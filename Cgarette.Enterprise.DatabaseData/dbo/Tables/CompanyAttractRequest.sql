CREATE TABLE [dbo].[CompanyAttractRequest] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [Position]    NVARCHAR (500) NULL,
    [Company]     NVARCHAR (500) NULL,
    [Email]       NVARCHAR (500) NULL,
    [Phone]       NVARCHAR (500) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [DateCreated] DATETIME       NULL,
    [Type]        NCHAR (5)      NULL,
    CONSTRAINT [PK_CompanyAttractRequest] PRIMARY KEY CLUSTERED ([Id] ASC)
);

