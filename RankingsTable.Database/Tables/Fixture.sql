CREATE TABLE [dbo].[Fixture]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [HomePlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [AwayPlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [SeasonId] UNIQUEIDENTIFIER NOT NULL, 
    [HomeGoals] INT NULL, 
    [AwayGoals] INT NULL, 
    CONSTRAINT [FK_Fixture_HomePlayer] FOREIGN KEY ([HomePlayerId]) REFERENCES [Player]([Id]),
    CONSTRAINT [FK_Fixture_AwayPlayer] FOREIGN KEY ([AwayPlayerId]) REFERENCES [Player]([Id]), 
    CONSTRAINT [FK_Fixture_Season] FOREIGN KEY ([SeasonId]) REFERENCES [Season]([Id]),
	CONSTRAINT [CK_Result_HomeGoals] CHECK (HomeGoals >=0 ), 
    CONSTRAINT [CK_Result_AwayGoals] CHECK (AwayGoals >= 0)  
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Fixture] ON [dbo].[Fixture] ([HomePlayerId], [AwayPlayerId], [SeasonId])
