CREATE TABLE SkiResorts (
	Id uniqueidentifier PRIMARY KEY,
	Name nvarchar(100),
	Description nvarchar(500),
	ImageUrl nvarchar(400),
	Latitude decimal(8,6),
	Longitude decimal(9,6)
)

CREATE TABLE FavoriteSkiResorts (
	Id uniqueidentifier PRIMARY KEY,
	SkiResortId uniqueidentifier,
	UserId uniqueidentifier

    CONSTRAINT FK_FavoriteSkiResorts_Id_SkiResorts_Id FOREIGN KEY (Id)
    REFERENCES SkiResorts(Id)
)

CREATE TABLE Avalanches (
	Id UNIQUEIDENTIFIER,
	ExternalId nvarchar(10),
	Date DATE,
	Latitude FLOAT,
	Longitude FLOAT,
	Elevation INT,
	Aspect NVARCHAR(30),
	Type NVARCHAR(50),
	Cause NVARCHAR(100),
	Depth INT,
	Width INT
)
GO

CREATE SCHEMA Lookup

CREATE TABLE Lookup.FeedbackType (
	Id INT PRIMARY KEY,
	Description nvarchar(100),
)

CREATE TABLE dbo.Feedback (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Description nvarchar(2000),
	FeedbackTypeId INT

	CONSTRAINT FK_Feedback_FeedbackTypeId_FeedbackType_Id FOREIGN KEY (FeedbackTypeId)
    REFERENCES Lookup.FeedbackType(Id)
)