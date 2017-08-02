CREATE TABLE [dbo].[Operations]
(
	id bigINT NOT NULL PRIMARY KEY,
	inout bit not null,
	Materials_id int,
	quantity decimal not null default 0,
	unitprice decimal not null default 0,
	Currencies_id int not null ,
	amount decimal not null default 0,

	date_time datetime default getdate()
	constraint chk1_Operations check(quantity>=0)
	constraint chk2_Operations check(amount>=0)
)
go
alter table Operations add constraint FK_Operations_Materials_Materials_id foreign key(Materials_id)  references   Materials(id) on delete no action on update no action
go
alter table Operations add constraint FK_Operations_Currencies_Currencies_id foreign key(Currencies_id)  references   Currencies(id) on delete no action on update no action