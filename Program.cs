using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.repository;
using PruebaDotnet.src.user;
using PruebaDotnet.src.user.entity;
using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.task.entity;
using PruebaDotnet.src.task;
using PruebaDotnet.src.task.dto;

var builder = WebApplication.CreateBuilder(args);


//Add de configuration for the controllers
builder.Services.AddControllers();
// Add services to the container.

//Injections of dependencies and interfaces

//REPOSITORIES
builder.Services.AddDbContext<BdPruebaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();
builder.Services.AddScoped<IRepository<TaskEntity>, TaskRepository>();

//SERVICES
builder.Services.AddScoped<IServices<UserEntity>, UserService>();
builder.Services.AddScoped<IServices<TaskDto>, TaskService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();   // Activa el middleware de enrutamiento
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();   // Activa los controladores
});

app.Run();
