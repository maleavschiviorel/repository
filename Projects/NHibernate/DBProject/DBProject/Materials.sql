CREATE TABLE Materials
( 
id int identity(1,1) primary key clustered not null,
name NVARCHAR(100) not null, 
TypeOfMaterial_Id int, 
TypeOfMesure_id int)

go
alter table Materials add constraint FK1_TypeOfMaterial foreign key(TypeOfMaterial_Id) references dbo.TypeOfMaterial(id) on delete no action on update no action
go
alter table Materials add constraint FK1_TypeOfMesure foreign key (TypeOfMesure_id) references TypeOfMesure(id) on delete no action on update no action