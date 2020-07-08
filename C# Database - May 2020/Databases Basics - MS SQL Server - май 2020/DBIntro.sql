/* Exercise 1 */

CREATE DATABASE Minions;

USE Minions;

CREATE TABLE Minions (
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
)

CREATE TABLE Towns (
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns (Id, [Name])
VALUES 
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

TRUNCATE TABLE Minions;

SELECT * FROM Minions;

DROP TABLE Minions;

DROP TABLE Towns;

/* Exercise 2 */

CREATE TABLE People (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 * 1024),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX),
);

INSERT INTO People ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES 
('Jorko1', 011010101010101100010011111011, 2222.22222, 23232321.2232222, 'M', GETDATE(), 'asdasdasdasd1'),
('Jorko2', 01101010101010111111011, 222222.222, 23232321.2232222, 'F', GETDATE(), 'asdasdasdasd32'),
('Jorko3', 0110101010101011111100010011111011, 22.22222, 23232321.2232222, 'M', GETDATE(), 'asdasdasdasd3'),
('Jorko4', 011010101010101100011110010011111011, 222222.22222, 23232321.2232222, 'F', GETDATE(), 'asdasdasdasd4'),
('Jorko5', 011010101010101100010011110001011, 22.22, 23232321.2232222, 'M', GETDATE(), 'asdasdasdasd5');

SELECT * FROM People;

TRUNCATE TABLE People;

/* Exercise 3 */

CREATE TABLE Users(
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	[LastLoginTime] Date NOT NULL,
	[isDeleted] bit NOT NULL,
);

INSERT INTO Users ([Username], [Password], [ProfilePicture], [LastLoginTime], [isDeleted])
VALUES 
('Pesho', 'Password', NULL, GETDATE(), 0),
('Pesho1', 'Password2', NULL, GETDATE(), 1),
('Pesho2', 'Password5', NULL, GETDATE(), 0),
('Pesho3', 'Password22', NULL, GETDATE(), 1),
('Pesho4', 'Passwor6d', NULL, GETDATE(), 0);

SELECT * FROM Users;

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07FDB3F7CF];

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime];

INSERT INTO Users ([Username], [Password], [isDeleted])
VALUES
('Gosho', '123567', 0);

/* Exercise 4 */

CREATE DATABASE Movies;

USE Movies;

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
);

INSERT INTO Directors (DirectorName, Notes)
VALUES 
	('Pesho1', 'asdasdasdasdasd'),
	('Pesho2', '1223'),
	('Pesho3', '441'),
	('Pesho4', 'asdas155125dasdasdasd'),
	('Pesho5', '12512512125');

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
);

INSERT INTO Genres (GenreName, Notes)
VALUES 
	('Horror', 'asdasdasdasdasd'),
	('Romance', '1223'),
	('SciFi', '441'),
	('Vintage', 'asdas155125dasdasdasd'),
	('Cooking', '12512512125');

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX),
);

INSERT INTO Categories (CategoryName, Notes)
VALUES 
	('Horror', 'asdasdasdasdasd'),
	('Romance', '1223'),
	('SciFi', '441'),
	('Vintage', 'asdas155125dasdasdasd'),
	('Cooking', '12512512125');

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] SMALLINT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating FLOAT NOT NULL,
	Notes NVARCHAR(MAX),
);

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES 
	('Racing movie 1', 1, GETDATE(), 20, 1, 1, 2.5, 'Crappy Movie'),
	('Racing movie 2', 2, GETDATE(), 21, 2, 2, 5.5, 'Crappy Movie'),
	('Racing movie 3', 3, GETDATE(), 22, 3, 3, 6.5, 'Crappy Movie'),
	('Racing movie 4', 4, GETDATE(), 23, 4, 4, 4.5, 'Crappy Movie'),
	('Racing movie 5', 5, GETDATE(), 24, 5, 5, 9.5, 'Crappy Movie');

SELECT * FROM Movies;

/* Exercise 4 */

CREATE DATABASE CarRental;

USE CarRental;

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate FLOAT NOT NULL,
	WeeklyRate FLOAT NOT NULL,
	MonthlyRate FLOAT NOT NULL,
	WeekendRate FLOAT NOT NULl,
);

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES 
('Eco', 2.5, 5, 10, 1.8),
('Normal', 111, 20, 18, 22),
('Premium', 25.5, 25, 50, 45);

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX) NOT NULL,
	Condition FLOAT NOT NULL,
	Available BIT NOT NULL,
);

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES 
	('E5050EE', 'Honda', 'Jazz', GETDATE(), 1, 4, 101110011001101, 2.5, 0),
	('E5420EE', 'Ford', 'Mustong', GETDATE(), 2, 4, 101110011001101, 4, 1),
	('E5250EE', 'Range Rover', 'Sport SVR', GETDATE(), 3, 4, 101110011001101, 6, 1);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(50),
);

