CREATE TABLE [dbo].[CEO] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (200) NULL,
    [Position]      NVARCHAR (200) NULL,
    [LinkedIn]      NVARCHAR (500) NULL,
    [Twitter]       NVARCHAR (500) NULL,
    [SnapChat]      NVARCHAR (500) NULL,
    [CVNote]        NVARCHAR (500) NULL,
    [ImageUrl]      NVARCHAR (500) NULL,
    [CVDescription] NVARCHAR (MAX) NULL,
    [Company]       NVARCHAR (500) NULL,
    [Email]         NVARCHAR (500) NULL,
    [Location]      NVARCHAR (500) NULL,
    [CreatedDate]   DATETIME       NULL,
    [Active]        BIT            NULL,
    [Views]         INT            NULL,
    [CVUrl]         NVARCHAR (500) NULL,
    CONSTRAINT [PK_CEO] PRIMARY KEY CLUSTERED ([Id] ASC)
);

