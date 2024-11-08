﻿using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Security.Claims;

namespace Fina.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HandleAsync)
       .WithName("Categories: Update")
       .WithSummary("Atualiza uma categoria")
       .WithDescription("Atualiza uma categoria")
       .WithOrder(2)
       .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, UpdateCategoryRequest request, long id)
    {
        request.Id = id;
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.UpdateAsync(request);
        if (result.IsSuccess)
            return TypedResults.Ok(result);
        return TypedResults.BadRequest(result);
    }
}
