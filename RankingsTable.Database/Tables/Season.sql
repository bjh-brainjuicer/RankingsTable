CREATE TABLE [dbo].[Season]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Number] INT NOT NULL, 
    CONSTRAINT [CK_Season_Number] CHECK (Number > 0)
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Season_Number] ON [dbo].[Season] ([Number])
