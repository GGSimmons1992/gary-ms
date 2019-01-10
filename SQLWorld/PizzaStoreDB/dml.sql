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
('High','D03!',dbo.ESTNow())
,('Lover','W@7k1n6',dbo.ESTNow());
;select * from PizzaStore.[User];

insert into PizzaStore.[Order](StoreId,UserId,Cost,TimeStamp)
values
(1,2,((0.75*14)*(0.50*2)),getDate())
,(2,1,((0.75*12)*(0.50*3)),getDate())
;select * from PizzaStore.[Order];

update p
set TimeStamp=dbo.ESTNow()
from PizzaStore.[Order] as p;

insert into PizzaStore.[Pizza](size,OrderId,ModifiedDate)
values
(14,2,dbo.ESTNow())
,(12,3,dbo.ESTNow())
;select * from PizzaStore.[Pizza];

insert into PizzaStore.[LocationUser](LocationID,UserID)
values
(1,2)
,(2,1)
;select * from PizzaStore.[LocationUser]

insert into PizzaStore.[LocationIngredient](LocationID,IngredientID,InventoryAmount)
values
(1,1,40)
,(1,2,65)
,(1,3,7)
,(1,4,9)
,(2,1,9)
,(2,2,13)
,(2,3,88)
,(2,4,16);

;select * from PizzaStore.[LocationIngredient]

insert into PizzaStore.[PizzaIngredient](PizzaID,IngredientID)
values
(1,2)
,(1,3)
,(2,2)
,(2,3)
,(2,4)
;select * from PizzaStore.[PizzaIngredient]

--Select all

 delete from PizzaStore.[Location] where locationID=3;

select * from PizzaStore.[Ingredient];
select * from PizzaStore.[User];
select * from PizzaStore.[Location];
select * from PizzaStore.[Order];
select * from PizzaStore.[Pizza];
select * from PizzaStore.[LocationUser];
select * from PizzaStore.[LocationIngredient];
select * from PizzaStore.[PizzaIngredient];

--Trial stuff
select sysdatetime() as regular,[dbo].fn_EST(GetDate()) as offset,[dbo].ESTNow() as test;