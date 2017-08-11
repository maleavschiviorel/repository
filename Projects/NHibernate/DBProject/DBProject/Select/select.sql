
select users.login,  Rights.name ,*  
from users inner join UserRole on Users.UserRole_id= UserRole.id 
           inner join RoleRights  on RoleRights.UserRole_id  =UserRole.id 
		   inner join Rights on RoleRights.Rights_id =Rights.id 
		        
select Users.* 
from Users  
where USERs.Persons_id is null 

select materials.name 
from  materials  
where Materials.name like '%to' 

select Materials.name, TypeOfMesure.type   
from materials inner join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id 
where TypeOfMesure.type in ('kg','l')
order by Materials.name    

select *
from materials full outer join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  

select *
from materials  left join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  

select *
from materials  right join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  

select *
from materials  left join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  
where TypeOfMesure.id  is null  

select *
from materials  right join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  
where  Materials.TypeOfMesure_id is null  

select *from materials  full outer join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  
where Materials.TypeOfMesure_id is null or TypeOfMesure.id is null   

select materials.name, typeofmesure.type 
from materials cross join TypeOfMesure
