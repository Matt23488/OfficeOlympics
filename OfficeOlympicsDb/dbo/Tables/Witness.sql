CREATE TABLE [dbo].[Witness]
(
	[WitnessId] INT IDENTITY(1, 1) NOT NULL,
	[CompetitorId] INT NOT NULL,
	[RecordId] INT NOT NULL,
	CONSTRAINT [PK_Witness] PRIMARY KEY CLUSTERED ([WitnessId] ASC),
	CONSTRAINT [FK_Witness_Competitor] FOREIGN KEY ([CompetitorId]) REFERENCES [dbo].[Competitor]([CompetitorId]),
	CONSTRAINT [FK_Witness_Record] FOREIGN KEY ([RecordId]) REFERENCES [dbo].[Record]([RecordId])
)