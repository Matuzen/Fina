using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Security.Claims;

namespace Fina.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandleAsync)
       .WithName("Categories: Get By Id")
       .WithSummary("Obtém uma categoria")
       .WithDescription("Obtém uma categoria")
       .WithOrder(4)
       .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, long id)
    {
        var request = new GetCategoryByIdRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };

        var result = await handler.GetByIdAsync(request);

        if (result.IsSuccess)
            return TypedResults.Ok(result);

        return Results.BadRequest(result);
    }
}
