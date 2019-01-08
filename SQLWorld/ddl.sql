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
	,InventoryID tinyint foreign key references PizzaStore.[Inventory](InventoryID)
	,Sales numeric(9,2) default(0) --Ledger
	--,GuidId (not needed)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[Order]
(
	OrderID int not null primary key identity(1,1)
	,Voidable bit default(1)
	--,PizzaList transient via OrderPizza
    ,TimeStamp dateTime2(0) not null
    ,StoreID tinyint foreign key references PizzaStore.Location(LocationID)
	,Cost decimal(4,2)
    ,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Pizza
(
	PizzaID bigint not null primary key identity(1,1)
	--,toppings transient via PizzaIngredient
	,size tinyint
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[User]
(
	UserID smallint not null primary key identity(1,1)
	,name varchar(32)
    ,password varchar(32)
	--History transient via UserOrder
    ,LastVist tinyint foreign key references PizzaStore.Location(LocationID)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[Inventory]
(
	InventoryID tinyint not null primary key identity(1,1)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Ingredient
(
	IngredientID smallint not null primary key identity(1,1)
	,Name nvarchar(50) not null --n=unicode
	,InventoryAmount int 
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

--
--
--Transient tables
create table PizzaStore.LocationUser
(
	LocationUserID int primary key identity(1,1)
	,LocationID tinyint foreign key references PizzaStore.Location(LocationID)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
);

create table PizzaStore.InventoryIngredient
(
	InventoryIngredient int primary key identity(1,1)
	,InventoryID tinyint foreign key references PizzaStore.[Inventory](InventoryID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
);

create table PizzaStore.OrderPizza
(
	OrderPizzaID bigint primary key identity(1,1)
	,PizzaID bigint foreign key references PizzaStore.Pizza(PizzaID)
	,OrderID int foreign key references PizzaStore.[Order](OrderID)
);

create table PizzaStore.PizzaIngredient
(
	PizzaIngredientID bigint primary key identity(1,1)
	,PizzaID bigint foreign key references PizzaStore.Pizza(PizzaID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
);

create table PizzaStore.UserOrder
(
	UserOrder int primary key identity(1,1)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
	,OrderID int foreign key references PizzaStore.[Order](OrderID)
)

--
--
--alterations
alter table PizzaStore.[Order]
add constraint CK_Order_Modified check(ModifiedDate=getdate())
go

drop database PizzaStoreDB

