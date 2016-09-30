SET IDENTITY_INSERT [dbo].[Quote] ON

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 1 AND [QuoteText] = 'The best preparation for tomorrow is doing your best today.' AND [Quoter] = 'H. Jackson Brown, Jr.')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    1,
    'The best preparation for tomorrow is doing your best today.',
    'H. Jackson Brown, Jr.'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 2 AND [QuoteText] = 'Start by doing what''s necessary; then do what''s possible; and suddenly you are doing the impossible.' AND [Quoter] = 'Francis of Assisi')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    2,
    'Start by doing what''s necessary; then do what''s possible; and suddenly you are doing the impossible.',
    'Francis of Assisi'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 3 AND [QuoteText] = 'Perfection is not attainable, but if we chase perfection we can catch excellence.' AND [Quoter] = 'Vince Lombardi')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    3,
    'Perfection is not attainable, but if we chase perfection we can catch excellence.',
    'Vince Lombardi'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 4 AND [QuoteText] = 'Believe you can and you''re halfway there.' AND [Quoter] = 'Theodore Roosevelt')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    4,
    'Believe you can and you''re halfway there.',
    'Theodore Roosevelt'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 5 AND [QuoteText] = 'If you believe in yourself and have dedication and pride and never quit, you''ll be a winner. The price of victory is high but so are the rewards.' AND [Quoter] = 'Paul Bryant')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    5,
    'If you believe in yourself and have dedication and pride and never quit, you''ll be a winner. The price of victory is high but so are the rewards.',
    'Paul Bryant'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 6 AND [QuoteText] = 'Act like you expect to get into the end zone.' AND [Quoter] = 'Christopher Morley')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    6,
    'Act like you expect to get into the end zone.',
    'Christopher Morley'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 7 AND [QuoteText] = 'In order to succeed, we must first believe that we can.' AND [Quoter] = 'Nikos Kazantzakis')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    7,
    'In order to succeed, we must first believe that we can.',
    'Nikos Kazantzakis'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 8 AND [QuoteText] = 'Don''t watch the clock; do what it does. Keep going.' AND [Quoter] = 'Sam Levenson')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    8,
    'Don''t watch the clock; do what it does. Keep going.',
    'Sam Levenson'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 9 AND [QuoteText] = 'It always seems impossible until it''s done.' AND [Quoter] = 'Nelson Mandella')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    9,
    'It always seems impossible until it''s done.',
    'Nelson Mandella'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 10 AND [QuoteText] = 'Good, better, best. Never let it rest. ''Til your good is better and your better is best.' AND [Quoter] = 'St. Jerome')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    10,
    'Good, better, best. Never let it rest. ''Til your good is better and your better is best.',
    'St. Jerome'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 11 AND [QuoteText] = 'We should not give up and we should not allow the problem to defeat us.' AND [Quoter] = 'A. P. J. Abdul Kalam')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    11,
    'We should not give up and we should not allow the problem to defeat us.',
    'A. P. J. Abdul Kalam'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 12 AND [QuoteText] = 'Failure will never overtake me if my determination to succeed is strong enough.' AND [Quoter] = 'Og Mandino')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    12,
    'Failure will never overtake me if my determination to succeed is strong enough.',
    'Og Mandino'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 13 AND [QuoteText] = 'Start where you are. Use what you have. Do what you can.' AND [Quoter] = 'Arthur Ashe')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    13,
    'Start where you are. Use what you have. Do what you can.',
    'Arthur Ashe'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 14 AND [QuoteText] = 'Keep your eyes on the stars, and your feet on the ground.' AND [Quoter] = 'Theodore Roosevelt')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    14,
    'Keep your eyes on the stars, and your feet on the ground.',
    'Theodore Roosevelt'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 15 AND [QuoteText] = 'A creative man is motivated by the desire to achieve, not by the desire to beat others.' AND [Quoter] = 'Ayn Rand')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    15,
    'A creative man is motivated by the desire to achieve, not by the desire to beat others.',
    'Ayn Rand'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 16 AND [QuoteText] = 'If you can dream it, you can do it.' AND [Quoter] = 'Walt Disney')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    16,
    'If you can dream it, you can do it.',
    'Walt Disney'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 17 AND [QuoteText] = 'What you do today can improve all your tomorrows.' AND [Quoter] = 'Ralph Marston')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    17,
    'What you do today can improve all your tomorrows.',
    'Ralph Marston'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 18 AND [QuoteText] = 'The secret of getting ahead is getting started.' AND [Quoter] = 'Mark Twain')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    18,
    'The secret of getting ahead is getting started.',
    'Mark Twain'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 19 AND [QuoteText] = 'Accept the challenges so that you can feel the exhilaration of victory.' AND [Quoter] = 'George S. Patton')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    19,
    'Accept the challenges so that you can feel the exhilaration of victory.',
    'George S. Patton'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 20 AND [QuoteText] = 'With the new day comes new strength and new thoughts.' AND [Quoter] = 'Eleanor Roosevelt')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    20,
    'With the new day comes new strength and new thoughts.',
    'Eleanor Roosevelt'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 21 AND [QuoteText] = 'There is only one corner of the universe you can be certain of improving, and that''s your own self.' AND [Quoter] = 'Aldous Huxley')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    21,
    'There is only one corner of the universe you can be certain of improving, and that''s your own self.',
    'Aldous Huxley'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 22 AND [QuoteText] = 'You can''t cross the sea merely by standing and staring at the water.' AND [Quoter] = 'Rabindranath Tagore')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    22,
    'You can''t cross the sea merely by standing and staring at the water.',
    'Rabindranath Tagore'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 23 AND [QuoteText] = 'Our greatest weakness lies in giving up. The most certain way to succeed is always to try just one more time.' AND [Quoter] = 'Thomas A. Edison')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    23,
    'Our greatest weakness lies in giving up. The most certain way to succeed is always to try just one more time.',
    'Thomas A. Edison'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 24 AND [QuoteText] = 'Ever tried. Ever failed. No matter. Try Again. Fail again. Fail better.' AND [Quoter] = 'Samuel Beckett')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    24,
    'Ever tried. Ever failed. No matter. Try Again. Fail again. Fail better.',
    'Samuel Beckett'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 25 AND [QuoteText] = 'The way to get started is to quit talking and begin doing.' AND [Quoter] = 'Walt Disney')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    25,
    'The way to get started is to quit talking and begin doing.',
    'Walt Disney'
);

IF NOT EXISTS (SELECT [QuoteId] FROM [dbo].[Quote] WHERE [QuoteId] = 26 AND [QuoteText] = 'The will to win, the desire to succeed, the urge to reach your full potential… These are the keys that will unlock the door to personal excellence.' AND [Quoter] = 'Confucius')
INSERT [dbo].[Quote]
(
    [QuoteId],
    [QuoteText],
    [Quoter]
)
VALUES
(
    26,
    'The will to win, the desire to succeed, the urge to reach your full potential… These are the keys that will unlock the door to personal excellence.',
    'Confucius'
);

SET IDENTITY_INSERT [dbo].[Quote] OFF

DBCC CHECKIDENT('dbo.Quote', RESEED, 26)