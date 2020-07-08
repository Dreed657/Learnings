-- Exersice 1 --

USE Gringotts;

SELECT COUNT(*)
	FROM WizzardDeposits;

-- Exersice 2 --

SELECT TOP(1) MagicWandSize AS [MagicWandSize]
	FROM WizzardDeposits
	ORDER BY MagicWandSize DESC;

-- Exersice 3 --

SELECT 
	DepositGroup,
	MagicWandSize AS [LongestMagicWand]
	FROM (SELECT 
		DepositGroup,
		MagicWandSize,
		DENSE_RANK() OVER (PARTITION BY DepositGroup ORDER BY MagicWandSize DESC) AS [Rank]
		FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandSize) AS [Data]
	WHERE [Rank] = 1;

-- Exersice 4 --

SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

-- Exersice 5 --

SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits
	GROUP BY DepositGroup;

-- Exersice 6 --

SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup;

-- Exersice 7 --

SELECT *
	FROM (SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
		FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family'
		GROUP BY DepositGroup) AS [Data]
	WHERE TotalSum < 150000
	ORDER BY TotalSum DESC;

-- Exersice 8 --

SELECT DepositGroup, MagicWandCreator, [MinDepositChange]
	FROM (SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositChange],
		DENSE_RANK() OVER (PARTITION BY DepositGroup, MagicWandCreator ORDER BY DepositCharge) AS [DepositRank]
		FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandCreator, DepositCharge) AS [Data]
	WHERE [DepositRank] = 1
	GROUP BY DepositGroup, MagicWandCreator, [MinDepositChange]
	ORDER BY MagicWandCreator, DepositGroup;

-- Exersice 9 --

SELECT [AgeGroup], COUNT(*) 
	FROM (SELECT
		Age,
		CASE 
			WHEN Age <= 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup]
	FROM WizzardDeposits) AS [Data]
	GROUP BY [AgeGroup];

-- Exersice 10 --

SELECT FirstLetter
	FROM 
		(SELECT LEFT(FirstName, 1) AS [FirstLetter]
			FROM WizzardDeposits
			WHERE DepositGroup = 'Troll Chest') AS [Data]
	GROUP BY [FirstLetter]
	ORDER BY FirstLetter ASC;

-- Exersice 11 --

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
	FROM WizzardDeposits
		WHERE DepositStartDate > '1985-01-01'
		GROUP BY DepositGroup, IsDepositExpired
		ORDER BY DepositGroup DESC, IsDepositExpired ASC;

-- Exersice 11 --

SELECT SUM(ResultTable.[Difference]) AS SumDifference
FROM (SELECT DepositAmount - (SELECT DepositAmount FROM WizzardDeposits WHERE Id = WizDeposits.Id + 1) 
AS [Difference] FROM WizzardDeposits WizDeposits) AS ResultTable;

-- Exersice 12 --

USE SoftUni_Base;

SELECT DepartmentID, SUM(Salary)
	FROM Employees
	GROUP BY DepartmentID;

-- Exersice 13 --

SELECT DepartmentID, MIN(Salary)
	FROM Employees
	WHERE DepartmentID IN (2, 5, 7) AND  HireDate > '2000-01-01'
	GROUP BY DepartmentID;

-- Exersice 14 --

SELECT * INTO [EmployeesAS] FROM Employees
WHERE [Salary] >= 30000
 
DELETE FROM EmployeesAS
WHERE [ManagerID] = 42
 
UPDATE EmployeesAS
SET [Salary] += 5000
WHERE [DepartmentID] = 1
 
SELECT [DepartmentID],
    AVG([Salary]) as [AverageSalary]
FROM EmployeesAS
GROUP BY [DepartmentID]

-- Exersice 15 --

SELECT * 
	FROM 
		(SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
		FROM Employees
		GROUP BY DepartmentID) AS [Data]
	WHERE MaxSalary NOT BETWEEN 30000 AND 70000;

-- Exersice 16 --

SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NULL

-- Exersice 17 --

SELECT DepartmentID, Salary	AS [ThirdHighestSalary]
	FROM 
	(SELECT 
	DepartmentID,
	Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary) AS [Data]
	WHERE [Rank] = 3;

-- Exersice 18 --
--SELECT AVG(Salary) AS [AvgSalary] FROM Employees GROUP BY DepartmentID
