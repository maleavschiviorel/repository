select min(customers.Last_Name  ) from customers 
select avg(monthly_payment ) from packages 
select max(customers.Last_Name  ) from customers 

select count (*) from packages
select count (*) from customers 

select * from customers
select count (*) from 
(
select State  from customers 
group by state) as gr


select count (* ) from (select speed  from packages group by speed ) as gr

select count (*) from customers where fax is not null
select count (*) from customers where fax is  null

select max(monthly_discount) as max_monthly_discount, min(monthly_discount ) as min_monthly_discount, avg(monthly_discount ) as avg_monthly_discount  from customers 

--2
select state,  count (* ) as nr_customers from customers group by State order by State 
select speed, AVG(monthly_payment ) as avg_monthly_payment  from packages group by speed 

select state, count(*) as nr_cities from (select distinct city, state from customers   ) as sl group by State 

select sector_id, max(monthly_payment)   from packages group by sector_id 

select pack_id,AVG(monthly_discount ) as avg_monthly_discount  from customers group by pack_id  order by pack_id 




select pack_id,AVG(monthly_discount ) as avg_monthly_discount  from customers where pack_id in (13,22) group by pack_id  order by pack_id 

select max(monthly_payment ) as max_monthly_payment, min(monthly_payment ) as min_monthly_payment, AVG(monthly_payment ) as avg_monthly_payment from packages group by speed 
order by max_monthly_payment desc

select pack_id,count(*) nr_customers from customers group by pack_id 
order by pack_id



select pack_id,count(*) nr_customers from customers where monthly_discount >20 group by pack_id 
order by nr_customers desc


select pack_id,count(*) as nr_customers 
from customers 
where monthly_discount >20 
group by pack_id 
having count(*) >20
order by pack_id


select state, city, count (*) as nr_customers from customers group by state, City  
order by State,city

select city, avg(monthly_discount ) as avg_monthly_discount from customers group by City 
order by city

select city, avg(monthly_discount ) as avg_monthly_discount from customers
where monthly_discount >20 
group by City 
order by city

select state, min(monthly_discount ) as min_monthly_discount from customers group by State 
having  min(monthly_discount ) >10
order by State 

select speed, count(* ) as nr_packages  from packages
group by speed 
having  count(* ) >8