using BusinessRulesContracts.Interfaces;
using BusinessRulesImpl;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adding DBContexts
string connectionStringSQLServer = builder.Configuration.GetConnectionString("DefaultSQLServerStringConnection");
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
    builder.Services.AddTransient<IAtualizarFilmeBO, AtualizarFilmeBO>();
    builder.Services.AddTransient<IRemoverFilmesBO, RemoverFilmesBO>();
    builder.Services.AddTransient<IRetornaFilmesBO, RetornarFilmesBO>();
    builder.Services.AddTransient<ISalvarFilmesBO, SalvarFilmesBO>();
}