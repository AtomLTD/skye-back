using System.Globalization;
using Serilog;
using Serilog.Exceptions;
using skye_back.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .Enrich.WithExceptionDetails()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("Seq") 
                 ?? throw new ArgumentNullException("Seq"))
    .CreateBootstrapLogger();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddScoped<SkyeBackDbContext>(_ =>
    new SkyeBackDbContext(builder.Configuration.GetConnectionString("DirectoryServiceDb")!));

// Repositories

// Handlers

// Logger
builder.Services.AddSerilog();

// Validator


var app = builder.Build();

// Middleware


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "skye-back"));
}

app.MapControllers();

Log.Information("Start");

app.Run();