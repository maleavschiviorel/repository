-- afiseaza toti customerii si nr de customeri din  pachetul customerului curent
select first_name, last_name,pack_id, (select count(*) from customers as cst  where cst.pack_id  =   t.pack_id   ) nr_customers_with_same_package 
from customers t
order by customer_id
--order by pack_id 

-- afiseaza doar customerii din pachetele ce au mai mult de 80 customeri
select first_name, last_name,pack_id from customers t
where 
(select count(*) from customers as cst  where cst.pack_id  =   t.pack_id   )>80
order by customer_id

--afiseaza acele pachete pentru care plata toatala a customerilor pentru acel pachet e mai mare decit plata customerilor de pe pachaetul 39
select t.pack_id,count (p.monthly_payment ) 
from customers t left join packages p on t.pack_id =p.pack_id   
group by t.pack_id 
having 
count (p.monthly_payment )  >(select count (p1.monthly_payment ) 
                              from customers t1 left join packages p1 on t1.pack_id =p1.pack_id   
							  where  t1.pack_id=39    )
 

 -- select customerii din orasul Chicago  si  Philadelphia
 select * from customers 
 where City in ('Chicago','Philadelphia')

 -- afiseaza acei customeri  din acele pachete in care exista customeri ce au discount >29
 select * from customers t 
 where exists(select * from customers cst where cst.pack_id =t.pack_id and  cst.monthly_discount>29 )
 order by t.pack_id  desc, monthly_discount  desc

-- afiseaza acei customeri  din acele pachete in care exista customeri ce au discount <29
 select * from customers t 
 where 29<any(select cst.monthly_discount from customers cst where cst.pack_id =t.pack_id)
 order by t.pack_id  desc

 -- afiseaza customerii  din acele pachete  customerii carora toti au monthly_payment>8100
 select * from customers t
 where  
 t.pack_id is not null and
 8100<all(select pkg.monthly_payment   from customers cst inner join packages as pkg 
                                        on cst.pack_id= pkg.pack_id where cst.pack_id =t.pack_id)
 order by t.pack_id  desc

 --afiseaza vitezele pachetelor si nr de pachete din acea viteza cu monthly_payment >100 si monthly_payment <100
 select t.speed,
 count(case when t.monthly_payment >100 then 1 end) as'nr of pkg with monthly_payment >100',
 count(case when t.monthly_payment <100 then 1 end)as 'nr of pkg with monthly_payment <100'
 from packages t
 group by t.speed


---devision
begin tran
begin try
 drop table #C
 drop table #A
 drop table #B
end try
begin catch
end catch

create table #A(a1 int, a2 nvarchar(10)  )
insert into #A(a1,a2) values(1,'a1'),(2,'a2'),(3,'a3')
create table #B(b1 int, b2 nvarchar(10)  )
insert into #B(b1,b2) values(1,'b1'),(2,'b2')
--create table #C(c1 nvarchar(10), c2 nvarchar(10)  ) nu trebuie creata
select #A.a2, #B.b2 into #C from #A cross join #B

insert into #C(a2,b2) values('c1','c2')
select * from #C
commit;


--division
select #C.a2 from #C
where  #C.b2 in ('b1','b2')
group by #C.a2
having --count(#C.b2)=2
count(#C.b2)=(select count(*) from #C as t where t.a2 =#C.a2  )
-----------------------------------------------------------------------------------------

