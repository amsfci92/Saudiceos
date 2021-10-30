CREATE TABLE [dbo].[Banner] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (500) NULL,
    [ImageUrl]    NVARCHAR (500) NULL,
    [Type]        NCHAR (10)     NULL,
    [Link]        NVARCHAR (MAX) NULL,
    [FileUrl]     NVARCHAR (500) NULL,
    [Description] TEXT           NULL,
    [Advertiser]  NVARCHAR (500) NULL,
    [Keywords]    NVARCHAR (MAX) NULL,
    [AdPlace]     INT            NULL,
    [CreatedDate] DATETIME       NULL,
    [Active]      BIT            NULL,
    CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED ([Id] ASC)
);

