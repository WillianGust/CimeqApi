using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuration JWT Auth
var secretKey = builder.Configuration["AppSettings:Secret"];
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Fix as environment
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false, // Fix as configuration
        ValidateAudience = false, // Fix as configuration
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cimeq API", Version = "v1" });

    // Add support auth Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add services needed
builder.Services.AddControllers();

// Add Configurations Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration environment developemnt
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //    c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    //    c.RoutePrefix = string.Empty; // Configure Swagger UI
    //});
}

// Add  middleware Auth before middleware Authorization
app.UseAuthentication();
app.UseAuthorization();

// Mapping Controllers
app.MapControllers();

app.Run();
