
create table RoleRights(id int primary key identity (1,1),UserRole_id int , Rights_id int )
go
alter table RoleRights add constraint FK1_UserRole foreign key (UserRole_id) references UserRole(id) on delete no action on update no action 
go
alter table RoleRights add constraint FK2_UserRight foreign key (Rights_id) references Rights(id) on delete no action on update no action
go