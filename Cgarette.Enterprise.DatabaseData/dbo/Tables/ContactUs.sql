CREATE TABLE [dbo].[ContactUs] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (50)  NULL,
    [Phone]      NVARCHAR (50)  NULL,
    [Subject]    NVARCHAR (500) NULL,
    [Message]    TEXT           NULL,
    [Name]       NVARCHAR (500) NULL,
    [CreateDate] DATETIME       NULL,
    CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

