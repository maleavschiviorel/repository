--select users.login,  Rights.name ,*  from users inner join UserRole on Users.UserRole_id= UserRole.id inner join RoleRights  on RoleRights.UserRole_id  =UserRole.id inner join Rights on RoleRights.Rights_id =Rights.id      
--select Users.* from Users  where USERs.Persons_id is null 
--select materials.name from  materials  where Materials.name like '%to' 

--select Materials.name, TypeOfMesure.type   from materials inner join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id 
--where TypeOfMesure.type in ('kg','l')
--order by Materials.name    

--select *from materials full outer join TypeOfMesure on Materials.TypeOfMesure_id =TypeOfMesure.id  
