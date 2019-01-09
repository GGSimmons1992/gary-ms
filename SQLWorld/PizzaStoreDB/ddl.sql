use PizzaStoreDB;
go

----create
--create database PizzaStoreDB;
--go

--schema

create schema PizzaStore;
go

--tables
create table PizzaStore.Location
(
	LocationID tinyint not null primary key identity(1,1)
	--,GuidId (not needed)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[Order]
(
	OrderID int not null primary key identity(1,1)
	,Voidable bit default(1)
	--,PizzaList transient via OrderPizza
    ,StoreID tinyint foreign key references PizzaStore.[Location](LocationID)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
	,Cost decimal(4,2)
    ,TimeStamp datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Pizza
(
	PizzaID bigint not null primary key identity(1,1)
	--,toppings transient via PizzaIngredient
	,size tinyint
	,OrderId int foreign key references PizzaStore.[Order](OrderID)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[User]
(
	UserID smallint not null primary key identity(1,1)
	,name varchar(32)
    ,password varchar(32)
	--History transient via UserOrder
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Ingredient
(
	IngredientID smallint not null primary key identity(1,1)
	,Name nvarchar(50) not null --n=unicode 
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

--
--
--Transient tables
create table PizzaStore.LocationUser--For Location.UserList and User.Store
(
	LocationUserID int primary key identity(1,1)
	,LocationID tinyint foreign key references PizzaStore.Location(LocationID)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
);

create table PizzaStore.LocationIngredient --For Location.Inventory
(
	LocationIngredient int primary key identity(1,1)
	,LocationID tinyint foreign key references PizzaStore.[Location](LocationID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
	,InventoryAmount int
);

create table PizzaStore.PizzaIngredient --For Pizza.Toppings
(
	PizzaIngredientID bigint primary key identity(1,1)
	,PizzaID bigint foreign key references PizzaStore.Pizza(PizzaID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
);

--
--
--alterations
alter table PizzaStore.[Order]
add constraint CK_Order_Modified check(ModifiedDate=getdate())
go

drop database PizzaStoreDB

