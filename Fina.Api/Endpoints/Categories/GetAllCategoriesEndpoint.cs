using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Fina.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fina.Api.Endpoints.Transactions;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
       .WithName("Categories: Get All")
       .WithSummary("Obtém todas as categorias")
       .WithDescription("Obtém todas as categorias")
       .WithOrder(5)
       .Produces<PagedResponse<List<Category?>>>();
    }

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);

        if (result.IsSuccess)
            return TypedResults.Ok(result);

        return Results.BadRequest(result);
    }
}

