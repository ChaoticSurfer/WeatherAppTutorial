using WeatherAppTutorial;
using WeatherAppTutorial.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WeatherService>();
builder.Services.Configure<OpenWeatherConfig>(builder.Configuration.GetSection("OpenWeatherConfig"));


builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.MapGet("/weather", async (WeatherService weatherService, double latitude, double longitude) =>
{
    return await weatherService.GetWeatherDataAsync(latitude, longitude);
});
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
