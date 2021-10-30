CREATE TABLE [dbo].[Category] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [ImageUrl]     NVARCHAR (500) NULL,
    [Name]         NVARCHAR (500) NULL,
    [CreationDate] DATETIME       NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

