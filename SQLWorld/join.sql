use adventureworks2019;

select *
from SalesLT.Customer as slc
left join SalesLT.CustomerAddress as slca on slc.CustomerID=slca.CustomerID
where slca.AddressID is null;

select slp.name,slc.firstname,slsoh.TotalDue
from SalesLT.Customer as slc
inner join SalesLT.SalesOrderHeader as slsoh on slsoh.CustomerID=slc.CustomerID
left join SalesLT.SalesOrderDetail as slsod on slsoh.SalesOrderID=slsoh.SalesOrderID
left join SalesLT.Product as slp on slp.ProductID=slsod.ProductID
where slc.FirstName like 'J%' and slsoh.TotalDue>100 and slp.Name like '%touring%';
;

--customers if there first name was james,
--and the order was in july and 
--order costs more than $25
--in touring category

select slc.customerid, slc.lastname,slp.name, slsoh.TotalDue
from SalesLT.Customer as slc
inner join
(
	select customerid,totaldue,salesorderid
	from SalesLT.SalesOrderHeader
	where TotalDue>100
) as slsoh on slsoh.CustomerID=slc.CustomerID
left join SalesLT.SalesOrderDetail as slsod on slsod.SalesOrderID=slsoh.SalesOrderID
inner join
(
	select Name,ProductID
	from SalesLT.Product
	where Name like '%touring%'
)
as slp on slp.ProductID=slsod.ProductID
where slc.FirstName like 'J%';

--j , >100, touring, buying only 1

select slc.customerid, slc.lastname,slp.Name,slsoh.TotalDue
from SalesLT.Customer as slc
inner join
(
	select customerid,totaldue,salesorderid
	from SalesLT.SalesOrderHeader
	where TotalDue>100
) as slsoh on slsoh.CustomerID=slc.CustomerID
inner join
(
 select salesorderid,ProductID,OrderQty
 from SalesLT.SalesOrderDetail
 where OrderQty=1 
) 
as slsod on slsod.SalesOrderID=slsoh.SalesOrderID
inner join
(
	select Name,ProductID
	from SalesLT.Product
	where Name like '%touring%'
)
as slp on slp.ProductID=slsod.ProductID
where slc.FirstName like 'J%';

--all customers and their address
--that bought a product with a cost greater than 10 dollars purhcased in July

select slc.CustomerID,slc.firstname,slc.lastname,sla.AddressLine1,sla.AddressLine2,slsoh.OrderDate
from SalesLT.Customer as slc
inner join
(
	select CustomerID,AddressID
	from SalesLT.CustomerAddress 
) as slca on slca.CustomerID=slc.CustomerID
inner join
(
	select AddressID,AddressLine1,AddressLine2
	from SalesLT.Address
)as sla on sla.AddressID=slca.AddressID
inner join
(
select SalesOrderID,CustomerID,OrderDate
from SalesLT.SalesOrderHeader
where month(orderDate)=6
)as slsoh on slsoh.CustomerID=slc.CustomerID
inner join
(
	select UnitPrice,SalesOrderID
	from SalesLT.SalesOrderDetail
	where unitprice>10
)as slsod on slsod.SalesOrderID=slsoh.SalesOrderID;

;with orders as
(
select customerid,totaldue,salesorderid
	from SalesLT.SalesOrderHeader
	where TotalDue>100
), details as
(
select salesorderid,ProductID,OrderQty
 from SalesLT.SalesOrderDetail
 where OrderQty=1 
), products as
(
select Name,ProductID
	from SalesLT.Product
	where Name like '%touring%'
)select slc.customerid,slc.lastname,products.Name,orders.TotalDue
from SalesLT.Customer as slc
inner join orders on orders.CustomerID=slc.CustomerID
inner join details on details.SalesOrderID=orders.SalesORderID
inner join products on products.ProductID=details.ProductID
where slc.FirstName like 'j%';

---All customer where thier firstname is another customer's last name

select a.firstname,a.LastName,b.firstName,b.lastname
from SalesLT.Customer a, SalesLT.Customer b
where a.firstName=b.lastName;

select b.firstName,c.lastname
from SalesLT.Customer as c
inner join SalesLT.Customer as b on b.firstname=c.lastname
order by b.firstname;

select firstname
from SalesLT.Customer
union
select lastname
from SalesLT.Customer;

select firstname
from SalesLT.Customer
union all
select lastname
from SalesLT.Customer;

select firstname
from SalesLT.Customer
except
select lastname
from SalesLT.Customer;

select firstname
from SalesLT.Customer
intersect
select lastname
from SalesLT.Customer;

select firstname
from SalesLT.Customer
where FirstName not in
(
	select LastName
	from SalesLT.Customer
);

select firstname
from SalesLT.Customer as slc1
where not not exists
(
	select Lastname
	from SalesLT.Customer as slc2
	where slc1.firstname=slc2.LastName
)

select totaldue,modifiedDate
from SalesLT.SalesOrderHeader as slsoh
where ModifiedDate between '2000-01-01 00:00:00:001' and getdate();