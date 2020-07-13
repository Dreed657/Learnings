-- 1. DDL TA --

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

-- 11. Available Room --

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(300)
AS
BEGIN
    DECLARE @hotelBaseRate DECIMAL(18,2) = (SELECT Hotels.BaseRate FROM Hotels WHERE Hotels.Id = @HotelId);
 
    DECLARE @roomId INT = (SELECT TOP(1) tempDB.roomId
							FROM(
							SELECT Rooms.Id AS roomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
							FROM Rooms
							JOIN Hotels ON Hotels.Id = Rooms.HotelId
							JOIN Trips ON Trips.RoomId = Rooms.Id
							WHERE Hotels.Id = @HotelId AND Rooms.Beds >= @People ) as tempDB
							WHERE NOT EXISTS (SELECT tempDBTwo.roomId
										FROM(
										SELECT RoomsTwo.Id AS roomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
										FROM Rooms as RoomsTwo
										JOIN Hotels AS HotelsTwo ON HotelsTwo.Id = RoomsTwo.HotelId
										JOIN Trips AS TripsTwo ON TripsTwo.RoomId = RoomsTwo.Id
										WHERE HotelsTwo.Id = @HotelId AND RoomsTwo.Beds >= @People ) as tempDBTwo
										WHERE (CancelDate IS NULL AND @Date > ArrivalDate AND @Date < ReturnDate))
							ORDER BY tempDB.Price DESC))
 
    IF(@roomId IS NULL) RETURN 'No rooms available'
 
    DECLARE @highestPrice DECIMAL(18,2)
    SET @highestPrice = (SELECT Rooms.Price FROM Rooms WHERE Rooms.Id = @roomId)
 
    DECLARE @roomType NVARCHAR(200);
    SET @roomType = (SELECT Rooms.[Type] FROM Rooms WHERE Rooms.Id = @roomId);
 
    DECLARE @roomBeds INT
    SET @roomBeds = (SELECT Rooms.Beds FROM Rooms WHERE Rooms.Id = @roomId)
 
    DECLARE @totalPrice DECIMAL(18,2)  
    SET @totalPrice = (@hotelBaseRate + @highestPrice) * @People
    RETURN FORMATMESSAGE('Room %i: %s (%i beds) - $%s', @roomId, @roomType, @roomBeds, CONVERT(NVARCHAR(100),@totalPrice))
END