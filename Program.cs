using Microsoft.EntityFrameworkCore;
using SwaggerSchoolAPI.Data;
using SwaggerSchoolAPI; // necessário para AddProjectServices()

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (SQLite by default)
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHttpClient(); // for external API calls

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

// register repositories and services
builder.Services.AddProjectServices();
