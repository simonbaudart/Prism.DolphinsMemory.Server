CREATE TABLE [dbo].[Note] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [CatalogId] UNIQUEIDENTIFIER NOT NULL,
    [Title]     VARCHAR (MAX)    NOT NULL,
    [Author]    UNIQUEIDENTIFIER NOT NULL,
    [Data]      VARBINARY (MAX)  NOT NULL,
    [Created]   DATETIME         NOT NULL,
    [Updated]   DATETIME         NOT NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Note_Catalog] FOREIGN KEY ([CatalogId]) REFERENCES [dbo].[Catalog] ([Id]),
    CONSTRAINT [FK_Note_User] FOREIGN KEY ([Author]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Note_CatalogId]
    ON [dbo].[Note]([CatalogId] ASC);

