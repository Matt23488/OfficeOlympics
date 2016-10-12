declare @Id int = 12

set nocount on

select * from OlympicEvent

delete Witness where RecordId in (select RecordId from Record where OlympicEventId > @Id)
delete Record where OlympicEventId > @Id
delete OlympicEvent where OlympicEventId > @Id

dbcc checkident('dbo.OlympicEvent', reseed, @Id)

select * from OlympicEvent