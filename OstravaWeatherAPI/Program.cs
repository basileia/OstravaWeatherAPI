using Coravel;
using OstravaWeatherAPI_BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
