CREATE TABLE Employees (
    EmployeeID   INT IDENTITY(1,1) PRIMARY KEY,  
    FirstName    NVARCHAR(50) NOT NULL,         
    LastName     NVARCHAR(50) NOT NULL,         
    Email        NVARCHAR(100) UNIQUE,          
    PhoneNumber  VARCHAR(20) NULL,             
    Department   VARCHAR(50) NOT NULL,         
    Salary       DECIMAL(10,2), 
    BirthDate    DATE NOT NULL,  -- Added to support Age computation
    Age          AS DATEDIFF(YEAR, BirthDate, GETDATE()),  
	DepartmentId bigint null,
	CONSTRAINT FK_Employees_Department FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);


INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, Department, Salary, BirthDate)
VALUES
('John', 'Doe', 'johndoe@email.com', '123-456-7890', 'IT', 60000.00, '1990-05-15'),
('Jane', 'Smith', 'janesmith@email.com', '987-654-3210', 'HR', 55000.00, '1988-09-22'),
('Michael', 'Johnson', 'michaelj@email.com', '456-789-1234', 'Finance', 70000.00, '1985-07-10'),
('Emily', 'Brown', 'emilyb@email.com', '321-654-9870', 'Marketing', 50000.00, '1993-03-18'),
('Daniel', 'White', 'danielw@email.com', '789-123-4567', 'IT', 75000.00, '1980-11-30'),
('Sarah', 'Miller', 'sarahm@email.com', '159-357-4862', 'Sales', 65000.00, '1995-06-25'),
('David', 'Wilson', 'davidw@email.com', '852-963-7410', 'Finance', 72000.00, '1983-12-05'),
('Olivia', 'Anderson', 'oliviaa@email.com', '951-753-8524', 'HR', 57000.00, '1992-04-08'),
('James', 'Thomas', 'jamest@email.com', '357-159-4862', 'Marketing', 48000.00, '1997-01-14'),
('Sophia', 'Martinez', 'sophiam@email.com', '852-456-1597', 'Sales', 68000.00, '1986-08-20'),

-- Add 40 more rows with diverse names and departments
('Ethan', 'Garcia', 'ethang@email.com', '963-741-8520', 'IT', 73000.00, '1991-02-28'),
('Isabella', 'Rodriguez', 'isabellar@email.com', '741-852-9630', 'HR', 54000.00, '1989-10-12'),
('Mason', 'Martinez', 'masonm@email.com', '159-753-4862', 'Finance', 71000.00, '1984-07-07'),
('Mia', 'Hernandez', 'miah@email.com', '753-159-4862', 'Marketing', 52000.00, '1996-05-03'),
('Alexander', 'Lopez', 'alexl@email.com', '123-852-4567', 'Sales', 69000.00, '1987-09-15'),
('Charlotte', 'Gonzalez', 'charlotteg@email.com', '852-963-1597', 'IT', 77000.00, '1982-06-22'),
('Benjamin', 'Perez', 'benjaminp@email.com', '963-159-7530', 'HR', 56000.00, '1994-11-09'),
('Amelia', 'Taylor', 'ameliat@email.com', '741-123-8524', 'Finance', 74000.00, '1981-03-30'),
('Lucas', 'Torres', 'lucast@email.com', '951-852-1597', 'Marketing', 49000.00, '1998-12-14'),
('Harper', 'Nguyen', 'harpern@email.com', '357-486-1597', 'Sales', 67000.00, '1985-08-01'),

('William', 'Rivera', 'williamr@email.com', '789-654-3210', 'IT', 76000.00, '1990-07-21'),
('Ella', 'Clark', 'ellac@email.com', '654-789-1230', 'HR', 53000.00, '1989-05-18'),
('Henry', 'Lewis', 'henryl@email.com', '321-456-9870', 'Finance', 73000.00, '1983-01-10'),
('Ava', 'Robinson', 'avar@email.com', '789-321-6540', 'Marketing', 51000.00, '1997-06-12'),
('Jack', 'Walker', 'jackw@email.com', '951-357-1597', 'Sales', 66000.00, '1986-10-24'),
('Lucas', 'Hall', 'lucash@email.com', '654-321-7890', 'IT', 78000.00, '1981-04-03'),
('Evelyn', 'Allen', 'evelyna@email.com', '123-789-6540', 'HR', 58000.00, '1995-08-27'),
('Sebastian', 'Young', 'sebastiany@email.com', '852-357-1230', 'Finance', 72000.00, '1982-11-08'),
('Chloe', 'King', 'chloek@email.com', '789-654-1597', 'Marketing', 49500.00, '1998-09-02'),
('Dylan', 'Wright', 'dylanw@email.com', '321-852-4567', 'Sales', 69000.00, '1987-03-19'),


