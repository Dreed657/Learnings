-- Еxersice 1 --

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000;
GO

-- Еxersice 2 --

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number DECIMAL(18,4)
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @number
GO

-- Exersice 3 --

CREATE PROCEDURE usp_GetTownsStartingWith @FirstLetter VARCHAR(MAX)
AS
	SELECT [Name] FROM Towns
	WHERE LEFT([Name], LEN(@FirstLetter)) = @FirstLetter
GO;

-- Exersice 4 --

CREATE PROCEDURE usp_GetEmployeesFromTown @TownName VARCHAR(MAX)
AS
	SELECT FirstName, LastName
		FROM Employees E
		JOIN Addresses A ON E.AddressID = A.AddressID 
		JOIN Towns T ON A.TownID = T.TownID
		WHERE @TownName = T.[Name]
GO;

-- Exersice 5 --

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7);

	IF (@salary < 30000)
		SET @salaryLevel = 'Low';
	ELSE IF (@salary >= 30000 AND @salary <= 50000)
		SET @salaryLevel = 'Average';
	ELSE
		SET @salaryLevel = 'High';

	RETURN @salaryLevel
END
GO;

-- Exercise 6 --

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
	SELECT FirstName, LastName 
		FROM 
		(SELECT FirstName, LastName, dbo.ufn_GetSalaryLevel(Salary) AS [level]
		FROM Employees) AS [Data]
		WHERE [Level] = @salaryLevel
GO;

-- Exercise 7 --

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
    DECLARE @l int = 1;
    DECLARE @exist bit = 1;
    WHILE LEN(@word) >= @l AND @exist > 0
    BEGIN
      DECLARE @charindex int; 
      DECLARE @letter char(1);
      SET @letter = SUBSTRING(@word, @l, 1)
      SET @charindex = CHARINDEX(@letter, @setOfLetters, 0)
      SET @exist =
        CASE
            WHEN  @charindex > 0 THEN 1
            ELSE 0
        END;
      SET @l += 1;
    END

    RETURN @exist
END
GO; 

SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

GO;


-- Exersice 8 --

USE SoftUni_Base;
GO; 

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN ( SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId )

	ALTER TABLE Employees ALTER COLUMN ManagerID INT

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN ( SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId )

	ALTER TABLE Departments ALTER COLUMN ManagerID INT
	
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN ( SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId )
	
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees WHERE @departmentId = DepartmentID
GO;

USE Bank;
GO;

-- Exersice 9 --

CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
		FROM AccountHolders
GO;

-- Exersice 10 --

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18,4))
AS
	SELECT FirstName, LastName
		FROM Accounts A
		INNER JOIN AccountHolders AH ON A.AccountHolderId = AH.Id
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @minBalance
		ORDER BY FirstName, LastName
GO;

EXEC usp_GetHoldersWithBalanceHigherThan 3000

GO;
-- Exersice 11 --

CREATE FUNCTION ufn_CalculateFutureValue(@totalSum DECIMAL(18,4), @YIR FLOAT, @YearCount INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @total DECIMAL(18,4);

	SET @total = @totalSum * POWER(1 + @YIR, @YearCount);

	RETURN @total;
END
GO;

-- Exersice 12 --

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AID INT, @Interest DECIMAL(18,4))
AS
	SELECT 
		A.Id AS [Account Id],
		FirstName,
		LastName,
		Balance,
		dbo.ufn_CalculateFutureValue(Balance, @Interest, 5) AS [Balance in 5 years]
		FROM Accounts A
		JOIN AccountHolders AH ON A.AccountHolderId = AH.Id
		WHERE A.Id = @AID
GO;

EXEC usp_CalculateFutureValueForAccount 3, 0.5
GO;

USE Diablo;
GO;

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(25))
RETURNS TABLE 
AS
RETURN
	SELECT SUM(Cash) AS [SumCash]
		FROM (SELECT 
			[Name],
			[Cash],
			ROW_NUMBER() OVER (Partition BY [Name] ORDER BY [Cash] DESC) AS [RowNumber]
			FROM UsersGames UG
			JOIN Games G ON UG.GameId = G.Id
			WHERE G.[Name] = @gameName) AS [Data]
		WHERE [RowNumber] % 2 <> 0

GO;

SELECT * FROM Games
	WHERE [Name] = 'Amsterdam'

SELECT dbo.ufn_CashInUsersGames('Amsterdam')