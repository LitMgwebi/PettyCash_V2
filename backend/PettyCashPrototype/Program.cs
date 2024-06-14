global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using PettyCashPrototype.Services.SubAccountService;
global using PettyCashPrototype.Services.PurposeService;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using PettyCashPrototype.Models;
global using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

#region Scoping Services and Mapping Config

builder.Services.AddScoped<IPurpose, PurposeService>();
builder.Services.AddScoped<ISubAccount, SubAccountService>();

builder.Services.AddAutoMapper(typeof(Program));

#endregion


#region Controllers and Endpoints Config
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Identity Configuration

builder.Services.AddDbContext<PettyCashPrototypeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")));
builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<PettyCashPrototypeContext>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    .AllowAnyHeader()
    .AllowAnyMethod()
    //.AllowAnyOrigin()
    .WithOrigins("http://localhost:8080")
);

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