('Grace', 'Scott', 'graces@email.com', '753-159-8520', 'IT', 77000.00, '1991-06-14'),
('Nathan', 'Green', 'nathang@email.com', '456-123-7890', 'HR', 55000.00, '1989-12-22'),
('Zoey', 'Adams', 'zoeya@email.com', '159-357-8520', 'Finance', 73500.00, '1984-09-30'),
('Liam', 'Baker', 'liamb@email.com', '741-963-2580', 'Marketing', 50500.00, '1996-07-25'),
('Scarlett', 'Nelson', 'scarlettn@email.com', '852-951-7530', 'Sales', 67500.00, '1985-04-17'),
('Owen', 'Carter', 'owenc@email.com', '789-357-8520', 'IT', 76500.00, '1980-02-14'),
('Madison', 'Mitchell', 'madisonm@email.com', '963-852-1597', 'HR', 56500.00, '1993-11-01'),
('Eli', 'Perez', 'elip@email.com', '753-741-8520', 'Finance', 72500.00, '1981-08-05'),
('Victoria', 'Evans', 'victoriae@email.com', '951-753-1597', 'Marketing', 52000.00, '1998-01-20'),
('Leo', 'Collins', 'leoc@email.com', '357-456-8520', 'Sales', 70000.00, '1986-05-10');


select * from Employees;


-- 1. Har bir departmentdagi ishchilar sonini aniqlang.
Select Department, Count(*) As IshchilarSoni
from Employees
Group by Department;

--2. Har bir departmentdagi ortacha oylikni aniqlang.
Select Department, AVG(Salary) As OrtachaOylik
from Employees
Group by Department;

--3. Har bir departmentdagi max oylikni aniqlang aniqlang.
Select Department, Max(Salary) As MaxOylik
from Employees
Group by Department;

--4. Har bir departmentdagi min oylikni aniqlang.
Select Department, Min(Salary) As MinOylik
from Employees
Group by Department;

--5. Har bir departmentdagi berilgan telefon raqamlarni aniqlang aniqlang.
Select Department, Count(PhoneNumber) As PhoneNumberCount
from Employees
Group by Department;

--6. Har bir departmentdagi umumiy oylikni aniqlang aniqlang.
Select Department, Sum(Salary) As UmumiyOylik
from Employees
Group by Department;

--7. har bir yoshdagi umumiy oyliklarni aniqlang
Select Age, Sum(Salary) As UmumiyOylikByAge
from Employees
Group by Age;

--8. har bir yoshdagi ortacha, katta, kichik oyliklarni aniqlang
Select Age, Avg(Salary) As OrtachaOylikByAge, Max(Salary) As MaxOylikByAge, Min(Salary) As MinOylikByAge
from Employees
Group by Age;

--Group by siz ishlanadigan tasklar

update Employees
set PhoneNumber = NUll
Where EmployeeID = 1;

--1. 30 yoshdan katta ishchilar sonini aniqlang.
Select Count(*) as AgeKatta30Count from Employees
Where Age > 30; 

select * from Employees;

--2. 30 yoshdan katta ishchilarni ortacha oyligini aniqlang
Select AVG(Salary) from Employees
Where Age > 30; 

--3. 30 yoshdan katta ishchilarni max oyligini aniqlang
Select Max(Salary) as MaxAge30Katta from Employees
Where Age > 30; 

--4. 30 yoshdan katta ishchilarni min oyligini aniqlang
Select Min(Salary) as MinAge30Katta from Employees
Where Age > 30; 

