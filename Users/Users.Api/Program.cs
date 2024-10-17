using BuildingBlocks.Api.Configs;
using Users.Api.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.BaseRegister(builder.Configuration, builder.Host).Register(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
