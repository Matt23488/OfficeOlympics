CREATE TABLE [dbo].[Competitor]
(
	[CompetitorId] INT IDENTITY(1, 1) NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Competitor] PRIMARY KEY CLUSTERED ([CompetitorId] ASC)
)