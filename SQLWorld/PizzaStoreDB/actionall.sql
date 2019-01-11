use PizzaStoreDB;
go

--view  --Special Access to a table  which normally is restricted to a database user


--Only temporaily work w/o schemabinding (schemabinding is key restricing)
--Need Crust and Size tables
--need crust.Name, size.sizeId, and crust.crustId
create view GetCrusts
as 
(
select Name
from PizzaStore.Crust as c
inner join PizzaStore.Size as s on s.SizeId=c.CrustId 
);
go

select * from vw_GetCrusts;
go

--functions reusable and moldable views 2 types (scalar and tabular)
--scalar
create function fn_CountCrusts(@countId int)
returns int
as
begin
	declare @counter int;

	select @counter=count(*)
	from PizzaStore.Crusts
	where CrustID <= @CountId
	return @counter
end;
go

select * from PizzaStore.Crust where CrustID=fn_CountCrusts(1);
go

--tabular
create function CountCrusts2(@Id int)
returns table
as
	return select Name
	from PizzaStore.Crust
	where CrustId>=@id
go

select * from fn_CountCrusts(2);
go

--stored procedures (lazy proc, smug procedure)
create procedure pr_SetUser(@name nvarchar(50),@street nvarchar(50),@city nvarchar(50),@addressId int output)
as
begin
   declare @addressId int;

   select @addressId=AddressId from 
   PizzaStore.[Address]
   where Street=@street,City=@city

   begin transaction
	   if (@addressId>0)
	   begin
		insert into PizzaStore.[User](Name,AddressId)
		values
		(@name,@addressId)
	   end
	   else
	   begin
		insert into PizzaStore.[Address]([City],[Street])
		output @addressId=inserted(AddressId)
		values (@city,@street)

		insert into PizzaStore.[User]([Name],[AddressId])
		values (@name,@addressId)

	   end
	  commit transaction
	end

end;
go

--How to use it (lazy exec, smug execute)
declare @id int;
execute pr_SetUser 'fred','fowler','tampa bay', @id output;

