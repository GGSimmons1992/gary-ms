use adventureworks2019;
go

select 1+1;
select 'fred'+1;
select 'fred' + 'belotte';

select FirstName,LastName
from SalesLT.Customer
where FirstName='john';

select CustomerID,FirstName,MiddleName,LastName
from SalesLT.Customer
where (FirstName like '%ber%') or (LastName like '%ber%') or (MiddleName like '%ber%');

select CustomerID,FirstName,MiddleName,LastName
from SalesLT.Customer
where (LastName like '%e_') 

select (FirstName+' '+isnull(MiddleName,'')+' '+LastName) as FullName
from SalesLT.Customer;

select (FirstName+' '+coalesce(MiddleName,'')+' '+LastName) as FullName
from SalesLT.Customer;

select count(*),FirstName,LastName
from SalesLT.Customer
where (firstName='John')
group by firstname,lastname;

select Avg(CustomerID) as average,Min(CustomerID) as minimum,Max(CustomerID) as maximum
from SalesLT.Customer
where (firstName like '%r') or (lastName like '%r') or (middleName like '%r')

select count(*) as number, firstname, lastname
from SalesLT.Customer
where (lastName like '[km]%')
group by firstname,lastname
having count(*)=1
order by (firstname) desc;

select count(*) as number, firstname as fname, lastname as lname
from SalesLT.Customer
where (lastName like '[km]%')
group by firstname,lastname
having count(*)=1
order by (fname) desc , lname asc;

select StateProvince, count(*) as num 
from SalesLT.Address
where (city like '%t%') --and CountryRegion='United States'
group by StateProvince
--having count(*)=(max(count(*))) or count(*)=(min(count(*)))
order by num desc;

--method of execution
--from 
--where
--group by
--having
--select
--order by

select count(*),slc.firstname, sla.city,sla.stateprovince
from SalesLT.Customer as slc
left join SalesLT.CustomerAddress as slca on slca.CustomerID=slc.CustomerID
inner join SalesLT.Address as sla on sla.AddressID=slca.AddressID
group by slc.customerID,firstname,sla.city,sla.stateprovince
having count(*)>1;

select * from SalesLT.Customer;