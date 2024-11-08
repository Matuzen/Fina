using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Security.Claims;

namespace Fina.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1)
            .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user,
        ICategoryHandler handler, CreateCategoryRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.CreateAsync(request);
        if (result.IsSuccess)
            return TypedResults.Created($"/{result.Data.Id}", result);

        return Results.BadRequest(result);
    }
}
