CREATE TABLE [dbo].Orders
(
	id bigINT identity(1,1) NOT NULL PRIMARY KEY,
	inout bit not null,
	Users_id int,
	Materials_id int,
	quantity decimal not null default 0,
	unitprice decimal not null default 0,
	Currencies_id int not null ,
	amount decimal not null default 0,

	date_time datetime default getdate(),
	commited bit 

	constraint chk1_Orders check(quantity>=0)
	constraint chk2_Orders check(amount>=0)


)
go
alter table Orders add constraint FK_Orders_Materials_Materials_id foreign key(Materials_id)  references   Materials(id) on delete no action on update no action
go
alter table Orders add constraint FK_Orders_Currencies_Currencies_id foreign key(Currencies_id)  references   Currencies(id) on delete no action on update no action
go
alter table Orders add constraint FK_Orders_Users_Users_id foreign key(Users_id)  references   Users(id) on delete no action on update no action
go 
create index  in_Orders_date_time on Orders(date_time)