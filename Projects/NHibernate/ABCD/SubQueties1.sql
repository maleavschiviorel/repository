--1
select First_Name, Last_Name, City ,State  
from customers
where State =(select cst.state from customers cst where cst.Customer_Id =170 ) 
--2
select pack_id ,speed ,sector_id  
from packages 
where 
sector_id =(select pkg.sector_id from packages pkg where pkg.pack_id =10)
--3
select First_Name, Last_Name, Join_Date 
from customers
where Join_Date >(select Join_Date from customers  cst where cst.Customer_Id =540 ) 
--4
declare @date as datetime
set @date= (select cst.Join_Date
            from customers cst
			where  Customer_Id=372 )

select cst.First_Name,  cst.Last_Name, cst.Join_Date  
      from customers  cst 
where 
month(cst.Join_Date  )=month(@date )
and 
Year(cst.Join_Date  )=Year(@date )
--5
select First_Name, Last_Name, City ,State , pack_id  
from customers  cst
where '5Mbps' = (select speed 
                 from  packages pkg 
                 where pkg.pack_id= cst.pack_id
				 ) 
order by pack_id ,First_Name ,Last_Name 

--6 
select pack_id ,speed ,strt_date  
from packages t
where 
YEAR(t.strt_date ) =(select YEAR(pkg.strt_date ) 
                     from packages pkg 
					 where pkg.pack_id =7
					 )

--7
select First_Name,monthly_discount , pack_id ,main_phone_num ,secondary_phone_num  
from customers  cst
where 'Business' = (select sectors.sector_name   
                    from  packages pkg  inner join sectors on pkg.sector_id =sectors.sector_id   
					where pkg.pack_id= cst.pack_id) 

--8
select First_Name,monthly_discount , customers.pack_id
from customers  left join packages on customers.pack_id =packages.pack_id   
where packages.monthly_payment  > (select avg(pkg.monthly_payment )
                                   from customers cst left join packages pkg on cst.pack_id =pkg.pack_id  )
								   
--9 
select First_Name,City , State, Birth_Date, monthly_discount     
from customers t
where Birth_Date = (select cst.Birth_Date 
                    from customers cst 
					where cst.Customer_Id =179  ) 
    and  t.monthly_discount> 
	                (select cst1.monthly_discount 
					from customers cst1 
					where cst1.Customer_Id =107  
					) 

--10
select * from packages t
where t.speed =(select pkg.speed 
                from packages pkg 
				where pkg.pack_id =30
				) 
	and 
       t.monthly_payment >
	              (select pkg1.monthly_payment 
				   from packages pkg1 
				   where pkg1.pack_id =7  
				   )

--11 
select pack_id, speed , monthly_payment  from packages t
where 
t.monthly_payment >(select max(pkg.monthly_payment ) 
                    from packages pkg 
					where pkg.speed ='5Mbps'
					)
  
--12 
select pack_id, speed , monthly_payment  
from packages t
where 
t.monthly_payment >(select min(pkg.monthly_payment ) 
                    from packages pkg 
					where pkg.speed ='5Mbps')

--13 
select pack_id, speed , monthly_payment  
from packages t
where 
t.monthly_payment <(select min(pkg.monthly_payment ) 
                    from packages pkg 
					where pkg.speed ='5Mbps')         

--14								    
select First_Name,monthly_discount,pack_id    
from customers t
where 
t.monthly_discount <(select avg(cst.monthly_discount ) 
                           from customers cst) 
		and
         t.pack_id =(select cst1.pack_id 
	                 from customers cst1 
					 where cst1.First_Name  ='Kevin')
      
