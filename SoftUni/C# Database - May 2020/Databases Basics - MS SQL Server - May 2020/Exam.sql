CREATE DATABASE TripService;

USE TripService;

-- Section 1. DDL --

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode NVARCHAR(2) NOT NULL,
);

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2),
);

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL REFERENCES Hotels(Id),
);

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	BookDate DATETIME NOT NULL,
	ArrivalDate DATETIME NOT NULL,
	ReturnDate DATETIME NOT NULL,
	CancelDate DATETIME,
	CONSTRAINT CHK_BookDate CHECK(DATEDIFF(DAY, [BookDate], [ArrivalDate]) > 0),
	CONSTRAINT CHK_ArrivalDate CHECK(DATEDIFF(DAY, [ArrivalDate], [ReturnDate]) > 0),
);

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATETIME2 NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL,
);

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL,
	TripId INT NOT NULL,
	Luggage INT NOT NULL CHECK ([Luggage] >= 0),

	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId),

	CONSTRAINT FK_AccountsTrips_Accounts FOREIGN KEY ([AccountId]) REFERENCES Accounts(Id),
	CONSTRAINT FK_AccountsTrips_Trips FOREIGN KEY ([TripId]) REFERENCES Trips(Id),
);

--DROP TABLE AccountsTrips, Rooms, Accounts, Trips, Hotels, Cities;

-- Section 2. DML --

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
	('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg');

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
	(101, '2015-04-12',	'2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07',	'2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17',	'2013-07-23', '2013-07-24', NULL),
	(104, '2012-03-17',	'2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07',	'2017-08-28', '2017-08-29', NULL);

SELECT COUNT(*) FROM Accounts;
SELECT COUNT(*) FROM Trips

UPDATE Rooms
	SET Price += Price * 0.14
	WHERE HotelId IN (5, 7, 9);

DELETE FROM AccountsTrips
	WHERE AccountId = 47;

-- Section 3. Querying --

SELECT
	FirstName,
	LastName,
	FORMAT(BirthDate, 'MM-dd-yyyy') AS [BirthDate],
	C.[Name] AS [Hometown],
	Email
	FROM Accounts A
	JOIN Cities C ON C.Id = A.CityId
	WHERE LEFT(Email, 1) = 'e'
	ORDER BY [Hometown] ASC;


SELECT
	C.[Name],
	COUNT(*) AS [Hotels]
	FROM Cities C
	JOIN Hotels H ON C.Id = H.CityId
	GROUP BY CityId, C.[Name]
	ORDER BY [Hotels] DESC, Name ASC

SELECT
	AccountId,
	FullName,
	MAX([TripLength]) AS [LongestTrip],
	MIN([TripLength]) AS [ShortestTrip]
	FROM (SELECT *,
	DENSE_RANK() OVER (PARTITION BY [FullName] ORDER BY [TripLength]) AS [Rank]
	FROM
		(SELECT
		AccountId,
		FirstName + ' ' + LastName AS [FullName],
		DATEDIFF(DAY, ArrivalDate, ReturnDate) AS [TripLength]
		FROM AccountsTrips ATT
		LEFT JOIN Accounts A ON A.Id = ATT.AccountId
		LEFT JOIN Trips T ON T.Id = ATT.TripId
		WHERE CancelDate IS NULL AND MiddleName IS NULL) AS [Ranking]) AS [Data]
	GROUP BY FullName, AccountId
	ORDER BY [LongestTrip] DESC, [ShortestTrip] ASC

SELECT TOP(10) CityId, C.[Name], C.CountryCode, COUNT(*) AS [Accounts]
	FROM Accounts A
	JOIN Cities C ON A.CityId = C.Id
	GROUP BY CityId, C.[Name], C.CountryCode
	ORDER BY [Accounts] DESC

SELECT
	A.Id,
	A.Email,
	C.[Name],
	COUNT(*) AS [Trips]
	FROM Accounts A
	RIGHT JOIN AccountsTrips ATT ON ATT.AccountId = A.Id
	JOIN Trips T ON T.Id = ATT.TripId
	JOIN Rooms R ON T.RoomId = R.Id
	JOIN Hotels H ON H.Id = R.HotelId
	JOIN Cities C ON c.Id = A.CityId
	GROUP BY C.[Name], A.Id, A.Email, H.CityId, A.CityId
	HAVING H.CityId = A.CityId
	ORDER BY [Trips] DESC, A.Id

