create table Users(id int primary key identity(1,1), Persons_id int ,login nvarchar(30) not null unique, pass nvarchar(30), UserRole_id int)
go
alter table Users add constraint FK_Persons foreign key (Persons_id) references Persons(id) on delete no action on update no action
go
alter table Users add constraint FK_UserRole foreign key (UserRole_id) references UserRole(id) on  delete no action on update no action
go