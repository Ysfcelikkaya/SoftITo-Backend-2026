using HospitalAppApi.Data;
using HospitalAppApi.Data.Repository; // Bunları ekledik
using HospitalAppApi.Data.Repository.IRepository; // Bunları ekledik
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
// ================= SERILOG KARA KUTU KURULUMU =================
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/hospital-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
// ==============================================================

// Add services to the container.
// Bu satır API'nin sonsuz döngüye girmesini (Kendi kuyruğunu yemesini) sonsuza dek engeller!
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
builder.Services.AddScoped<HospitalAppApi.Services.SymptomCheckerService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital API", Version = "v1" });

    // Swagger'a JWT kullanacağımızı söylüyoruz
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Lütfen Bearer [boşluk] token_şifreniz formatında giriş yapın. \r\n\r\n Örnek: 'Bearer eyJhbGci...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// ---> İŞTE BURAYA YAPIŞTIRDIK <---
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Önce kimlik sor (Auth), sonra yetki sor (Authoriz)
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();