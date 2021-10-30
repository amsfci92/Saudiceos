CREATE TABLE [dbo].[News] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (500) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Note]        NVARCHAR (500) NULL,
    [imageUrl]    NVARCHAR (500) NULL,
    [Views]       INT            NULL,
    [CreateDate]  DATETIME       NULL,
    [Active]      BIT            NULL,
    [Tags]        NVARCHAR (MAX) NULL,
    [CeoId]       BIGINT         NULL,
    CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_News_CEO] FOREIGN KEY ([CeoId]) REFERENCES [dbo].[CEO] ([Id])
);

