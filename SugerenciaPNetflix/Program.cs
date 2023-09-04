using Microsoft.EntityFrameworkCore;
using SugerenciaPNetflix.Models;
using SugerenciaPNetflix.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IServicioNetflix, ServicesNetflix>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Conexion DB

    builder.Services.AddDbContext<SugerencaPeliculaContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetSection("AppSettings").GetSection("DefaultConnection").Value);
    });
    var appSettingsSection = builder.Configuration.GetSection("AppSettings");

#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "API",
                      builder =>
                      {
                          builder.WithHeaders("*");
                          builder.WithOrigins("*");
                          builder.WithMethods("*");

                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("API");

app.MapControllers();

app.Run();
