using API.DataAccess;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
    //options.CacheProfiles.Add("200SecondsCache", new (){ Duration = 240});
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPasswordVaultUI", builder =>
    {
        builder.WithOrigins("http://passowrd-index.com")
               .WithMethods("GET", "POST", "PUT", "DELETE")
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(optionsAction => 
{
   optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("PasswordVaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowPasswordVaultUI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
