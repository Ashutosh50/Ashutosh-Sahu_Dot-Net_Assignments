using Assignment_5__Employee_Management_System_.Common;
using Assignment_5__Employee_Management_System_.CosmosDB;
using Assignment_5__Employee_Management_System_.Interfaces;
using Assignment_5__Employee_Management_System_.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
{
    var cosmosUrl = Credential.cosmosEndpoint;
    var primaryKey = Credential.PrimeryKey;

    if (string.IsNullOrEmpty(cosmosUrl) || string.IsNullOrEmpty(primaryKey))
    {
        throw new InvalidOperationException("CosmosDB connection details are missing");
    }

    return new CosmosClient(cosmosUrl, primaryKey);
});

builder.Services.AddScoped<ICosmosDB,CosmosDBService>();
builder.Services.AddScoped<IEmployeeService,EmployeeServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