--5. 30 - 40 yosh oraliqdagi ishchilarni max, min, o'rtacha oyligini aniqlang
Select Max(Salary) as Maxx, Min(Salary) as Minn, Avg(Salary) as avgg from Employees
Where Age > 30 And Age < 40; 

--6. 30 - 40 yosh oraliqdagi ishchilarni jami oyligini aniqlang
Select Sum(Salary) as JamiOylik from Employees
Where Age > 30 And Age < 40; 

--7. 30 yoshdan kichik ishchilarni ortacha, max, umumiy, katta oyligini aniqlang
Select  Max(Salary) as Maxx, Min(Salary) as Minn, Avg(Salary) as avgg, Sum(Salary) as summ from Employees
Where Age < 30;


create table Department (
	DepartmentId bigint identity(1, 1) primary key,
	Name nvarchar(50) not null
);

Alter table Employees
add DepartmentId bigint null;

Alter table Employees
ADD CONSTRAINT FK_Employees_Department FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId);

select * from Employees;

DELETE
from Employees
where EmployeeID > 0;


INSERT INTO [four10].[dbo].[Department] ([Name])
VALUES
    ('HR'),
    ('Finance'),
    ('IT'),
    ('Marketing'),
    ('Sales'),
    ('Logistics'),
    ('Legal'),
    ('Operations'),
    ('Customer Support'),
    ('R&D');

INSERT INTO [four10].[dbo].[Employees] 
    ([FirstName], [LastName], [Email], [PhoneNumber], [Department], [Salary], [BirthDate], [DepartmentId]) 
