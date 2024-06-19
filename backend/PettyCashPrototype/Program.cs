#region Global Imports

global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using PettyCashPrototype.Services.RequisitionService;
global using PettyCashPrototype.Services.MainAccountService;
global using PettyCashPrototype.Services.SubAccountService;
global using PettyCashPrototype.Services.DepartmentService;
global using PettyCashPrototype.Services.GLAccountService;
global using PettyCashPrototype.Services.PurposeService;
global using PettyCashPrototype.Services.OfficeService;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using PettyCashPrototype.Models;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using System.Data;

#endregion

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

#region Scoping Services and Mapping Config

builder.Services.AddScoped<IOffice, OfficeService>();
builder.Services.AddScoped<IPurpose, PurposeService>();
builder.Services.AddScoped<IGLAccount, GLAccountService>();
builder.Services.AddScoped<IDepartment, DepartmentService>();
builder.Services.AddScoped<ISubAccount, SubAccountService>();
builder.Services.AddScoped<IMainAccount, MainAccountService>();
builder.Services.AddScoped<IRequisition, RequisitionService>();


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

#endregion

#region Identity Configuration

builder.Services.AddDbContext<PettyCashPrototypeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")));
builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<PettyCashPrototypeContext>();

#endregion

var app = builder.Build();

#region Web Application Config

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

#endregion