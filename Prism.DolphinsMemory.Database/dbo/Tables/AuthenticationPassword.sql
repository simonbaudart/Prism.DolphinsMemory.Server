CREATE TABLE [dbo].[AuthenticationPassword] (
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Salt]       VARBINARY (MAX)  NOT NULL,
    [Hash]       VARBINARY (MAX)  NOT NULL,
    [Iterations] INT              NOT NULL,
    CONSTRAINT [PK_AuthenticationPassword] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_AuthenticationPassword_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

