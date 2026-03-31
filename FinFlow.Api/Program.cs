using FinFlow.Application.Interfaces;
using FinFlow.Application.Services;
using FinFlow.Infrastructure.Data;
using FinFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Register DbContext
builder.Services.AddDbContext<FinFlowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers, swagger, etc.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Services
builder.Services.AddScoped<IFinancialAccountService, FinancialAccountService>();

// Add Repositories
builder.Services.AddScoped<IFinancialAccountRepository, FinancialAccountRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Generate Swagger/OpenAPI JSON at /swagger/v1/swagger.json
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        // Default generated JSON endpoint
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowReact");
app.UseAuthentication();
app.UseAuthorization();
// Serve uploaded files from wwwroot (e.g. /uploads/filename)
app.UseStaticFiles();
app.MapControllers();
app.Run();