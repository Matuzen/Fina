using Fina.Api.Common.Api;
using Fina.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDatacontexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();

app.UseSecurity();
app.MapEndpoints();
app.Run();
