using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Api.Models;
using Fina.Core;
using Fina.Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            // Garante que os nomes das entidades vão usar os namespaces
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
    }

    public static void AddDatacontexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(Configuration.ConnectionString);
        });

        builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<long>>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
        builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
        options => options.AddPolicy(
               ApiConfiguration.CorsPolicyName,
               policy => policy
                   .WithOrigins([
                       Configuration.BackendUrl,
                       Configuration.FrontendUrl
                   ])
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
           ));
    }

    public static void Default(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(z => z.FullName);
        });

        builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<long>>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

        builder.Services.AddControllers();
    }
}