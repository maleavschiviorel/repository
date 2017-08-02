CREATE TABLE [dbo].[Stock]
(
	id INT NOT NULL PRIMARY KEY,
	Materials_id int,
	quantity decimal not null default 0,
	amount decimal not null default 0,
	Currencies_id int not null ,
	date_time datetime default getdate()
	constraint chk1_Stock check(quantity>=0)
	constraint chk2_Stock check(amount>=0)
)
go

alter table Stock add constraint FK_Materials foreign key(Materials_id)  references   Materials(id) on delete no action on update no action
go
alter table Stock add constraint FK_Stock_Currencies_Currencies_id foreign key(Currencies_id)  references   Currencies(id) on delete no action on update no action
go

