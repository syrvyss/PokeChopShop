using Data;
using Data.Services.Interfaces;
using Data.Services.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddDbContext<EfCoreContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    new OpenApiInfo()
    {
        License = new OpenApiLicense() { Name = "GPL3", Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.en.html") },
        Contact = new OpenApiContact() { Name = "Nikolaj Lübker" },
        Title = "PokeChop Shop"
    }
);

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