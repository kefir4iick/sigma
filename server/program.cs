var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IFreespaceService, FreespaceService>();
builder.Services.AddSingleton<IMemoryinfoService, MemoryinfoService>();
builder.Services.AddSingleton<IRequestService, RequestService>();
builder.Services.AddSingleton<IUptimeService, UptimeService>();

var app = builder.Build();
app.UseCors("AllowAll");
app.UseMiddleware<LoggingMiddleware>();
app.MapControllers();
app.Run();
