using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Infrastructure.Data;
using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Infrastructure.Repositories;
using SocialMediaApp.Application.Services;
using SocialMediaApp.Application;
using SocialMediaApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();