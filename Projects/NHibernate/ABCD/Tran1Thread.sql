--1 --al doilea se executa 
set tran isolation level read committed --default e commited
begin tran 
select * from sectors --nu va putea citi pina cind in Tran2 nu se va face rollback sau commit
where sector_id =1
commit

--2 al doilea se executa 
set tran isolation level read uncommitted
begin tran 
select * from sectors --read dirty data , va citi datele care au fost schimbate dar nu au fost fixate (commit), daca se face rollback in tran2 atunci se iau date gresite 
commit
--3 --primul se executa 
set tran isolation level repeatable read 
begin tran 
select * from sectors --repeatable read  va bloca rindurile selectate ca sa fie schimbate in alta transactie 
commit

--4 --primul se executa 
set tran isolation level repeatable read 
begin tran 
select * from sectors --repeatable read  va bloca rindurile selectate ca sa fie schimbate in alta transactie 
waitfor delay '00:00:05'
select * from sectors --repeatable read  va bloca rindurile selectate ca sa fie schimbate in alta transactie , dar va da voie sa fie introduse noi si vor fi vazute
commit 
select @@TRANCOUNT ,XACT_STATE ()

--5 --primul se executa 
set tran isolation level serializable
begin tran 
select * from sectors --serializable   va bloca rindurile selectate ca sa fie schimbate in alta transactie 
waitfor delay '00:00:05'
select * from sectors --serializable   va bloca rindurile selectate ca sa fie schimbate in alta transactie ,si va bloca sa fie introduse noi si vor fi vazute
commit 
select @@TRANCOUNT ,XACT_STATE ()

