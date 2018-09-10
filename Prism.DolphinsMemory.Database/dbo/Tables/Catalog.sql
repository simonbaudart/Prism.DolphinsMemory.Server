CREATE TABLE [dbo].[Catalog] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]    VARCHAR (MAX)    NOT NULL,
    [Created] DATETIME         NOT NULL,
    [Updated] DATETIME         NOT NULL,
    [Deleted] BIT              CONSTRAINT [DF_Catalog_Deleted] DEFAULT 0 NOT NULL,
    CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Catalog_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Catalog_UserId]
    ON [dbo].[Catalog]([UserId] ASC);

