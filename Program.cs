using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.repository;
using PruebaDotnet.src.user;
using PruebaDotnet.src.user.entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injections of dependencies and interfaces

//REPOSITORIES
builder.Services.AddDbContext<BdPruebaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();

//USERS
builder.Services.AddScoped<IServices<UserEntity>, UserService>();


//Add de configuration for the controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

//TODO:
// la conexion a la base de datos