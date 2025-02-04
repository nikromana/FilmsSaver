
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model;
using MediatR;
using Application.Commands.Registration;
using Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("https://127.0.0.1:4200")  
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = builder.Configuration.GetSection("Jwt:ValidIssuer").Value;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:ValidIssuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:ValidAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Secret").Value)) // Replace with your secret key
    };
    //options.Events = new JwtBearerEvents
    //{
    //    OnMessageReceived = context =>
    //    {
    //        Console.WriteLine("📩 Получен запрос с заголовками:");
    //        foreach (var header in context.Request.Headers)
    //        {
    //            Console.WriteLine($"   {header.Key}: {header.Value}");
    //        }

    //        if (context.Request.Headers.ContainsKey("Authorization"))
    //        {
    //            Console.WriteLine("✅ Header Authorization founded: " + context.Request.Headers["Authorization"]);
    //        }
    //        else
    //        {
    //            Console.WriteLine("❌ Header Authorization not founded");
    //        }

    //        return Task.CompletedTask;
    //    },
    //    OnAuthenticationFailed = context =>
    //    {
    //        Console.WriteLine("❌ Error auth: " + context.Exception.Message);
    //        return Task.CompletedTask;
    //    },
    //    OnTokenValidated = context =>
    //    {
    //        Console.WriteLine("✅ Success auth! User: " + context.Principal.Identity.Name);
    //        return Task.CompletedTask;
    //    }
    //};

});

builder.Services.AddScoped<JwtTockenService>();
builder.Services.AddScoped<OmdbApiService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserContextService>();
builder.Services.AddMediatR(typeof(RegistrationCommandHandler).Assembly);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FilmsSaverDbContext.FilmsSaverDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<FilmsSaverDbContext.FilmsSaverDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();
app.Use(async (context, next) =>
{
    Console.WriteLine("Authorization Header: " + context.Request.Headers["Authorization"]);
    await next();
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
