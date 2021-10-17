-- Creating new database
CREATE DATABASE [BrokerSampleDatabase];
GO

-- Enabaling the Broker
ALTER DATABASE [BrokerSampleDatabase] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;
USE [BrokerSampleDatabase];
GO

-- Creating two tables
CREATE TABLE [Person](
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Surname] VARCHAR(50) NOT NULL
);

CREATE TABLE [Order](
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PersonFK] INT NOT NULL FOREIGN KEY REFERENCES Person(ID),
	[Date] SMALLDATETIME NOT NULL
);
GO

-- Example queries

-- SELECT * FROM [Person]
-- INSERT INTO [Person] ([Name], [Surname]) VALUES ('TestName', 'TestSurname')
-- UPDATE [Person] SET [Name] = 'TestName1', [Surname] = 'TestSurname1' WHERE [ID] = 1
-- DELETE FROM [Person] WHERE [ID] = 1

-- SELECT * FROM [Order]
-- INSERT INTO [Order] ([PersonFK], [Date]) VALUES (7, GETDATE())
-- UPDATE [Order] SET [PersonFK] = 1 WHERE [ID] = 1
-- DELETE FROM [Person] WHERE [ID] = 1
