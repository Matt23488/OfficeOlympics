CREATE TABLE [dbo].[Record]
(
	[RecordId] INT IDENTITY(1, 1) NOT NULL,
	[CompetitorId] INT NOT NULL,
	[OlympicEventId] INT NOT NULL,
	[Score] INT NOT NULL,
	[DateAchieved] DATETIME NOT NULL,
	CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED ([RecordId]),
	CONSTRAINT [FK_Record_Competitor] FOREIGN KEY ([CompetitorId]) REFERENCES [dbo].[Competitor]([CompetitorId]),
	CONSTRAINT [FK_Record_OlympicEvent] FOREIGN KEY ([OlympicEventId]) REFERENCES [dbo].[OlympicEvent]([OlympicEventId])
)