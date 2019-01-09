use PizzaStoreDB;
go;


insert into PizzaStore.[Location](ModifiedDate)
values 
(getDate())
,(getDate());
;select * from PizzaStore.[Location];

insert into PizzaStore.[User](name,password,ModifiedDate)
values
('High','D03!',getDate())
,('Lover','W@7k1n6',getDate());
;select * from PizzaStore.[User];

insert into PizzaStore.[Order](StoreId,UserId,Cost,TimeStamp)
values
(1,2,24.50,getDate())
,(2,1,36.00,getDate())
;select * from PizzaStore.[Order];

insert into PizzaStore.[Pizza](size,OrderId,ModifiedDate)
values
(14,1,getDate())
,(12,2,getDate())
;select * from PizzaStore.[Pizza];

insert into PizzaStore.[Ingredient](name,ModifiedDate)
values
('Crust',getDate())
,('TomatoSauce',getDate())
,('Mozzarella',getDate())
;select * from PizzaStore.[Ingredient];
