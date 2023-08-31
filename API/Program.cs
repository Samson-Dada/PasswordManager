using API.Modules.Repositories;
using API.Modules.Services;
using API.Modules.User.Repositories;
using API.Modules.User.Services;
using API.Shared.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(optionAction =>
{
    optionAction.RejectionStatusCode = 330;
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
builder.Services.AddResponseCaching();
builder.Services.AddDbContext<ApplicationDbContext>(actionOptions =>
{
    actionOptions.UseSqlServer(builder.Configuration.GetConnectionString("PasswordVaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
//
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
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

app.MapControllers();

app.Run();
