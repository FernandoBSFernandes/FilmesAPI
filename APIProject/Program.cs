using Microsoft.EntityFrameworkCore;
using Repositories.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionStringSQLServer = builder.Configuration.GetConnectionString("DefaultSQLServerStringConnection");

//Adding DBContexts
builder.Services.AddDbContext<FilmeContext>(settings => settings.UseSqlServer(connectionStringSQLServer));

SetDI(builder);

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

static void SetDI(WebApplicationBuilder builder)
{
    //builder.Services.AddTransient();
}