SELECT
	T.Id,
	CONCAT(A.FirstName, ' ',ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name],
	A.CityId AS [From],
	H.CityId AS [To],
	CASE
		WHEN CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate), ' days')
	END AS [Duration]
	FROM Accounts A
	JOIN AccountsTrips ATT ON ATT.AccountId = A.Id
	JOIN Trips T ON T.Id = ATT.TripId
	JOIN Rooms R ON R.Id = T.RoomId
	JOIN Hotels H ON H.Id = R.HotelId
	ORDER BY [Full Name], T.Id

SELECT Trips.Id, CASE
    WHEN MiddleName IS NOT NULL THEN FirstName + ' ' + MiddleName + ' ' + LastName
    ELSE FirstName + ' ' + LastName
END AS FullName
, cityOne.[Name] AS [From], cityTwo.[Name] AS [To],
CASE
    WHEN CancelDate IS NULL THEN CONVERT(NVARCHAR(MAX), DATEDIFF(DAY, Trips.ArrivalDate, Trips.ReturnDate)) + ' days'
    ELSE 'Canceled'
END AS Duration
FROM AccountsTrips
JOIN Trips ON AccountsTrips.TripId = Trips.Id
JOIN Accounts ON Accounts.Id = AccountsTrips.AccountId
JOIN Cities AS cityOne ON cityOne.Id = Accounts.CityId
JOIN Rooms ON Rooms.Id = Trips.RoomId
JOIN Hotels ON Hotels.Id = Rooms.HotelId
JOIN Cities AS cityTwo ON cityTwo.Id = Hotels.CityId
ORDER BY FullName, Trips.Id

-- Section 4. Programmability --

GO;

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS VARCHAR(250)
BEGIN
	DECLARE @RoomId INT = NULL, @RoomType VARCHAR(50),
	@BedCount INT, @Price DECIMAL(18,2), @BaseRate DECIMAL(10,2),
	@ArrivalDate DATETIME, @ReturnDate DATETIME;

	SELECT TOP(1)
		@RoomId = RoomId,
		@RoomType = [Type],
		@BedCount = Beds,
		@Price = Price,
		@BaseRate = BaseRate,
		@ArrivalDate = ArrivalDate,
		@ReturnDate = ReturnDate
		FROM Trips T
		JOIN Rooms R ON R.Id = T.RoomId
		JOIN Hotels H ON H.Id = R.HotelId
		WHERE HotelId = @HotelId AND Beds >= @People
		ORDER BY Price DESC

	IF (@Date BETWEEN @ArrivalDate AND @ReturnDate) OR @ArrivalDate IS NULL
	BEGIN
		RETURN 'No rooms available';
	END

	DECLARE @TotalPrice DECIMAL(18,2) = (@BaseRate + @Price) * @People;

	RETURN CONCAT('Room ', @RoomId, ': ', @RoomType, ' (', @BedCount, ' beds) - $', @TotalPrice)
END

GO;

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

GO;

CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TargetRoomHotelId INT = (SELECT HotelId
									FROM Rooms R
									WHERE R.Id = @TargetRoomId)

	DECLARE @CurrentHotelId INT = (SELECT R.HotelId
										FROM Trips T
										JOIN Rooms R ON R.Id = T.RoomId
										WHERE T.Id = @TripId)

	IF (@TargetRoomHotelId != @CurrentHotelId)
		THROW 50001, 'Target room is in another hotel!', 1;

	DECLARE @TargetBedCount INT = (SELECT TOP(1) Beds FROM Rooms WHERE Id = @TargetRoomId);
	DECLARE @CurrentBedCount INT = (SELECT TOP(1) Beds
										FROM Trips T
										JOIN Rooms R ON R.Id = T.Id
										WHERE T.Id = @TripId);

	IF @TargetBedCount < @CurrentBedCount
		THROW 50002, 'Not enough beds in target room!', 1;

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
GO;

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8

SELECT * FROM Rooms
	WHERE Id = 10

SELECT RoomId
	FROM Trips T
	JOIN Rooms R ON R.Id = T.Id
	WHERE T.Id = 10
