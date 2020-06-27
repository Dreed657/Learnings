CREATE DATABASE School;

USE School

CREATE TABLE Subjects 
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	[Lessons] INT NOT NULL
);

CREATE TABLE Exams
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Date] DATETIME,
	[SubjectId] INT FOREIGN KEY REFERENCES Subjects(Id)
);

CREATE TABLE Students 
(
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(25),
	[LastName] NVARCHAR(30) NOT NULL,
	[Age] INT NOT NULL CHECK (Age > 0),
	[Address] NVARCHAR(50),
	[Phone] NVARCHAR(10)
);

CREATE TABLE Teachers
(
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	[Phone] NVARCHAR(10),
	[SubjectId] INT REFERENCES Subjects(Id)
);

CREATE TABLE StudentsExams
(
	[StudentId] INT,
	[ExamId] INT,
	[Grade] DECIMAL(18,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6),

	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId),

	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentId) REFERENCES Students(Id),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamId) REFERENCES Exams(Id)
);

CREATE TABLE StudentsTeachers
(
	[StudentId] INT,
	[TeacherId] INT,

	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId),
	
	CONSTRAINT FK_StudentsTeachers_Students FOREIGN KEY (StudentId) REFERENCES Students(Id),
	CONSTRAINT FK_StudentsTeachers_Teachers FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE StudentsSubjects
(
	[Id] INT IDENTITY PRIMARY KEY,
	[StudentId] INT,
	[SubjectId] INT,
	[Grade] DECIMAL(18,2) NOT NULL CHECK (Grade >= 2 AND Grade <= 6),

	CONSTRAINT FK_StudentsSubjects_Students FOREIGN KEY (StudentId) REFERENCES Students (Id),
	CONSTRAINT FK_StudentsSubjects_Subjects FOREIGN KEY (SubjectId) REFERENCES Subjects (Id)
);

--DROP TABLE StudentsTeachers, StudentsExams, StudentsSubjects, 
--	Exams, Teachers, Subjects, Students;

GO;
-- Exersice 2 --

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId)
VALUES 
	('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
	('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4);

INSERT INTO Subjects(Name, Lessons)
VALUES 
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9);

SELECT * FROM [StudentsSubjects]
	WHERE Grade >= 5.50 AND SubjectId IN (1, 2);

-- Exersice 3 --

UPDATE [StudentsSubjects]
	SET Grade = 6.00
	WHERE Grade >= 5.50 AND SubjectId IN (1, 2);

-- Exersice 4 --

DELETE FROM StudentsTeachers
	WHERE TeacherId IN ( SELECT Id FROM Teachers
							WHERE Phone LIKE '%72%');

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

-- Exersice 5 --

SELECT FirstName, LastName, Age 
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName, LastName

-- Exersice 6 --

SELECT FirstName, LastName, COUNT(*) AS [TeachersCount]
	FROM StudentsTeachers ST
	LEFT JOIN Students S ON s.Id = ST.StudentId 
	GROUP BY StudentId, FirstName, LastName
	ORDER BY LastName;

-- Exersice 7 --

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
	FROM Students S
	LEFT JOIN StudentsExams SE ON S.Id = SE.StudentId
	WHERE SE.Grade IS NULL
	ORDER BY [Full Name];

-- Exersice 8 --

SELECT TOP(10) FirstName, LastName, CONVERT(DECIMAL(10,2), AVG(Grade)) AS [Grade]
	FROM StudentsExams SE
	JOIN Students S ON SE.StudentId = S.Id
	GROUP BY StudentId, FirstName, LastName
	ORDER BY Grade DESC

-- Exersice 9 --

SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name]
	FROM StudentsSubjects SS
	RIGHT JOIN Students S ON S.Id = SS.StudentId
	WHERE SS.Id IS NULL
	ORDER BY [Full Name]

-- Exersice 10 --

SELECT [Name], AVG(Grade)
	FROM StudentsSubjects SS
	JOIN Subjects S ON S.Id = SS.SubjectId 
	GROUP BY SubjectId, [Name]
	ORDER BY SubjectId

-- Exersice 11 --
GO;

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(10, 2))
RETURNS VARCHAR(2500)
BEGIN 
	DECLARE @student INT = (SELECT Id FROM Students WHERE Id = @studentId);
	DECLARE @studentName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId);
	DECLARE @count VARCHAR(10);

	IF (@student IS NULL) 
		RETURN 'The student with provided id does not exist in the school!';

	IF (@grade > 6.00) 
		RETURN 'Grade cannot be above 6.00!';

	SET @count = (SELECT COUNT(*) 
					FROM Students S
					JOIN StudentsExams SE ON SE.StudentId = S.Id
					WHERE @studentId = S.Id AND (Grade BETWEEN @grade AND @grade + 0.50)
				)

	RETURN 'You have to update ' + @count + ' grades for the student ' + @studentName;
END
GO;

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20);

SELECT dbo.udf_ExamGradesToUpdate(24, 5.50);

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50);

GO;

-- Exersice 12 --

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @Student INT = (SELECT Id FROM Students WHERE @StudentId = ID);

	IF (@Student IS NULL)
		THROW 50001, 'This school has no student with the provided id!', 1;

	DELETE FROM StudentsExams
		WHERE StudentId = @Student

	DELETE FROM StudentsTeachers
		WHERE StudentId = @Student

	DELETE FROM StudentsSubjects
		WHERE StudentId = @Student

	DELETE FROM Students
		WHERE Id = @Student
GO;

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301