INSERT INTO Employees (FirstName, LastName, Title)
VALUES
	('Gosho', 'Pleshiv', 'CEO'),
	('Gosho1', 'Pleshiv1', 'CTO'),
	('Gosho2', 'Pleshiv2', 'COO');

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes VARCHAR(MAX),
);

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES 
	(124153566, 'GoshoOtPochivka1', 'Purvata Ulica2', 'Sofia', 2000),
	(231242345, 'GoshoOtPochivka2', 'Purvata Ulica3', 'Plovdiv', 2000),
	(151551515, 'GoshoOtPochivka3', 'Purvata Ulica4', 'Petrich', 2000);

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel FLOAT NOT NULL,
	KilometrageStart FLOAT NOT NULL,
	KilometrageEnd FLOAT NOT NULL, 
	TotalKilometrage FLOAT NOT NULL, 
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied FLOAT NOT NULL,
	TaxRate FLOAT NOT NULL,
	OrderStatus VARCHAR(50) NOT NULl,
	Notes VARCHAR(MAX),
);

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES 
	(1, 1, 1, 50.2, 25356.55, 26000, 50000, GETDATE(), GETDATE(), 10, 20.52, 20, 'Completed'),
	(2, 2, 2, 75.2, 25356.55, 22, 50000, GETDATE(), GETDATE(), 10, 20.52, 20, 'Completed'),
	(3, 3, 3, 150.2, 25356.55, 2, 50000, GETDATE(), GETDATE(), 10, 20.52, 20, 'Completed');
	
/* Exercise 5 */

CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(100) NOT NULL,
	Notes VARCHAR(100),
);

INSERT INTO Employees (FirstName, LastName, Title)
VALUES 
	('Gosho', 'Pleshiv', 'Trash'),
	('Gosho', 'Pleshiv', 'Trash'),
	('Gosho', 'Pleshiv', 'Trash');

CREATE TABLE Customers (
	AccountNumber INT NOT NULL,
	FirstName VARCHAR(50) NOT Null,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName VARCHAR(50) NOT NULL,
	EmergencyNumber INT NOT NULL,
	Notes VARCHAR(100),
);

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES 
	(1231245, 'Jory', 'Pe', 0120515, 'SOS', 12351),
	(1231245, 'Jory', 'Pe', 0120515, 'SOS', 12351),
	(1231245, 'Jory', 'Pe', 0120515, 'SOS', 12351);

CREATE TABLE RoomStatus  (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomStatus VARCHAR(10) NOT NULL,
	Notes VARCHAR(50),
);

INSERT INTO RoomStatus (RoomStatus)
VALUES 
	('Free'),
	('Ocupied'),
	('Empty');

CREATE TABLE RoomTypes (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType VARCHAR(10) NOT NULL,
	Notes VARCHAR(50),
);

INSERT INTO RoomTypes (RoomType)
VALUES 
	('Normal'),
	('Luxiry'),
	('Exclusive');

CREATE TABLE BedTypes (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	BedType VARCHAR(10) NOT NULL,
	Notes VARCHAR(50),
);

INSERT INTO BedTypes (BedType)
VALUES 
	('Single'),
	('Double'),
	('KingSize');

CREATE TABLE Rooms (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomNumber INT NOT NULL,
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id),
	BedType INT FOREIGN KEY REFERENCES BedTypes(Id),
	Rate FLOAT NOT NULL,
	RoomStatus VARCHAR(100) NOT NULL,
	Notes VARCHAR(50)
);

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES
	(123, 1, 1, 2.5, 1),
	(123, 2, 2, 2.5, 2),
	(123, 3, 3, 2.5, 1);

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount DECIMAL NOT NULL,
	PaymentTotal DECIMAL NOT NULL,
	Notes VARCHAR(50),
);

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES 
	(1, GETDATE(), 123, GETDATE(), GETDATE(), 20, 200, 20, 40, 240),
	(2, GETDATE(), 123, GETDATE(), GETDATE(), 20, 200, 20, 40, 240),
	(3, GETDATE(), 123, GETDATE(), GETDATE(), 20, 200, 20, 40, 240);

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied FLOAT NOT NULL,
	PhoneCharge INT NOT NULL,
	Notes VARCHAR(50) NOT NULL,
);

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES 
	(1, GETDATE(), 13, 351, 20, 61361361, 'asdasd'),
	(2, GETDATE(), 123, 351, 20, 61361361, 'asdasd'),
	(3, GETDATE(), 1325, 351, 20, 61361361, 'asdasd');

/* Exercise 6 */

CREATE DATABASE Softuni;

USE Softuni;

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText VARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id),
);

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
);

INSERT INTO Towns ([Name])
VALUES 
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas');

INSERT INTO Departments ([Name])
VALUES 
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance');

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES 
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88);

SELECT * FROM Towns ORDER BY [Name] ASC;
SELECT * FROM Departments ORDER BY [Name] ASC;
SELECT * FROM Employees ORDER BY Salary DESC;

SELECT [Name] FROM Towns ORDER BY [Name] ASC;
SELECT [Name] FROM Departments ORDER BY [Name] ASC;
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC;

UPDATE Employees SET Salary += Salary * 0.10; 

SELECT Salary FROM Employees;

USE Hotel;

UPDATE Payments SET TaxRate -= TaxRate * 0.03;

SELECT TaxRate FROM Payments;

TRUNCATE TABLE Occupancies;