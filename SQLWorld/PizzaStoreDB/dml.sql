use PizzaStoreDB;
go

drop function fn_ToEasternTime;
go

create function fn_EST(@utcTime datetime2(0))
returns datetime2(0)
as
begin
	return cast(switchoffset(@utcTime,'-05:00') as datetime2(0))
	--switchoffset(@utcTime,'-05:00')
end;
go

create function ESTNow()
returns datetime2(0)
as
begin
	return [dbo].fn_EST(GetDate()) 
end;
go

insert into PizzaStore.[Ingredient](Name,ModifiedDate)
values
('Crust',dbo.ESTNow())
,('TomatoSauce',dbo.ESTNow())
,('Mozzarella',dbo.ESTNow())
,('Pepperoni',dbo.ESTNow())
,('Mushrooms',dbo.ESTNow())
,('Anchovies',dbo.EstNow());
;select * from PizzaStore.[Ingredient];

insert into PizzaStore.[Crust](Name,CrustFactor,ModifiedDate)
values
('Regular',1.00,dbo.ESTNow())
,('Stuffed',1.50,dbo.ESTNow())
,('Thin',1.25,dbo.ESTNow())
,('Deep Dish',1.75,dbo.ESTNow());


insert into PizzaStore.[Location](ModifiedDate)
values 
(dbo.ESTNow())
,(dbo.ESTNow());
;select * from PizzaStore.[Location];

insert into PizzaStore.[User](name,password,ModifiedDate)
values
('Hugo','D03!',dbo.ESTNow())
,('Liv','W@7k1n6',dbo.ESTNow());
;select * from PizzaStore.[User];


--CliClient will insert our transient and dependancy data for now. 

--Select everything
select * from PizzaStore.Crust;
select * from PizzaStore.[Ingredient];
select * from PizzaStore.[User];
select * from PizzaStore.[Location];
select * from PizzaStore.[Order];
select * from PizzaStore.[Pizza];
select * from PizzaStore.[LocationUser];
select * from PizzaStore.[PizzaIngredient];

--delete everyting
delete from PizzaStore.[Crust];
delete from PizzaStore.[Ingredient];
delete from PizzaStore.[User];
delete from PizzaStore.[Location];
delete from PizzaStore.[Order];
delete from PizzaStore.[Pizza];
delete from PizzaStore.[LocationUser];
delete from PizzaStore.[PizzaIngredient];

insert into PizzaStore.[User](name,password,ModifiedDate)
values
('Guinea','P!6',dbo.ESTNow())

--Trial stuff
select sysdatetime() as regular,[dbo].fn_EST(GetDate()) as offset,[dbo].ESTNow() as test;