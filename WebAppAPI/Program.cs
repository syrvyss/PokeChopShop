using Data;
using Data.Services.Interfaces;
using Data.Services.Repositories;
using Microsoft.OpenApi.Models;
using PokeShop.Shared.Dto;
using WebAppAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonStatsRepository, PokemonStatsRepository>();
builder.Services.AddScoped<Logic.Controllers.IPokemonController, Logic.Controllers.PokemonController>();
builder.Services.AddScoped<Logic.Controllers.IOrderController, Logic.Controllers.OrderController>();
builder.Services.AddScoped<Logic.Controllers.IPokemonStatsController, Logic.Controllers.PokemonStatsController>();
//
// builder.Services.AddTransient<IOrderRepository, OrderRepository>();
// builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
// builder.Services.AddTransient<IPokemonStatsRepository, PokemonStatsRepository>();
// builder.Services.AddTransient<Logic.Controllers.IPokemonController, Logic.Controllers.PokemonController>();
// builder.Services.AddTransient<Logic.Controllers.IOrderController, Logic.Controllers.OrderController>();
// builder.Services.AddTransient<Logic.Controllers.IPokemonStatsController, Logic.Controllers.PokemonStatsController>();

builder.Services.AddDbContext<EfCoreContext>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        x => x.WithOrigins("http://localhost:5119")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

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
    app.UseCors("AllowSpecificOrigin");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();