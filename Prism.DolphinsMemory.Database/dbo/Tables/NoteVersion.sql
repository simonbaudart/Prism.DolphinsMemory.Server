CREATE TABLE [dbo].[NoteVersion] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Version]   INT              NOT NULL,
    [CatalogId] UNIQUEIDENTIFIER NOT NULL,
    [Title]     VARCHAR (MAX)    NOT NULL,
    [Author]    UNIQUEIDENTIFIER NOT NULL,
    [Data]      VARBINARY (MAX)  NOT NULL,
    [Created]   DATETIME         NOT NULL,
    [Updated]   DATETIME         NOT NULL,
    CONSTRAINT [PK_NoteVersion] PRIMARY KEY CLUSTERED ([Id] ASC, [Version] ASC),
    CONSTRAINT [FK_NoteVersion_Catalog] FOREIGN KEY ([CatalogId]) REFERENCES [dbo].[Catalog] ([Id]),
    CONSTRAINT [FK_NoteVersion_Note] FOREIGN KEY ([Id]) REFERENCES [dbo].[Note] ([Id]),
    CONSTRAINT [FK_NoteVersion_User] FOREIGN KEY ([Author]) REFERENCES [dbo].[User] ([Id])
);

