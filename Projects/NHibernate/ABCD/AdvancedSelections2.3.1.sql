if OBJECT_ID('#sectors1','u') is not null
 drop table #sectors1
create table #sectors1( id int, name nvarchar(10))
insert into  #sectors1(id,name) values(3,'sector11'),(4,'sector12'),(5,'sector13')
insert into sectors ( sector_name ) select name from #sectors1 
select * from sectors  

truncate table customers

delete pkg from packages as pkg inner join sectors on pkg.sector_id = sectors.sector_id   
where sectors.sector_name like '%Private%' 

select * from  packages as pkg inner join sectors on pkg.sector_id = sectors.sector_id   
where sectors.sector_name like '%Private%' 


update pkg 
set pkg.monthly_payment =pkg.monthly_payment +1000 
output deleted.monthly_payment ,inserted.monthly_payment   
from packages as pkg inner join sectors on pkg.sector_id = sectors.sector_id   
where sectors.sector_name like '%siness%' 

select * from  packages as pkg inner join sectors on pkg.sector_id = sectors.sector_id   
where sectors.sector_name like '%siness%' 

--rank
select sector_id,speed,monthly_payment, RANK() over(partition by speed order by monthly_payment desc)   from packages 

--merge 
--if OBJECT_ID('#StateCity','U')  is not null
 begin try
 drop table #StateCity
 end try
 begin catch 
 end catch
create table #StateCity(state nvarchar(30),city nvarchar(40))

insert into #StateCity(state) select distinct state from customers
delete  from  #StateCity where state ='Alabama'
insert into #StateCity(state) values('CHishinau'),('Balti')

select * from #StateCity order by state 
merge into #statecity as sc
using
(select state,min(city) as maxcity ,[rank] from
                         (select State ,City , RANK() over(partition by state order by count(city) desc) as [rank]  from customers 
                            group by State , city
                            ) as scr 
							group by state, [rank]
						) as scr1 on sc.state=scr1.state

when matched and scr1.rank=1 then update-- sursa si destinatia au acelasi tind cu sc.state=scr1.state

set sc.city=scr1.maxcity

when not matched by source then update --- sursa(din using) nu are acest rind cu sc.state=scr1.state

set sc.city='not specified'

when not matched by target  and scr1.rank=1 then --- destinatia nu are acest rind cu sc.state=scr1.state
insert (state, city) values(scr1.state+'!', scr1.maxcity+'!');
select * from #StateCity order by state 

--------------
 begin try
 drop table #StateCity
 end try
 begin catch 
 end catch
create table #StateCity(state nvarchar(30),city nvarchar(40))

insert into #StateCity(state) 
output inserted.state  
select distinct state from customers

delete  from  #StateCity 
output deleted.state  
where state ='Alabama'


