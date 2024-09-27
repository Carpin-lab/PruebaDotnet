using PruebaDotnet.src.interfaces;
using PruebaDotnet.src.repository;
using PruebaDotnet.src.user;
using PruebaDotnet.src.user.entity;
using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.task.entity;
using PruebaDotnet.src.task;
using PruebaDotnet.src.task.dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PruebaDotnet.src.Auth;
using PruebaDotnet.src.Auth.model;
using PruebaDotnet.src.user.dto;

var builder = WebApplication.CreateBuilder(args);


//Add de configuration for the controllers
builder.Services.AddControllers().AddDataAnnotationsLocalization();
// Add services to the container.

//Injections of dependencies and interfaces

//REPOSITORIES
builder.Services.AddDbContext<BdPruebaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//SERVICES
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IServices<TaskDto>, TaskService>();
builder.Services.AddScoped<IAuthServices, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// var secret = builder.Configuration["Jwt:Key"];
var jwt = builder.Configuration.GetSection("jwt").Get<JwtModel>();
var keyBytes = Encoding.UTF8.GetBytes(jwt.Key);

//Configurations for the authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Key,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
