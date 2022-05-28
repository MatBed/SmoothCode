using FluentValidation;
using FluentValidation.AspNetCore;
using MeetupTime.API.Entities;
using MeetupTime.API.Identity;
using MeetupTime.API.Models;
using MeetupTime.API.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = new JwtOptions();
builder.Configuration.GetSection("JWT").Bind(jwtOptions);

builder.Services.AddSingleton(jwtOptions);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtOptions.JwtIssuer,
        ValidAudience = jwtOptions.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey))
    };
});

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MeetupAPI", Version = "v1" });
});
builder.Services.AddDbContext<Context>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "MeetupAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
