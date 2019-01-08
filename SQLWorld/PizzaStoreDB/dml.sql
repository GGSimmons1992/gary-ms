use PizzaStoreDB;
go;

SET IDENTITY_INSERT PizzaStore.[User] ON;  
GO 

SET IDENTITY_INSERT PizzaStore.[Order] OFF;  
GO 

insert into PizzaStore.[Inventory](ModifiedDate)
values
(getDate())
,(getDate())

insert into PizzaStore.[Location](InventoryID,ModifiedDate)
values 
(1,getDate())
,(2,getDate());

insert into PizzaStore.[User](name,password,LastVist,ModifiedDate)
values
('High','D03!',6,getDate())
,('Lover','W@7k1n6',7,getDate());

insert into PizzaStore.[Order](TimeStamp,ModifiedDate)
values
(getDate(),getDate())
,(getDate(),getDate());

insert into PizzaStore.[Pizza](size,ModifiedDate)
values
(14,getDate())
,(12,getDate());

select * from PizzaStore.[Order];
