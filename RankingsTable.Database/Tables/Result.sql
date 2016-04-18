CREATE TABLE [dbo].[Result]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[FixtureId] UNIQUEIDENTIFIER NOT NULL,
    [HomeGoals] INT NOT NULL, 
    [AwayGoals] INT NOT NULL, 
    CONSTRAINT [FK_Result_Fixture] FOREIGN KEY ([FixtureId]) REFERENCES [Fixture]([Id]), 
    CONSTRAINT [CK_Result_HomeGoals] CHECK (HomeGoals >=0 ), 
    CONSTRAINT [CK_Result_AwayGoals] CHECK (AwayGoals >= 0)    
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Result_FixtureId] ON [dbo].[Result] ([FixtureId])
