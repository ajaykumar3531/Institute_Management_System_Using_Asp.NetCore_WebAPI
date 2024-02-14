//using IMS.BusinessLayer.Classes;
//using IMS.BusinessLayer.Interfaces;
//using IMS.DataAccessLayer.Classess;

//using IMS.DataAccessLayer.Interfaces;


//using IMS.BusinessLayer.EmployeeClasses;
using IMS.BusinessLayer.EmployeeClasses;
using IMS.BusinessLayer.EmployeeInterfaces;
using IMS.BusinessLayer.IMSClasses;
using IMS.BusinessLayer.IMSInterfaces;
using IMS.DataAccessLayer.Classess;
using IMS.DataAccessLayer.EmployeeClasses;
using IMS.DataAccessLayer.EmployeeInterfaces;
using IMS.DataAccessLayer.IMSClassess;
//using IMS.DataAccessLayer.EmployeeInterfaces;
//using IMS.DataAccessLayer.IMSClassess;
using IMS.DataAccessLayer.IMSDatabase;
using IMS.DataAccessLayer.IMSEmployeesDatabase;
//using IMS.DataAccessLayer.IMSEmployeesDatabase;
using IMS.DataAccessLayer.Interfaces;
using IMS.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InstituteManagementSystemContext>();
builder.Services.AddScoped(typeof(IMS_IDataAccess<>), typeof(IMS_DataAccess<>));




builder.Services.AddDbContext<EmployeesContext>();
builder.Services.AddScoped<ITokenManager, Tokengeeration>();
builder.Services.AddScoped(typeof(IEmployessDataAccess<>), typeof(EmployessDataAccess<>));
builder.Services.AddScoped<IEmployessBusinessLayer, EmployessBusinessLayer>();
builder.Services.AddScoped<IStudentBusinessAccess, StudentBusinessAccess>();
builder.Services.AddScoped<ICourseBusinessAccess, CourseBusinessAccess>();
builder.Services.AddScoped<IBatchBusinessAccess, BatchBusinessAccess>();
builder.Services.AddScoped<IBillWisePaymentDetailsBusinessAccess, BillWisePaymentDetailsBusinessAccess>();
builder.Services.AddScoped<ICourseJoinedBusinessAccess, CourseJoinedBusinessAccess>();
builder.Services.AddScoped<IFacultyBusinessAccess, FacultyBusinessAccess>();
builder.Services.AddScoped<IPaymentModeBusinessAccess, PaymentModeBusinessAccess>();
builder.Services.AddScoped<IStudentBillBusinessAccess, StudentBillBusinessAccess>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





///JWT TokenConfig
var jwtConfig = builder.Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();

builder.Services.AddSingleton(jwtConfig);

var secretKey = jwtConfig.Secret;
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidAudience = jwtConfig.Audience,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey))
    };
});


//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api's", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
                });
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
