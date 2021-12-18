CREATE TABLE SkiResorts (
	SkiResortId uniqueidentifier PRIMARY KEY,
	Name nvarchar(100),
	Description nvarchar(500),
	ImageUrl nvarchar(400),
	Latitude decimal(8,6),
	Longitude decimal(9,6)
)

CREATE TABLE FavoriteSkiResorts (
	FavoriteSkiResortId uniqueidentifier PRIMARY KEY,
	SkiResortId uniqueidentifier,
	UserId uniqueidentifier

    CONSTRAINT FK_FavoriteSkiResorts_FavoriteSkIResortId_SkiResorts_SkiResortId FOREIGN KEY (SkiResortId)
    REFERENCES SkiResorts(SkiResortId)
)
