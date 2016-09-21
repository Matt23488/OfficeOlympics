CREATE TABLE [dbo].[OlympicEvent] (
    [OlympicEventId] INT           IDENTITY (1, 1) NOT NULL,
    [EventName]      VARCHAR (100) NOT NULL,
    [EventTypeId]    INT           NOT NULL,
	[Description] VARCHAR(MAX) NULL,
	[Specification] VARCHAR(MAX) NULL,
    CONSTRAINT [PK_OlympicEvent] PRIMARY KEY CLUSTERED ([OlympicEventId] ASC),
    CONSTRAINT [FK_OlympicEvent_EventType] FOREIGN KEY ([EventTypeId]) REFERENCES [dbo].[EventType] ([EventTypeId])
);

