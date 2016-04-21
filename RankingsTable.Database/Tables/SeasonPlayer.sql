CREATE TABLE [dbo].[SeasonPlayer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SeasonId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_SeasonPlayer_Season] FOREIGN KEY ([SeasonId]) REFERENCES [Season]([Id]), 
    CONSTRAINT [FK_SeasonPlayer_Player] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_SeasonPlayer] ON [dbo].[SeasonPlayer] ([PlayerId], [SeasonId])