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

    // �Ĥ@�����殳�����ѡA�Ϥ����ѤU�@��{���X
    //InitializeDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void InitializeDatabase()
{
    using var conn = new SqlConnection(builder.Configuration.GetConnectionString("Customer"));
    conn.Open();
    string sql = @"
IF OBJECT_ID(N'dbo.CustomerInfo', N'U') IS NOT NULL
   DROP TABLE [dbo].[CustomerInfo]
IF OBJECT_ID(N'dbo.RegionInfo', N'U') IS NOT NULL
   DROP TABLE [dbo].[RegionInfo]

CREATE TABLE CustomerInfo (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    EMail varchar(100) not null,
    Password varchar(30) not null,
    Name nvarchar(30) not null,
    Age int null,
    Gender nvarchar(1) not null,
    AreaName nvarchar(20) not null,
    CityName nvarchar(20) not null,
    CONSTRAINT IX_CustomerInfo UNIQUE (Name, CityName)
)

CREATE TABLE RegionInfo (
    AreaName nvarchar(20) NOT NULL,
    CityName nvarchar(20) NOT NULL,
    CONSTRAINT IX_RegionInfo UNIQUE (AreaName, CityName)
)

BEGIN TRANSACTION
    INSERT INTO CustomerInfo (
        EMail,
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a1@example.com',
        'a123456',
        N'�i�T',
        26,
        N'�k',
        N'�s�F',
        N'�s�{'
    );
    INSERT INTO CustomerInfo (
        EMail,
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a2@example.com',
        'a123456',
        N'���|',
        25,
        N'�k',
        N'�W��',
        N'�W��'
    );
    INSERT INTO CustomerInfo (
        EMail,
        Password,
        Name,
        Age,
        Gender,
        AreaName,
        CityName
    )
    VALUES (
        'a3@example.com',
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
COMMIT
";

    var command = conn.CreateCommand();
    command.Connection = conn;
    command.CommandText = sql;
    command.ExecuteNonQuery();
    command.Dispose();
    conn.Dispose();
    conn.Close();
}