VALUES
    ('John', 'Doe', 'john.doe@example.com', '998901234567', 'IT', 5000, '1990-01-15', 3),
    ('Alice', 'Smith', 'alice.smith@example.com', '998902345678', 'HR', 4500, '1992-06-25', 1),
    ('Bob', 'Brown', 'bob.brown@example.com', '998903456789', 'Finance', 5500, '1988-11-10', 2),
    ('Charlie', 'Davis', 'charlie.davis@example.com', '998904567890', 'Sales', 4800, '1995-02-20', 5),
    ('Eve', 'Johnson', 'eve.johnson@example.com', '998905678901', 'Marketing', 4700, '1993-09-12', 4),
    ('Frank', 'White', 'frank.white@example.com', '998906789012', 'Logistics', 4600, '1991-07-05', 6),
    ('Grace', 'Miller', 'grace.miller@example.com', '998907890123', 'Legal', 6000, '1987-03-30', 7),
    ('Hank', 'Wilson', 'hank.wilson@example.com', '998908901234', 'Operations', 5300, '1996-12-08', 8),
    ('Ivy', 'Anderson', 'ivy.anderson@example.com', '998909012345', 'Customer Support', 4200, '1998-04-22', 9),
    ('Jack', 'Thomas', 'jack.thomas@example.com', '998900123456', 'R&D', 6500, '1985-10-18', 10),
    ('Liam', 'Taylor', 'liam.taylor@example.com', '998901112233', 'IT', 5200, '1994-05-07', 3),
    ('Sophia', 'Moore', 'sophia.moore@example.com', '998902223344', 'HR', 4700, '1997-08-15', 1),
    ('William', 'Martinez', 'william.martinez@example.com', '998903334455', 'Finance', 5800, '1989-09-30', 2),
    ('Emma', 'Garcia', 'emma.garcia@example.com', '998904445566', 'Sales', 4900, '1992-01-12', 5),
    ('Mason', 'Hernandez', 'mason.hernandez@example.com', '998905556677', 'Marketing', 4800, '1995-06-21', 4),
    ('Olivia', 'Lopez', 'olivia.lopez@example.com', '998906667788', 'Logistics', 4700, '1993-03-05', 6),
    ('Ethan', 'Gonzalez', 'ethan.gonzalez@example.com', '998907778899', 'Legal', 6100, '1986-07-14', 7),
    ('Ava', 'Wilson', 'ava.wilson@example.com', '998908889900', 'Operations', 5400, '1996-02-28', 8),
    ('James', 'Anderson', 'james.anderson@example.com', '998909990011', 'Customer Support', 4300, '1998-05-10', 9),
    ('Charlotte', 'Thomas', 'charlotte.thomas@example.com', '998900000111', 'R&D', 6600, '1984-09-03', 10),
    ('Benjamin', 'Roberts', 'benjamin.roberts@example.com', '998901234001', 'IT', 5300, '1991-11-22', 3),
    ('Mia', 'Scott', 'mia.scott@example.com', '998902345002', 'HR', 4800, '1994-04-18', 1),
    ('Lucas', 'Young', 'lucas.young@example.com', '998903456003', 'Finance', 5900, '1987-12-09', 2),
    ('Amelia', 'Allen', 'amelia.allen@example.com', '998904567004', 'Sales', 5000, '1991-06-15', 5),
    ('Henry', 'King', 'henry.king@example.com', '998905678005', 'Marketing', 4900, '1995-10-27', 4),
    ('Harper', 'Wright', 'harper.wright@example.com', '998906789006', 'Logistics', 4800, '1992-02-06', 6),
    ('Daniel', 'Lopez', 'daniel.lopez@example.com', '998907890007', 'Legal', 6200, '1985-08-17', 7),
    ('Evelyn', 'Hill', 'evelyn.hill@example.com', '998908901008', 'Operations', 5500, '1997-03-30', 8),
    ('Matthew', 'Green', 'matthew.green@example.com', '998909012009', 'Customer Support', 4400, '1999-07-12', 9),
    ('Ella', 'Adams', 'ella.adams@example.com', '998900123010', 'R&D', 6700, '1983-11-24', 10),
    ('Samuel', 'Baker', 'samuel.baker@example.com', '998901112011', 'IT', 5400, '1990-08-09', 3),
    ('Scarlett', 'Nelson', 'scarlett.nelson@example.com', '998902223012', 'HR', 4900, '1993-09-15', 1),
    ('David', 'Carter', 'david.carter@example.com', '998903334013', 'Finance', 6000, '1988-12-30', 2),
    ('Victoria', 'Mitchell', 'victoria.mitchell@example.com', '998904445014', 'Sales', 5100, '1992-05-18', 5),
    ('Logan', 'Perez', 'logan.perez@example.com', '998905556015', 'Marketing', 5000, '1996-06-30', 4),
    ('Grace', 'Roberts', 'grace.roberts@example.com', '998906667016', 'Logistics', 4900, '1994-01-25', 6),
    ('Elijah', 'Phillips', 'elijah.phillips@example.com', '998907778017', 'Legal', 6300, '1986-09-19', 7),
    ('Aria', 'Evans', 'aria.evans@example.com', '998908889018', 'Operations', 5600, '1997-04-14', 8),
    ('Joseph', 'Turner', 'joseph.turner@example.com', '998909990019', 'Customer Support', 4500, '1999-08-01', 9),
    ('Lily', 'Parker', 'lily.parker@example.com', '998900000020', 'R&D', 6800, '1982-07-09', 10);

select * from Employees;
select * from Department;

--Tasks

--1. department aniq bo'lgan ishchilarni ismi va department nomini chiqaring.
Select Employees.FirstName, Department.Name
from Employees
Inner join Department on Employees.DepartmentId = Department.DepartmentId;

--2. hamma ishchilarni ismi va department nomini chiqaring
Select Employees.FirstName, Department.Name
from Employees
FULL OUTER JOIN Department on Employees.DepartmentId = Department.DepartmentId;

--3. hamma departmentlarni (hamma department malumotlar) va ishchilarni ismi bn chiqaring.
Select Department.Name, Employees.FirstName
from Department
Left join Employees on Employees.DepartmentId = Department.DepartmentId;

--4. Hamma ishchi va department malumotlarini chiqaring.
Select e.EmployeeID, e.FirstName, e.LastName, e.Email, e.PhoneNumber, e.Age, e.BirthDate, e.Salary, d.DepartmentId, d.Name
from Employees e
FULL OUTER JOIN Department d on e.DepartmentId = d.DepartmentId;

--5. birorta ham ishchisi yoq departmentlarni aniqalng.
SELECT d.*
FROM Department d
LEFT JOIN Employees e ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID IS NULL;

insert into Department (Name)
values
	('bekorchi');

