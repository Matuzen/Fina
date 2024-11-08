using Fina.Api.Common.Api;
using Fina.Api.Models;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Security.Claims;

namespace Fina.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandleAsync)
       .WithName("Categories: Delete")
       .WithSummary("Exclui uma categoria")
       .WithDescription("Exclui uma categoria")
       .WithOrder(3)
       .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };

        var result = await handler.DeleteAsync(request);

        if (result.IsSuccess)
            return TypedResults.Ok(result);

        return Results.BadRequest(result);
    }
}