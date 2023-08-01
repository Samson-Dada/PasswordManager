using API.DataAccess;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
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
