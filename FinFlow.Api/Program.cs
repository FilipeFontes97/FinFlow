using FinFlow.Application.Interfaces;
using FinFlow.Application.Interfaces.Dashboard;
using FinFlow.Application.Interfaces.Debts;
using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Application.Interfaces.InvestmentRecords;
using FinFlow.Application.Services;
using FinFlow.Application.Services.Dashboard;
using FinFlow.Application.Services.Debts;
using FinFlow.Application.Services.FixedExpenses;
using FinFlow.Application.Services.InvestmentRecords;
using FinFlow.Infrastructure.Data;
using FinFlow.Infrastructure.Repositories;
using FinFlow.Infrastructure.Repositories.Debts;
using FinFlow.Infrastructure.Repositories.FixedExpenses;
using FinFlow.Infrastructure.Repositories.InvestmentRecords;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "https://localhost:5173",
                "http://localhost:5246",
                "https://localhost:5246"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<FinFlowDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFinancialAccountService, FinancialAccountService>();
builder.Services.AddScoped<IFinancialAccountRepository, FinancialAccountRepository>();
builder.Services.AddScoped<IDebtService, DebtService>();
builder.Services.AddScoped<IDebtRepository, DebtRepository>();
builder.Services.AddScoped<IFixedExpensesService, FixedExpensesService>();
builder.Services.AddScoped<IFixedExpensesRepository, FixedExpensesRepository>();
builder.Services.AddScoped<IInvestmentTransactionRepository, InvestmentTransactionRepository>();
builder.Services.AddScoped<IInvestmentService, InvestmentService>();
builder.Services.AddScoped<IInvestmentReportService, InvestmentReportService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowReact");
app.UseAuthorization();
app.MapControllers();
app.Run();