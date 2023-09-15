using API.Modules.Repositories;
using API.Modules.Services;
using API.Modules.User.Repositories;
using API.Modules.User.Services;
using API.Shared.DataAccess;
using API.Shared.Entities;
using API.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using API.Shared.Authentications.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(actionOptions =>
{
    actionOptions.UseSqlServer(builder.Configuration.GetConnectionString("PasswordVaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//

//For Identity

builder.Services.AddScoped<IAuthService, AuthService>();

//
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
//
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
//

// Adding Authentication
builder.Services.AddAuthentication(actionOption =>
{
    actionOption.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    actionOption.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    actionOption.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

 // Add JWT bearer
    .AddJwtBearer(options =>
     {
         var key = Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:SecretKey"]);

         options.SaveToken = true;
         options.RequireHttpsMetadata = false;
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidIssuer = builder.Configuration["JWTKey:Issuer"],
             ValidAudience = builder.Configuration["JWTkey:Audience"],
             ValidateIssuerSigningKey = true,
             ClockSkew = TimeSpan.Zero,
             IssuerSigningKey = new SymmetricSecurityKey(key)
         };
         { }

    });

builder.Services.AddRateLimiter(actionOption =>
{
    actionOption.RejectionStatusCode = 330;
});
builder.Services.AddMvc().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddCors(optionAction =>
{
    optionAction.AddPolicy(name: "justPolicy", builder =>
    {
        builder
        .WithOrigins("http://password-index.com")
        .AllowAnyHeader()
        .WithMethods("GET", "PUT", "POST", "DELETE")
        .AllowAnyHeader();
    });
});

builder.Services.AddHealthChecks();
builder.Services.AddLogging(actionOption =>
{
    actionOption.AddJsonConsole();
});

builder.Services.AddResponseCaching();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
