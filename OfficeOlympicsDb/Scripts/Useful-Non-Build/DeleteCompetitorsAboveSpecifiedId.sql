declare @Id int = 5

set nocount on

select * from Competitor

delete Witness where CompetitorId > @Id -- Covers witnesses that are the deleted competitors
	or RecordId in (select RecordId from Witness where CompetitorId > @Id) -- Covers cowitnesses of deleted competitors
	or RecordId in (select RecordId from Record where CompetitorId > @Id) -- Covers witnesses of records held by deleted competitors
delete Record where CompetitorId > @Id
	or RecordId not in (select RecordId from Witness)
delete Competitor where CompetitorId > @Id

dbcc checkident('dbo.Competitor', reseed, @Id)

select * from Competitor