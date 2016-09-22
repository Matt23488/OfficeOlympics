SET IDENTITY_INSERT [dbo].[EventType] ON

IF NOT EXISTS (SELECT [EventTypeId] FROM [dbo].[EventType] WHERE [EventTypeId] = 1)
INSERT [dbo].[EventType]
(
	[EventTypeId],
	[Description]
)
VALUES
(
	1,
	'Timed'
);

IF NOT EXISTS (SELECT [EventTypeId] FROM [dbo].[EventType] WHERE [EventTypeId] = 2)
INSERT [dbo].[EventType]
(
	[EventTypeId],
	[Description]
)
VALUES
(
	2,
	'Repetitions'
);

SET IDENTITY_INSERT [dbo].[EventType] OFF

DBCC CHECKIDENT('dbo.EventType', RESEED, 2)