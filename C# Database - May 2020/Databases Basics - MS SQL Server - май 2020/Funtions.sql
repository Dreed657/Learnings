-- Exercise 1 --
USE Softuni_Base;

SELECT [FirstName] ,[LastName]
  FROM [Employees]
  WHERE [FirstName] LIKE 'SA%';

-- Exercise 2 --

SELECT [FirstName] ,[LastName]
  FROM [Employees]
  WHERE [LastName] LIKE '%ei%';

-- Exercise 3 --

SELECT [FirstName] FROM [Employees]
  WHERE (DepartmentID IN (3, 10)) AND ([HireDate] BETWEEN '1994' AND '2006');
  
-- Exercise 4 --

SELECT [FirstName] ,[LastName]
  FROM [Employees]
  WHERE [JobTitle] NOT LIKE '%engineer%';

-- Exercise 5 --

SELECT [Name] 
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name] ASC;

-- Exercise 6 --

SELECT *
	FROM Towns 
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name] ASC;

-- Exercise 7 --

SELECT *
	FROM Towns 
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name] ASC;

-- Exercise 8 --

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName] ,[LastName]
  FROM [Employees]
  WHERE [HireDate] > '2001';
  
-- Exercise 8 --

SELECT [FirstName] ,[LastName]
  FROM [Employees]
  WHERE LEN([LastName]) = 5;

-- Exercise 8 --

SELECT 
	[EmployeeID],
	[FirstName],
	[LastName],
	[Salary],
	DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
  FROM [Employees]
  WHERE ([Salary] BETWEEN 10000 AND 50000)
  ORDER BY [Salary] DESC;

-- Exercise 9 --

SELECT * FROM (SELECT [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank] FROM [Employees]
    WHERE [Salary] BETWEEN 10000 AND 50000) AS [Temp]
	WHERE [Rank] = 2
	ORDER BY Salary DESC;

-- Exercise 10 --

USE Geography;

SELECT [CountryName], [IsoCode]
	FROM Countries
	WHERE len([CountryName]) - len(replace([CountryName],'A','')) >= 3
	ORDER BY [IsoCode];

SELECT [CountryName], [IsoCode]
	FROM Countries
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode];

-- Exercise 11 --

SELECT 
	PeakName,
	RiverName, 
	LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName) - 1))) AS Mix 
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix;

-- Exercise 12 --

USE Diablo;

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
	ORDER BY [Start], [Name];

-- Exercise 13 --

SELECT
	[Username],
	RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], [Username];

SELECT * FROM USERS;

-- Exercise 14 --

SELECT 
	[Username],
	[IpAddress] AS [IP Address]
	FROM Users
	WHERE [IpAddress] LIKE '___.1%.%.___'
	ORDER BY Username;

-- Exercise 15 --

SELECT [Name],
	CASE
		WHEN DATEPART(hh, [Start]) >= 0 AND DATEPART(hh, [Start]) < 12  THEN 'Morning'
		WHEN DATEPART(hh, [Start]) >= 12 AND DATEPART(hh, [Start]) < 18  THEN 'Afternoon'
		WHEN DATEPART(hh, [Start]) >= 18 AND DATEPART(hh, [Start]) < 24  THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
	FROM Games
	ORDER BY [Name], [Duration], [Part of the Day];

-- Exercise 16 --

Use Orders;

Select 
	[ProductName],
	[OrderDate],
	DATEADD(dd, 3, [OrderDate]) AS [Pay Due],
	DATEADD(mm, 1, [OrderDate]) AS [Deliver Due]
	FROM Orders;

-- Exercise 18 --

USE Demo;

SELECT * FROM Citizens;

SELECT 
	[Name],
	[Birthdate],
	DATEDIFF(yy, [Birthdate], GETDATE()) AS [Age in Years],
	DATEDIFF(MM, [Birthdate], GETDATE()) AS [Age in Months],
	DATEDIFF(dd, [Birthdate], GETDATE()) AS [Age in Days],
	DATEDIFF(mi, [Birthdate], GETDATE()) AS [Age in Minutes]
	FROM Citizens;