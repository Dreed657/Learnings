-- Exersice 1 --

USE Softuni_Base;

SELECT TOP(5) e.EmployeeId, e.JobTitle, a.AddressId, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID;

-- Exersice 2 --

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON t.TownID = a.TownID 
	ORDER BY e.FirstName, e.LastName;

-- Exersice 3 --

SELECT EmployeeID, FirstName, LastName, D.[Name] AS [DepartmentName]
	FROM Employees E
	JOIN Departments D ON E.DepartmentID = D.DepartmentID
	WHERE D.[Name] = 'Sales'
	ORDER BY EmployeeID;

-- Exersice 4 --

SELECT TOP(5) EmployeeID, FirstName, E.Salary, D.[Name] AS [DepartmentName]
	FROM Employees E
	JOIN Departments D ON E.DepartmentID = D.DepartmentID
	WHERE D.[Name] = 'Engineering' AND E.Salary > 15000
	ORDER BY D.DepartmentID;

-- Exersice 5 --

SELECT TOP(3) E.EmployeeID, E.FirstName
	FROM Employees E
	LEFT OUTER JOIN EmployeesProjects EP ON E.EmployeeID = EP.EmployeeID
	WHERE EP.EmployeeID IS NULL

-- Exersice 6 --

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
	FROM Employees e
	JOIN Departments D ON E.DepartmentID = D.DepartmentID 
	WHERE e.HireDate > '1.1.1999' AND D.[Name] IN ('Sales', 'Finance')
	ORDER BY E.HireDate;

-- Exersice 7 --

SELECT TOP(5) E.EmployeeID, E.FirstName, P.[Name] AS [ProjectName]
	FROM Employees E
	LEFT JOIN EmployeesProjects EP ON E.EmployeeID = EP.EmployeeID
	JOIN Projects P ON EP.ProjectID = P.ProjectID 
	WHERE P.StartDate > '2002-08-13'
	ORDER BY E.EmployeeID ASC;

-- Exersice 8 --

SELECT E.EmployeeID,
	E.FirstName,
	CASE
		WHEN P.[StartDate] > '2004' THEN NULL
		ELSE p.[Name]
	END	AS [ProjectName]
	FROM Employees E
	LEFT JOIN EmployeesProjects EP ON E.EmployeeID = EP.EmployeeID
	JOIN Projects P ON EP.ProjectID = P.ProjectID 
	WHERE EP.EmployeeID = 24;

-- Exersice 9 --

SELECT E.EmployeeID,  E.FirstName, E.ManagerID, M.FirstName AS [ManagerName]
	FROM Employees E
	JOIN Employees M ON E.ManagerID = M.EmployeeID
	WHERE E.ManagerID IN (3, 7)
	ORDER BY EmployeeID;

-- Exersice 10 --

SELECT TOP(50) E.EmployeeID,
	E.FirstName + ' ' + E.LastName,
	M.FirstName + ' ' + M.LastName AS [ManagerName],
	D.[Name] AS [DepartmentName]
	FROM Employees E
	JOIN Employees M ON E.ManagerID = M.EmployeeID
	JOIN Departments D ON E.DepartmentID = D.DepartmentID 
	ORDER BY EmployeeID;

-- Exersice 11 --

SELECT TOP(1) AVG(Salary) 
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY AVG(Salary);

-- Exersice 12 --

USE Geography;

SELECT CountryCode, MountainRange, PeakName, Elevation
	FROM Peaks P
	JOIN Mountains M ON P.MountainId = M.id
	JOIN MountainsCountries MC ON M.Id = MC.MountainId
	WHERE P.Elevation > 2835 AND MC.CountryCode = 'BG'
	ORDER BY P.Elevation DESC;

-- Exercise 13 --

SELECT CountryCode, COUNT(MountainId) AS [MountainRanges]
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode;

-- Exercise 14 --

SELECT TOP(5) C.CountryName, R.RiverName
	FROM Countries C
	LEFT JOIN CountriesRivers CM ON C.CountryCode = CM.CountryCode 
	LEFT JOIN Rivers R ON CM.RiverId = R.Id
	WHERE C.ContinentCode = 'AF'
	ORDER BY C.CountryName ASC

