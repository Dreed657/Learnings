CREATE DATABASE Airport;

USE Airport;

CREATE TABLE Planes
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	[Seats] INT NOT NULL,
	[Range] INT NOT NULL
);

CREATE TABLE Flights
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[DepartureTime] DATETIME,
	[ArrivalTime] DATETIME,
	[Origin] NVARCHAR(50) NOT NULL,
	[Destination] NVARCHAR(50) NOT NULL,
	[PlaneId] INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
);

CREATE TABLE Passengers
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Age] INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	[PassportId] NVARCHAR(11) NOT NULL
);

CREATE TABLE LuggageTypes
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Type] NVARCHAR(30) NOT NULL
);

CREATE TABLE Luggages 
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[LuggageTypeId] INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
	[PassengerId] INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
);

CREATE TABLE Tickets
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[PassengerId] INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	[FlightId] INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
	[LuggageId] INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
	[Price] DECIMAL(18,2) NOT NULL
);

INSERT INTO Planes ([Name], [Seats], [Range])
VALUES 
	('Airbus 336', 112, 5132),
	('Airbus 330', 432, 5325),
	('Boeing 369', 231, 2355),
	('Stelt 297', 254, 2143),
	('Boeing 338', 165, 5111),
	('Airbus 558', 387, 1342),
	('Boeing 128', 345, 5541);

INSERT INTO LuggageTypes ([Type])
VALUES 
	('Crossbody Bag'),
	('School Backpack'),
	('Shoulder Bag');

UPDATE Tickets
	SET Price += Price * 0.13
	FROM Tickets
	JOIN Flights F ON F.Id = Tickets.FlightId
	WHERE Destination = 'Carlsbad';

DELETE Tickets
	FROM Tickets T
	JOIN Flights F ON T.FlightId = F.Id
	WHERE Destination = 'Ayn Halagim';

DELETE Flights
	WHERE Destination = 'Ayn Halagim';

SELECT * 
	FROM Planes
	WHERE CHARINDEX('tr', [Name]) > 0
	ORDER BY Id, [Name], Seats, [Range];

SELECT FlightId, SUM(Price)
	FROM Tickets 
	GROUP BY FlightId
	ORDER BY SUM(Price) DESC, FlightId;

SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name],
	Origin,
	Destination
	FROM Tickets T
	JOIN Flights F ON T.FlightId = F.Id
	JOIN Passengers P ON T.PassengerId = P.Id
	ORDER BY [Full Name], Origin, Destination;

SELECT FirstName, LastName, Age
	FROM Passengers P
	LEFT JOIN Tickets T ON T.PassengerId = P.Id
	WHERE T.Id IS NULL
	ORDER BY Age DESC, FirstName, LastName;

SELECT 
	CONCAT(P.FirstName, ' ', P.LastName) AS [Full Name],
	Pl.[Name],
	CONCAT(F.Origin, ' - ', F.Destination) AS [Trip],
	LT.[Type]
	FROM Tickets T
	JOIN Flights F ON T.FlightId = F.Id
	JOIN Planes Pl ON F.PlaneId = Pl.Id
	JOIN Passengers P ON T.PassengerId = P.Id
	JOIN Luggages L ON T.LuggageId = L.Id
	JOIN LuggageTypes LT ON L.LuggageTypeId = LT.Id
	ORDER BY [Full Name], Pl.[Name], Origin, Destination, LT.[Type]

SELECT 
	p.[Name],
	p.Seats,
	COUNT(T.PassengerId) AS [Passengers Count]
	FROM Planes P
	LEFT OUTER JOIN Flights F ON F.PlaneId = P.Id
	LEFT OUTER JOIN Tickets T ON T.FlightId = F.Id
	GROUP BY P.[Name], P.Seats
	ORDER BY [Passengers Count] DESC, [Name], Seats;
GO;

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(100), @destination VARCHAR(100), @peopleCount INT) 
RETURNS VARCHAR(100)
BEGIN
	IF (@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!';
	END

	DECLARE @FlightId INT = (SELECT TOP(1) Id FROM Flights 
								WHERE Origin = @origin AND
									Destination = @destination);
	
	IF (@FlightId IS NULL)
	BEGIN
		RETURN 'Invalid flight!';
	END

	DECLARE @FlightPrice DECIMAL(18,2) = (SELECT TOP(1) Price FROM Tickets
												WHERE FlightId = @FlightId
											);

	DECLARE @Total DECIMAL(18, 2) = @FlightPrice * @peopleCount;
	
	RETURN CONCAT('Total price ', @Total);
END
GO;

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
GO;

CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE Flights
		SET DepartureTime = NULL, ArrivalTime = NULL
		WHERE DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0
GO;

SELECT * FROM FLIGHTS;

EXEC usp_CancelFlights