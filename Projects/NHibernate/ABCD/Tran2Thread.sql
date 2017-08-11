--1--primul se executa 
begin tran
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_id =1 
waitfor delay '00:00:05'
rollback
select @@TRANCOUNT ,XACT_STATE ()

--2--primul se executa 
begin tran
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_id =1 
waitfor delay '00:00:05'
rollback
select @@TRANCOUNT ,XACT_STATE ()

--3  al doilea se executa 
begin tran
update sectors set sectors.sector_name =sectors.sector_name+'!' -- nu va fi updatat pina nu se termina tran1
where sectors.sector_id =1 
rollback
select @@TRANCOUNT ,XACT_STATE ()

--4  al doilea se executa 
begin tran
insert into sectors (sector_name ) values('aaaa') -- va putea fi introdusa
commit
select @@TRANCOUNT ,XACT_STATE ()

--5  al doilea se executa 
begin tran
insert into sectors (sector_name ) values('bbbbb') --nu va putea fi introdusa pina nu se termina tran1
commit
select @@TRANCOUNT ,XACT_STATE ()

--1004 
begin tran
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_id =1 
commit
select @@TRANCOUNT ,XACT_STATE ()

----nested transactions
begin tran
insert into sectors (sector_name ) values('aaaa') 
begin tran 
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_name  ='aaaa'
rollback
commit-- da eroare pentru ca rollback a anulat transactiile 

begin tran
insert into sectors (sector_name ) values('aaaa') 
begin tran 
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_name  ='aaaa'
commit
rollback-- anuleaza updatul si insertul (anuleaza toate operatiile incluse)

select @@TRANCOUNT ,XACT_STATE ()
----------------------------------------
--implicit transactions
set implicit_transactions on
insert into sectors (sector_name ) values('aaaa2') 
update sectors set sectors.sector_name =sectors.sector_name+'!'
where sectors.sector_name  ='aaaa2'
commit
--rollback
set implicit_transactions off
