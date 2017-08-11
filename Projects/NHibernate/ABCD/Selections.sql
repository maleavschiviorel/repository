select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed   
from customers inner join packages on customers.pack_id = packages.pack_id 
order by packages.pack_id, First_Name asc, Last_Name asc

select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed   
from customers inner join packages on customers.pack_id = packages.pack_id 
where packages.pack_id =22 or packages.pack_id =27
order by Last_Name asc

select packages.pack_id, packages.monthly_payment ,packages.speed, sectors.sector_name  
from packages inner join sectors on packages.sector_id =sectors.sector_id 
order by sector_name 

select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,sectors.sector_name   
from customers inner join packages on customers.pack_id = packages.pack_id 
inner join sectors on packages.sector_id =sectors.sector_id 
order by packages.pack_id, First_Name asc, Last_Name asc

select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,sectors.sector_name   
from customers inner join packages on customers.pack_id = packages.pack_id 
inner join sectors on packages.sector_id =sectors.sector_id 
where sector_name like '%usines%'
order by packages.pack_id, First_Name asc, Last_Name asc

select customers.Last_Name , customers .First_Name, packages.pack_id, packages.speed ,sectors.sector_name   
from customers inner join packages on customers.pack_id = packages.pack_id 
inner join sectors on packages.sector_id =sectors.sector_id 
where sector_name like 'Private' and year(customers.Join_Date )=2006
order by packages.pack_id, First_Name asc, Last_Name asc


select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,packages.monthly_payment   
from customers inner join packages on customers.pack_id = packages.pack_id 
order by packages.pack_id, First_Name asc, Last_Name asc

select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,packages.monthly_payment   
from customers left join packages on customers.pack_id = packages.pack_id 
order by packages.pack_id, First_Name asc, Last_Name asc

select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,packages.monthly_payment   
from customers right join packages on customers.pack_id = packages.pack_id 
order by packages.pack_id, First_Name asc, Last_Name asc


select customers.First_Name , customers .Last_Name, packages.pack_id, packages.speed ,packages.monthly_payment   
from customers full outer join packages on customers.pack_id = packages.pack_id 
order by packages.pack_id, First_Name asc, Last_Name asc

