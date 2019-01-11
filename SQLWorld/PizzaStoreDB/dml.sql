use PizzaStoreDB;
go;

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
,('Pepperoni',dbo.ESTNow());
;select * from PizzaStore.[Ingredient]

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

insert into PizzaStore.[Order](StoreId,UserId,Cost,TimeStamp)
values
(7,7,((0.75*14)*(0.50*2)),dbo.ESTNow())
,(8,6,((0.75*12)*(0.50*3)),dbo.ESTNow())
;select * from PizzaStore.[Order];

update p
set TimeStamp=dbo.ESTNow()
from PizzaStore.[Order] as p;

insert into PizzaStore.[Pizza](size,OrderId,ModifiedDate)
values
(14,8,dbo.ESTNow())
,(12,9,dbo.ESTNow())
;select * from PizzaStore.[Pizza];

update u
set name='Hugo'
from PizzaStore.[User] as u
where name='High';

insert into PizzaStore.[LocationUser](LocationID,UserID)
values
(7,7)
,(8,6)
;select * from PizzaStore.[LocationUser]

insert into PizzaStore.[LocationIngredient](LocationID,IngredientID,InventoryAmount)
values
(7,11,40)
,(7,12,65)
,(7,13,7)
,(7,14,9)
,(8,11,9)
,(8,12,13)
,(8,13,88)
,(8,14,16);

;select * from PizzaStore.[LocationIngredient]

insert into PizzaStore.[PizzaIngredient](PizzaID,IngredientID)
values
(4,12)
,(4,13)
,(5,12)
,(5,13)
,(5,14)
;select * from PizzaStore.[PizzaIngredient]

--Select all

--Mistakes were made
 delete from PizzaStore.[Location] where locationID=3;
 delete from PizzaStore.[Order] where OrderID=4;

--Select everything
select * from PizzaStore.[Ingredient];
select * from PizzaStore.[User];
select * from PizzaStore.[Location];
select * from PizzaStore.[Order];
select * from PizzaStore.[Pizza];
select * from PizzaStore.[LocationUser];
select * from PizzaStore.[LocationIngredient];
select * from PizzaStore.[PizzaIngredient];

delete from PizzaStore.[Ingredient];
delete from PizzaStore.[User];
delete from PizzaStore.[Location];
delete from PizzaStore.[Order];
delete from PizzaStore.[Pizza];
delete from PizzaStore.[LocationUser];
delete from PizzaStore.[LocationIngredient];
delete from PizzaStore.[PizzaIngredient];

insert into PizzaStore.[User](name,password,ModifiedDate)
values
('Guinea','P!6',dbo.ESTNow())

--Trial stuff
select sysdatetime() as regular,[dbo].fn_EST(GetDate()) as offset,[dbo].ESTNow() as test;