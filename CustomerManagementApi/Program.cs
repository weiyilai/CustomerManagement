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

    // 第一次執行拿掉註解，反之註解下一行程式碼
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
        N'張三',
        26,
        N'男',
        N'廣東',
        N'廣州'
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
        N'李四',
        25,
        N'女',
        N'上海',
        N'上海'
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
        N'王五',
        20,
        N'男',
        N'廣東',
        N'深圳'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'廣東',
        N'廣州'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'廣東',
        N'深圳'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'廣東',
        N'珠海'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'福建',
        N'福州'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'福建',
        N'廈門'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'廣西',
        N'南寧'
    );
    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'福建',
        N'桂林'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'上海',
        N'上海'
    );

    INSERT INTO RegionInfo (
        AreaName,
        CityName
    )
    VALUES (
        N'北京',
        N'北京'
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