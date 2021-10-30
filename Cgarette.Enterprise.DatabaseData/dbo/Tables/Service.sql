CREATE TABLE [dbo].[Service] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [ImageUrl]    NVARCHAR (MAX) NULL,
    [LogoUrl]     NVARCHAR (MAX) NULL,
    [Code]        NVARCHAR (MAX) NULL,
    [Link]        NVARCHAR (MAX) NULL,
    [Active]      BIT            NULL,
    [DateCreated] DATETIME       NULL,
    [CategoryId]  BIGINT         NULL,
    CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Service_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

