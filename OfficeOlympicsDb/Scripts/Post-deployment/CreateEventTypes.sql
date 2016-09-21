SET IDENTITY_INSERT [dbo].[EventType] ON

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