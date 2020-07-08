CREATE DATABASE [Service];

USE [Service];

-- Section 1 DDL --

CREATE TABLE [Users]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Username] NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	[Birthdate] DATETIME2 NOT NULL,
	[Age] INT CHECK([Age] >= 14 AND [Age] <= 110),
	[Email] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Employees]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(25),
	[LastName] NVARCHAR(25),
	[Birthdate] DATETIME2,
	[Age] INT CHECK([Age] >= 18 AND [Age] <= 110),
	[DepartmentId] INT REFERENCES Departments(Id)
);

CREATE TABLE [Categories] 
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT REFERENCES Departments(Id) NOT NULL
);

CREATE TABLE [Status]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Label] NVARCHAR(30) NOT NULL
);

CREATE TABLE [Reports] 
(
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryId] INT REFERENCES [Categories](Id) NOT NULL,
	[StatusId] INT REFERENCES [Status](Id) NOT NULL,
	[OpenDate] DATETIME2 NOT NULL,
	[CloseDate] DATETIME2,
	[Description] NVARCHAR(200) NOT NULL,
	[UserId] INT REFERENCES Users(Id) NOT NULL,
	[EmployeeId] INT REFERENCES Employees(Id)
);

-- Section 2 DML --

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-15', 9),
	('Giovanna', 'Amati', '1959-07-20', 5);

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
VALUES 
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1);

UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL;

DELETE FROM REPORTS
	WHERE StatusId = 4;

-- Section 3 Querying --

SELECT 
	[Description],
	FORMAT(OpenDate, 'dd-MM-yyyy') AS [OpenDate]
	FROM Reports R
	WHERE EmployeeId IS NULL
	ORDER BY R.OpenDate, [Description];

SELECT 
	[Description],
	C.[Name]
	FROM Reports R
	JOIN Categories C ON R.CategoryId = C.Id
	ORDER BY [Description], C.[Name];

SELECT TOP(5)
	C.[Name],
	COUNT(*) AS [ReporstNumber]
	FROM Reports R
	JOIN Categories C ON R.CategoryId = C.Id
	GROUP BY C.[Name]
	ORDER BY [ReporstNumber] DESC, C.[Name];

SELECT 
	Username, 
	C.[Name]
	FROM Reports R
	JOIN Users U ON U.Id = R.UserId
	JOIN Categories C ON C.Id = R.CategoryId
	WHERE (DATEPART(MONTH, R.OpenDate) = DATEPART(MONTH, U.Birthdate)) 
		AND (DATEPART(DAY, R.OpenDate) = DATEPART(DAY, U.Birthdate))
	ORDER BY Username, C.Name;

SELECT [Name], COUNT(*) 
	FROM Users
	GROUP BY [Name];

SELECT 
	FirstName + ' ' + LastName AS [FullName],
	COUNT(UserId) AS [UsersCount]
	FROM Reports R
	RIGHT JOIN Employees E ON E.Id = R.EmployeeId
	GROUP BY R.EmployeeId, E.FirstName, E.LastName
	ORDER BY [UsersCount] DESC, [FullName] ASC;

SELECT	
	ISNULL(E.FirstName + ' ' + E.LastName, 'None') AS [Employee],
	ISNULL(D.[Name], 'None') AS [Department],
	ISNULL(C.[Name], 'None') AS [Category],
	ISNULL(R.Description, 'None') AS [Description],
	FORMAT(R.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	ISNULL(S.Label, 'None') AS [Status],
	ISNULL(U.Name, 'None') AS [User]
	FROM Reports R
	LEFT JOIN Employees E ON E.Id = R.EmployeeId
	LEFT JOIN Departments D ON D.Id = E.DepartmentId
	LEFT JOIN Categories C ON C.Id = R.CategoryId
	LEFT JOIN [Status] S ON S.Id = R.StatusId
	LEFT JOIN Users U ON U.Id = R.UserId
	ORDER BY 
		E.FirstName DESC,
		E.LastName DESC,
		[Department] ASC,
		[Category] ASC,
		[Description] ASC,
		R.OpenDate ASC,
		[Status] ASC,
		[User] ASC

-- Section 4 Programmability --
GO;

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
	IF (@StartDate IS NULL OR @EndDate IS NULL) RETURN 0;

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate);
END

GO;

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO;

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
	DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
	DECLARE @ReportDepartmentId INT = (SELECT TOP(1) DepartmentId 
										FROM Reports R
										JOIN Categories C ON C.Id = R.CategoryId
										WHERE R.Id = @ReportId);
	
	IF (@EmployeeDepartmentId != @ReportDepartmentId) 
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
GO;

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2
