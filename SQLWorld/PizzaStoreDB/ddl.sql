use PizzaStoreDB;
go

----create
--create database PizzaStoreDB;
--go

--schema

create schema PizzaStore;
go

--tables
create table PizzaStore.Crust
(
CrustID tinyint not null primary key identity(1,1)
,Name nvarchar(50) not null
,CrustFactor decimal(2,2) not null default (01.00)
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

create table PizzaStore.Location
(
	LocationID tinyint not null primary key identity(1,1)
	--,GuidId (not needed)
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


create table PizzaStore.[Order]
(
	OrderID int not null primary key identity(1,1)
	,Voidable bit default(1)
	--,PizzaList transient via OrderPizza
    ,StoreID tinyint foreign key references PizzaStore.[Location](LocationID)
	,UserID smallint foreign key references PizzaStore.[User](UserID)
	,Cost decimal(4,2) default(0.00)
    ,TimeStamp datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.Pizza
(
	PizzaID bigint not null primary key identity(1,1)
	--,toppings transient via PizzaIngredient
	,size tinyint default(10)
	,OrderId int foreign key references PizzaStore.[Order](OrderID)
	,CrustId tinyint foreign key references PizzaStore.[Crust](CrustID)
	,ModifiedDate datetime2(0) not null
	,price decimal(4,2) default(0.00)
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
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

create table PizzaStore.PizzaIngredient --For Pizza.Toppings
(
	PizzaIngredientID bigint primary key identity(1,1)
	,PizzaID bigint foreign key references PizzaStore.Pizza(PizzaID)
	,IngredientID smallint foreign key references PizzaStore.[Ingredient](IngredientID)
	,ModifiedDate datetime2(0) not null
	,Active bit not null default(1)
);

--Inventory of ingredients have been scrapped in this itteration.

--
--
--alterations

alter table PizzaStore.LocationUser
add column ModifiedDate datetime2(0) not null

	




alter table PizzaStore.[Order]
add constraint CK_Order_Modified check(ModifiedDate=getdate())
go

alter table PizzaStore.Crust
alter column CrustFactor decimal(4,2) not null;

alter table PizzaStore.[Pizza]
add price decimal(4,2);

alter table PizzaStore.[Order]
alter column Cost decimal(4,2) not null;

alter table PizzaStore.[User]
alter column 

drop database PizzaStoreDB