-- Exercise 15 Continents and Currencies -- 

SELECT * 
	FROM 
		(SELECT ContinentCode, CurrencyCode, [CurrencyCount] AS [CurrencyUsage] 
		FROM 
			(SELECT *,
			DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY [CurrencyCount] DESC) AS [CurrencyRank]
			FROM 
				(SELECT ContinentCode, CurrencyCode,
				COUNT(*) AS [CurrencyCount]
				FROM Countries
				GROUP BY CurrencyCode, ContinentCode ) AS [CurCount]
				) AS [CurrencyCountQuery]
		WHERE [CurrencyRank] = 1
		) AS [CurrencyRankingQuery]
	WHERE [CurrencyUsage] > 1
	ORDER BY ContinentCode 

-- Exercise 16 --

SELECT COUNT(*) AS [Count]
	FROM Countries C
	LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
	WHERE MountainId IS NULL

-- Exercise 17 -- 

SELECT TOP(5)
	CountryName, 
	MAX(Elevation) AS [HighestPeakElevation],
	MAX([Length]) AS LongestRiverLength
	FROM Countries
	JOIN MountainsCountries ON MountainsCountries.CountryCode = Countries.CountryCode
	JOIN Peaks ON Peaks.MountainId = MountainsCountries.MountainId
	JOIN CountriesRivers ON CountriesRivers.CountryCode = Countries.CountryCode
	JOIN Rivers ON Rivers.Id = CountriesRivers.RiverId
	GROUP BY CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

-- Exercise 18 Highest Peak Name and Elevation by Country --
-- CountryName, PeakName, Elevation, MountainRange 

SELECT TOP(5)
	CountryName AS [Country],
	PeakName AS [Highest Peak Name],
	Elevation AS [Highest Peak Elevation],
	MountainRange AS [Mountain]
	FROM (SELECT *, DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank] 
		FROM (SELECT CountryName, PeakName, Elevation, MountainRange 
			FROM Countries C
			JOIN MountainsCountries MC ON MC.CountryCode = C.CountryCode
			JOIN Mountains M ON M.Id = MC.MountainId
			JOIN Peaks P ON P.MountainId = M.Id) 
			AS [FullInfo]) 
		AS [Ranking]
	WHERE [Rank] = 1
	ORDER BY [Country] ASC, [Highest Peak Name] ASC;

SELECT [Country],
		ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
		ISNULL(MAX(Elevation), 0) AS [Highest Peak Elevation],
		ISNULL(MountainRange, '(no mountain)') AS [Mountain],
		DENSE_RANK() OVER (PARTITION BY [Country] ORDER BY Elevation DESC) AS [Ranking]
		FROM (SELECT C.CountryCode AS [Country], PeakName, Elevation, MountainRange
			FROM Countries AS C
			LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
			LEFT JOIN Mountains M ON MC.MountainId = M.Id
			LEFT JOIN Peaks P ON M.Id = P.MountainId
			GROUP BY c.CountryName, P.PeakName, M.MountainRange) AS [Tmp]

WITH chp AS
(SELECT
   c.CountryName,
   p.PeakName,
   p.Elevation,
   m.MountainRange,
   ROW_NUMBER()
   OVER ( PARTITION BY c.CountryName
     ORDER BY p.Elevation DESC ) AS rn
 FROM Countries AS c
   LEFT JOIN CountriesRivers AS cr
     ON c.CountryCode = cr.CountryCode
   LEFT JOIN MountainsCountries AS mc
     ON mc.CountryCode = c.CountryCode
   LEFT JOIN Mountains AS m
     ON mc.MountainId = m.Id
   LEFT JOIN Peaks p
     ON p.MountainId = m.Id)

SELECT TOP 5
  chp.CountryName                           AS [Country],
  ISNULL(chp.PeakName, '(no highest peak)') AS [Highest Peak Name],
  ISNULL(chp.Elevation, 0)                  AS [Highest Peak Elevation],
  CASE WHEN chp.PeakName IS NOT NULL
    THEN chp.MountainRange
  ELSE '(no mountain)' END                  AS [Mountain]
FROM chp
WHERE rn = 1
ORDER BY chp.CountryName ASC, chp.PeakName ASC