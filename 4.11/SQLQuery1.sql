select * from Products;
select * from Customers;
select * from Orders;
select * from OrderItems;

insert into Customers(Name, Email) values ('as', 'bs')
insert into Products(Name, Price) values ('a', 1)
insert into Orders(CustomerID) values (1)

--0. Har bir mijoz qancha zakaz berganini miqdorin	.
select c.CustomerID, c.Name, Count(o.CustomerID) ZakaslarMiqdori
from Orders o
inner join Customers c 
on c.CustomerID = o.CustomerID
group by c.CustomerID, c.Name
order by Count(o.CustomerID) desc;

--1. Har bir mijoz qancha mahsulot buyurtma qilganini hisoblang:
select c.CustomerId, c.Name, count(o.Customerid) as ZakazMiqdor, Sum(oi.quantity) as TovarMiqdor
from Orders o
inner join OrderItems oi
on oi.OrderID = o.OrderID
inner join Customers c
on c.CustomerID = o.CustomerID
group by c.CustomerID, c.Name
order by Sum(oi.Quantity) desc


--2. Har bir mijoz barcha buyurtmalar bo'yicha qancha mablag' sarflaganini toping:
select o.CustomerID, Sum(oi.Price) UmumiyXarajat
from OrderItems oi
inner join Orders o
on oi.OrderID = o.OrderID
group by o.CustomerID
order by Sum(oi.Price) desc


--3. Buyurtma qilingan eng qimmat mahsulotni toping:
select top 1 p.Name, p.Price, oi.Quantity
from products p
left join orderitems oi
on p.Productid = oi.Productid
where oi.ProductId is not null
order by p.Price desc

--4. So'nggi 30 kun ichida barcha buyurtmalarni ro'yxatlang:
SELECT *
FROM Orders
WHERE OrderDate >= DATEADD(DAY, -30, CAST(GETDATE() AS DATE));

SELECT *
FROM Orders
WHERE DATEDIFF(DAY, OrderDate, GETDATE()) <= 30;

--5. Eng ko'p buyurtma bergan mijozni toping:
select top 1 c.CustomerID, c.Name, Count(o.CustomerID) as BuyurtmaMiqdori
from Orders o
inner join Customers c
on c.CustomerID = o.CustomerID
group by c.CustomerID, c.Name 
order by Count(o.CustomerID) desc

--6. Hali buyurtma qilinmagan mahsulotlarni ro'yxatlang:
select p.ProductID, p.Name, p.Price
from Products p
left join OrderItems oi
on p.ProductID = oi.ProductID
where oi.OrderItemID is null

--7. Har bir mahsulot uchun jami tushumni toping:
select p.ProductID, p.Name, oi.Quantity, Sum(oi.Price * oi.Quantity)
from Products p
inner join OrderItems oi
on oi.ProductID = p.ProductID
group by p.ProductID, p.Name, oi.Quantity
order by Sum(oi.Quantity * oi.Price) desc 

--8. Har bir mijoz qancha mahsulot buyurtma qilganini oling:
select o.CustomerID, Count(oi.ProductID) as Mahsulot, Sum(oi.Quantity) as Miqdori
from OrderItems oi
inner join Orders o
on o.OrderID = oi.OrderID
Group by o.CustomerID


--9. Hech qanday buyurtma bermagan mijozlarni toping:
select c.CustomerID, c.Name
from Orders o
right join Customers c
on o.CustomerID = c.CustomerID
where o.CustomerID is null

--10. Eng qimmat 5 mahsulotni oling:
select top 5 *
from Products p
order by p.Price desc

--11. Eng ko'p pul sarflagan 3 mijozni ro'yxatlang:
select top 3 c.CustomerID, c.Name, Sum(oi.Price * oi.Quantity) as ummumiyXarajat
from Customers c
inner join Orders o 
on o.CustomerID = c.CustomerID
inner join OrderItems oi
on oi.OrderID = o.OrderID
group by c.CustomerID, c.Name
Order by ummumiyXarajat desc

--12. Barcha buyurtmalarni va har bir buyurtma bo'yicha mahsulotlar miqdorini ro'yxatlang:


--13. Har bir mijoz qancha mahsulot buyurtma qilganini toping va 5 tadan ko'p mahsulot buyurtma qilgan mijozlarni filtrlang:

--14. Eng ko'p miqdorda buyurtma qilingan mahsulotlarni oling:

--15. 2024 yil davomida har oyda qancha buyurtma berilganligini ro'yxatlang:

--16. Eng qimmat buyurtma bergan mijozni toping:

--17. Mahsulotlarni va ularning jami sotilgan miqdorini ro'yxatlang, eng ko'p sotilgan bo'yicha tartiblangan:

--18. $500 dan ko'p sarflagan mijozlarni toping:

--19. Har bir buyurtma bo'yicha buyurtma qilingan mahsulotlar sonini o'rtacha oling:

--20. Umumiy miqdori $1000 dan oshgan buyurtmalarni toping:

--21. "Alice Smith" mijozning eng so'nggi buyurtmasini toping:

--22. "John Doe" mijoz tomonidan buyurtma qilingan mahsulotlarni ro'yxatlang, har bir mahsulotning jami miqdori bo'yicha tartiblangan:

--23. 2024 yilda har bir mijoz tomonidan buyurtma qilingan jami buyurtmalar va mahsulotlar sonini toping:

--24. Har bir mahsulotni uning narxi, buyurtma qilingan miqdori va jami tushumi bilan ro'yxatlang:

--25. So'nggi hafta ichida buyurtma qilingan mahsulotlarni toping va har bir mahsulot uchun jami tushumni hisoblang:

