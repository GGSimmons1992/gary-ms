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
