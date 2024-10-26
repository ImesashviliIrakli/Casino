using Banking.Api.Configs;
using BuildingBlocks.Applictaion.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly);

//builder.Host.UseSerilog((context, configuration) =>
// configuration
//      .WriteTo.Console()
//      //.MinimumLevel.Information());
//      .ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowall");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
