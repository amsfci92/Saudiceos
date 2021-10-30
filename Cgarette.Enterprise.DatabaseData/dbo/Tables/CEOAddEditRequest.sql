CREATE TABLE [dbo].[CEOAddEditRequest] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (500) NULL,
    [Position]           NVARCHAR (50)  NULL,
    [Email]              NVARCHAR (50)  NULL,
    [Phone]              NVARCHAR (50)  NULL,
    [CVDescription]      NVARCHAR (50)  NULL,
    [ImageUrl]           NVARCHAR (500) NULL,
    [DateCreated]        DATETIME       NULL,
    [CEOId]              BIGINT         NULL,
    [CVUrl]              NVARCHAR (500) NULL,
    [NationalIdImageUrl] NVARCHAR (500) NULL,
    CONSTRAINT [PK_CEORequest] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CEOAddEditRequest_CEO] FOREIGN KEY ([CEOId]) REFERENCES [dbo].[CEO] ([Id])
);

