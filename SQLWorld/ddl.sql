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
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Pizza
(
	PizzaID bigint not null primary key identity(1,1)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.[User]
(
	UserID smallint not null primary key identity(1,1)
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

--Transient tables
create table PizzaStore.LocationUser
(
	LocationUserID int primary key identity(1,1)
	,LocationID tinyint foreign key references PizzaStore.Location(LocationID)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
);

create table PizzaStore.LocationOrder
(
	LocationOrderID int primary key identity(1,1)
	,LocationID tinyint foreign key references PizzaStore.Location(LocationID)
	,OrderID int foreign key references PizzaStore.[Order](OrderID)
);

create table PizzaStore.InventoryIngredient
(
	InventoryIngredient int primary key identity(1,1)
	,InventoryID tinyint foreign key references PizzaStore.[Inventory](InventoryID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
);

alter table PizzaStore.[Order]
add constraint CK_Order_Modified check(ModifiedDate=getdate())
go