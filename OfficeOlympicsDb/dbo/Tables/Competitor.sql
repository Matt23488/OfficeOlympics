CREATE TABLE [dbo].[Competitor]
(
	[CompetitorId] INT IDENTITY(1, 1) NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[IsActive] BIT NOT NULL CONSTRAINT [DF_Competitor_IsActive] DEFAULT CAST(1 AS BIT),
	CONSTRAINT [PK_Competitor] PRIMARY KEY CLUSTERED ([CompetitorId] ASC)
)