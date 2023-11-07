CREATE TABLE CustomerInfo (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    EMail varchar(100) not null,
    Password varchar(30) not null,
    Name nvarchar(30) not null,
    Age int null,
    Gender nvarchar(1) not null,
    AreaName nvarchar(20) not null,
    CityName nvarchar(20) not null,
    INDEX IX_CustomerInfo NONCLUSTERED (Name, CityName)
)