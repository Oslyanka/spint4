using Microsoft.EntityFrameworkCore;
using SwaggerSchoolAPI.Data;
using SwaggerSchoolAPI; // garante o AddProjectServices()

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient();
builder.Services.AddProjectServices();

var app = builder.Build();

// SEM condicional: habilita Swagger também em produção
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerSchoolAPI v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

// Root redireciona pro Swagger para evitar 404 no "/"
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();


// register repositories and services
builder.Services.AddProjectServices();
