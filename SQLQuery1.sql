--select * from TblEmployee where EmployeeDepartmentId=(select DepartmentId from TblDepartment where DepartmentName='Yazýlým')
--select EmployeeCity from TblEmployee where EmployeeDepartmentId=(select DepartmentId from TblDepartment where DepartmentName='Muhasebe')
--select COUNT(*) from TblEmployee
--select sum(EmployeeSalary) from TblEmployee
--select max(EmployeeSalary) from TblEmploye
--select * from TblEmployee where EmployeeSalary=(select max(EmployeeSalary) from TblEmployee )
--select max(EmployeeSalary) from TblEmployee 


--UPDATE TblEmployee SET EmployeeSalary=EmployeeSalary+EmployeeSalary*0.5 where EmployeeSalary=(select MAX(EmployeeSalary) from TblEmployee)

--select * from TblEmployee

--select EmployeeCity,count(*) toplam from TblEmployee group by EmployeeCity

--select EmployeeName,EmployeeSurname,EmployeeSalary,EmployeeSalary*1.25 as zamlýmaas from TblEmployee

--select EmployeeName+' '+EmployeeSurname 'Personel' ,DepartmentName from TblEmployee as e
--inner join TblDepartment as dp on
--e.EmployeeDepartmentId=dp.DepartmentId

--create procedure employeeListDepartment
--as
--select EmployeeName+' '+EmployeeSurname 'Personel' ,DepartmentName from TblEmployee as e
--inner join TblDepartment as dp on
--e.EmployeeDepartmentId=dp.DepartmentId

--exec employeeListDepartment


--create table TblEmployeeCount
--(
--	StaffCount int
--)

--insert into TblEmployeeCount (StaffCount) values (0)

--select * from TblEmployeeCount

--UPDATE TblEmployeeCount SET StaffCount=(select count(*) from TblEmployee)

--create trigger IncreaseEmployeeCount
--on TblEmployee
--After Insert 
--as
--update TblEmployeeCount set StaffCount+=1

--create trigger DecreaseEmployeeCount
--on TblEmployee
--After Delete 
--as
--update TblEmployeeCount set StaffCount -= 1