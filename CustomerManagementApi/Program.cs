using Application;
using Infrastructure;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    InitializeDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void InitializeDatabase()
{
    using var conn = new SqlConnection(builder.Configuration.GetConnectionString("Customer"));

    string sql = @"
-- use database
USE [master];
GO

IF OBJECT_ID(N'dbo.CustomerInfo', N'U') IS NOT NULL
   DROP TABLE [dbo].[CustomerInfo];
GO

CREATE TABLE CustomerInfo (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Password varchar(30) not null,
    Name nvarchar(30) not null,
    Age int null,
    Gender nvarchar(1) not null,
    AreaName nvarchar(20) not null,
    CityName nvarchar(20) not null,
    CONSTRAINT IX_CustomerInfo UNIQUE (Name, CityName)
);

CREATE TABLE RegionInfo (
    AreaName nvarchar(20) NOT NULL PRIMARY KEY,
    CityName nvarchar(20),
    CONSTRAINT IX_RegionInfo UNIQUE (CityName)
);

BEGIN TRANSACTION;
    INSERT INTO CustomerInfo (
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a123456',
        N'�i�T',
        26,
        N'�k',
        N'�s�F',
        N'�s�{'
    );
    INSERT INTO CustomerInfo (
        'a123456',
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a123456',
        N'���|',
        25,
        N'�k',
        N'�W��',
        N'�W��'
    );
    INSERT INTO CustomerInfo (
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a123456',
        N'����',
        20,
        N'�k',
        N'�s�F',
        N'�`�`'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�s�F',
        N'�s�{'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�s�F',
        N'�`�`'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�s�F',
        N'�]��'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�֫�',
        N'�֦{'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�֫�',
        N'�H��'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�s��',
        N'�n��'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�֫�',
        N'�۪L'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�W��',
        N'�W��'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'�_��',
        N'�_��'
    );
COMMIT;
";
}