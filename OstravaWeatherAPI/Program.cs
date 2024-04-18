using Coravel;
using Microsoft.EntityFrameworkCore;
using OstravaWeatherAPI_BAL.Services;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Data;
using OstravaWeatherAPI_DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDbConnection")));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IRepositoryDailyWeather, RepositoryDailyWeather>();

builder.Services.AddTransient<GetWeatherFromOpenMeteo>();
builder.Services.AddHttpClient();
builder.Services.AddScheduler();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
