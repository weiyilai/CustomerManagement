CREATE TABLE RegionInfo (
    AreaName nvarchar(20) NOT NULL,
    CityName nvarchar(20) NOT NULL,
    INDEX IX_RegionInfo NONCLUSTERED (AreaName, CityName)
)