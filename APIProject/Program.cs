using BusinessRulesContracts.Interfaces;
using BusinessRulesImpl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models.Tables;
using Repositories.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Project", Version = "1.0" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

//Adding AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adding DBContexts
string connectionStringSQLServer = builder.Configuration.GetConnectionString("DefaultSQLServerStringConnection");
builder.Services.AddDbContext<FilmeContext>(settings => settings.UseSqlServer(connectionStringSQLServer));

string connectionStringLogin = builder.Configuration.GetConnectionString("LoginStringConnection");
builder.Services.AddDbContext<LoginContext>(settings => settings.UseSqlServer(connectionStringLogin));

//Adding Identity
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<LoginContext>().
    AddDefaultTokenProviders();

SetDI(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
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