-- Exercise 1 --

CREATE TABLE [Passports] (
	[PassportID] INT PRIMARY KEY NOT NULL,
	[PassportNumber] VARCHAR(10) NOT NULL,
);

CREATE TABLE [Persons] (
	[PersonID] INT NOT NULL,
	[FirstName] VARCHAR(20) NOT NULL,
	[Salary] DECIMAL(18, 2) NOT NULL,
	[PassportID] INT NOT NULL,
);

INSERT INTO [Passports] (PassportID, PassportNumber)
VALUES 
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2');

INSERT INTO [Persons] (PersonID, [FirstName], [Salary], [PassportId])
VALUES 
	(1, 'Roberto', 43300.00, 102),
	(2, 'Tom', 56100.00, 103),
	(3, 'Yana', 60200.00, 101);

ALTER TABLE [Persons]
ADD CONSTRAINT PK_Person PRIMARY KEY (PersonId);

ALTER TABLE [Persons]
ADD CONSTRAINT FK_Persons_Passports 
FOREIGN KEY (PassportId) REFERENCES Passports(PassportId);

SELECT [p].[FirstName], [p].Salary, [pass].PassportId 
	FROM Persons p
	JOIN Passports pass ON p.PassportId = pass.PassportId;

SELECT * FROM Passports, Persons;


DROP TABLE Passports;
DROP TABLE Persons;

-- Exercise 2 --

CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(10) NOT NULL,
	EstablishedOn DATE NOT NULL,
);

CREATE TABLE Models (
	ModelID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(10) NOT NULL,
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID),
);

INSERT INTO Manufacturers ([Name], [EstablishedOn])
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966');


INSERT INTO Models ([ModelID], [Name], [ManufacturerID])
VALUES
	(101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3);

SELECT * FROM Models;
SELECT * FROM Manufacturers;

-- Exercise 3 --

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(10) NOT NULL,
);

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
);

CREATE TABLE StudentsExams (
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_CompositeKey 
	PRIMARY KEY (StudentID, ExamID)
);

INSERT INTO Students ([Name])
VALUES 
	('Mila'),
	('Toni'),
	('Ron');


INSERT INTO Exams([Name])
VALUES 
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g');

INSERT INTO StudentsExams([StudentID], [ExamID])
VALUES 
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103);


-- Exercise 4 --

CREATE TABLE Teachers (
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(15) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES Teachers(TeacherID),
);

INSERT INTO Teachers ([Name], [ManagerID])
VALUES 
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),	
	('Greta', 101);

-- Exercise 5 --

CREATE TABLE [ItemTypes] (
	[ItemTypeID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE [Items] (
	[ItemID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID),
);

CREATE TABLE [Cities] (
	[CityID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE [Customers] (
	[CustomerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES Cities(CityID),
);

CREATE TABLE [Orders] (
	[OrderID] INT PRIMARY KEY IDENTITY NOT NULL,
	[CustomerID] INT NOT NULL FOREIGN KEY REFERENCES [Customers]([CustomerID]),
);

CREATE TABLE [OrderItems] (
	[OrderID] INT NOT NULL FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID] INT NOT NULL FOREIGN KEY REFERENCES [Items](ItemID),
	CONSTRAINT PK_CompositeKey PRIMARY KEY ([OrderID], [ItemID]),
);

-- Exercise 7 --

CREATE TABLE Subjects (
	[SubjectID] INT PRIMARY KEY IDENTITY NOT NULL,
	[SubjectName] VARCHAR(50) NOT NULL,
);

CREATE TABLE Majors (
	[MajorID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Students ( 
	[StudentID] INT PRIMARY KEY IDENTITY NOT NULL,
	[StudentNumber] VARCHAR(50) NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES Majors(MajorID),
);

CREATE TABLE Agenda (
	[StudentID] INT FOREIGN KEY REFERENCES Students([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES Subjects([SubjectID]),
	CONSTRAINT PK_CompositeKey
	PRIMARY KEY (StudentID, SubjectID),
);

CREATE TABLE Payments (
	[PaymentID] INT PRIMARY KEY IDENTITY NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(18, 2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
);

-- Exersise 8 --

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC;