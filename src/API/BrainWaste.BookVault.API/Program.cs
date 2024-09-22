using BrainWaste.BookVault.Api.Data;
using BrainWaste.BookVault.Api.Endpoints;
using BrainWaste.BookVault.Api.Repositories;
using BrainWaste.BookVault.Api.Services;
using BrainWaste.BookVault.Api.Services.Impls;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITimeService, SystemTimeService>();

var connectionString = builder.Configuration.GetValue<string>("Database:Sqlite");
if (connectionString == null)
    throw new Exception("Sqlite database is not configured");
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlite(connectionString); });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddScoped<BookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureEndpoints();

app.Run();