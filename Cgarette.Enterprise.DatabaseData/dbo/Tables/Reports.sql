CREATE TABLE [dbo].[Reports] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (500) NULL,
    [ImageUrl]    NVARCHAR (500) NULL,
    [FileUrl]     NVARCHAR (500) NULL,
    [SocialShare] NVARCHAR (500) NULL,
    [DateCreated] DATETIME       NULL,
    [Type]        NCHAR (10)     NULL,
    [Issuer]      NVARCHAR (500) NULL,
    [IssueDate]   DATETIME       NULL,
    [PublishDate] DATETIME       NULL,
    [Description] NVARCHAR (500) NULL,
    [Active]      BIT            NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED ([Id] ASC)
);

