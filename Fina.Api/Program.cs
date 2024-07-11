using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conncetionString = "Server=TI-MATHEUS3;Database=Fina;Trusted_Connection=true;TrustServerCertificate=true";

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(conncetionString));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
