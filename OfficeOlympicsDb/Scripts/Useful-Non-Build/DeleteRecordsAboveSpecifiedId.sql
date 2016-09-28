declare @Id int = 0

set nocount on;

select * from Record

delete [Witness] where RecordId > @Id
delete Record where RecordId > @Id
dbcc checkident('dbo.Record', reseed, @Id)

select * from record