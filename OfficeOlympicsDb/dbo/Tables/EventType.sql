CREATE TABLE [dbo].[EventType] (
    [EventTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED ([EventTypeId] ASC)
);

