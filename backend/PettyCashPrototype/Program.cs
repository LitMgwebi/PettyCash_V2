#region Global Imports

global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using PettyCashPrototype.Services.RequisitionService;
global using PettyCashPrototype.Services.TransactionService;
global using PettyCashPrototype.Services.MainAccountService;
global using PettyCashPrototype.Services.SubAccountService;
global using PettyCashPrototype.Services.DepartmentService;
global using PettyCashPrototype.Services.GLAccountService;
global using PettyCashPrototype.Services.DocumentService;
global using PettyCashPrototype.Services.DivisionService;
global using PettyCashPrototype.Services.JobTitleService;
global using PettyCashPrototype.Services.PurposeService;
global using PettyCashPrototype.Services.OfficeService;
global using PettyCashPrototype.Services.StatusService;
global using PettyCashPrototype.Services.VaultService;
global using PettyCashPrototype.Services.UserService;
global using PettyCashPrototype.Services.AuthService;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using PettyCashPrototype.Models;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using System.Data;

#endregion

#region Local Imports

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PettyCashPrototype.Services.NotificationService;
using System.Drawing;

#endregion

var builder = WebApplication.CreateBuilder(args);

#region Scoping Services and Mapping Config

builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IVault, VaultService>();
builder.Services.AddScoped<IOffice, OfficeService>();
builder.Services.AddScoped<IStatus, StatusService>();
builder.Services.AddScoped<IPurpose, PurposeService>();
builder.Services.AddScoped<IDivision, DivisonService>();
builder.Services.AddScoped<IJobTitle, JobTitleService>();
builder.Services.AddScoped<IDocument, DocumentService>();
builder.Services.AddScoped<IGLAccount, GLAccountService>();
builder.Services.AddScoped<ISubAccount, SubAccountService>();
builder.Services.AddScoped<IDepartment, DepartmentService>();
builder.Services.AddScoped<IMainAccount, MainAccountService>();
builder.Services.AddScoped<ITransaction, TransactionService>();
builder.Services.AddScoped<IRequisition, RequisitionService>();
builder.Services.AddHostedService<PettyCashNotification>();
builder.Services.AddHostedService<VaultNotification>();

builder.Services.AddAutoMapper(typeof(Program));

#endregion

#region Controllers and Endpoints Config

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();

#endregion

#region Authentication and Authorization Config

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("StudentAdminPolicy", policy => policy.RequireRole("Student", "Admin"));
});

#endregion

#region Identity Configuration

builder.Services.AddDbContext<PettyCashPrototypeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PettyCashPrototypeContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
});

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
app.UseFileServer();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

#region Constant enum and structs

public struct typesOfTransaction
{
    public const string Withdrawal = "Withdrawal";
    public const string Deposit = "Deposit";
    public const string Change = "Change";
    public const string All = "All";
};

public struct typesOfDocument
{
    public const string Motivation = "motivation";
    public const string Receipt = "receipt";
};

public struct editRequisitionStates
{
    public const string Recommendation = "recommendation";
    public const string Approval = "approval";
    public const string Edit = "edit";
    public const string Issuing = "issuing";
    public const string Expenses = "expenses";
    public const string Close = "close";
}

public struct getRequisitionStates
{
    public const string All = "all";
    public const string ForOne = "forOne";
    public const string Recommendation = "recommendation";
    public const string Approval = "approval";
    public const string Opened = "open";
    public const string Issued = "issue";
    public const string Receiving = "receiving";
    public const string Tracking = "tracking";
    public const string Closing = "closing";
    public const string Returned = "return";
}

#endregion