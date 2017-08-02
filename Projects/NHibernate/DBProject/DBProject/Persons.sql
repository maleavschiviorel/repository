create table Persons(id int primary key identity(1,1), name nvarchar(50), surname nvarchar(50))
go
alter  table Persons add constraint uc_Persons unique(name,surname)
go
