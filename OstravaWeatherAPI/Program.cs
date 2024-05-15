using AutoMapper;
using Coravel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using OstravaWeatherAPI_BAL.Extensions;
using OstravaWeatherAPI_BAL.Services;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Data;
using OstravaWeatherAPI_DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDbConnection")));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AppMapperProfile));
builder.Services.AddScoped<IRepositoryDailyWeather, RepositoryDailyWeather>();

builder.Services.AddScoped<ServiceDailyWeather, ServiceDailyWeather>();
builder.Services.AddTransient<GetWeatherFromOpenMeteo>();
builder.Services.AddHttpClient();
builder.Services.AddScheduler();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddTransient<DataDownloader>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date", 
        Example = new OpenApiString(DateTime.Now.ToString("yyyy-MM-dd")) });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.UseScheduler(scheduler =>
{
    scheduler.Schedule<GetWeatherFromOpenMeteo>()
        .EverySeconds(10);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
