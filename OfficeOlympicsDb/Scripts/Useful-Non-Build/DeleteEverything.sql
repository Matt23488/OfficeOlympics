set nocount on

delete Error
dbcc checkident('dbo.Error', reseed, 0)

delete Witness
dbcc checkident('dbo.Witness', reseed, 0)

delete Record
dbcc checkident('dbo.Record', reseed, 0)

delete Competitor
dbcc checkident('dbo.Competitor', reseed, 0)

delete OlympicEvent
dbcc checkident('dbo.OlympicEvent', reseed, 0)

--delete EventType
--dbcc checkident('dbo.EventType', reseed, 0)