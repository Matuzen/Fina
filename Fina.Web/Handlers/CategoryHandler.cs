﻿using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Net.Http.Json;

namespace Fina.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
// Factory é um factory method do design patern para criação de objetos http 

{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var result = await _client.PostAsJsonAsync("v1/categories", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha ao criar categoria");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível criar a categoria");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao excluir a categoria");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível excluir a categoria");
        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<Category>?>>("v1/categories")
           ?? new PagedResponse<List<Category>?>(null, 400, "Não foi possível obter as categorias");

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
      => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
           ?? new Response<Category?>(null, 400, "Não foi possível obter a categoria");

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                   ?? new Response<Category?>(null, 400, "Falha ao atualizar a categoria");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Não foi possível editar a categoria");
        }
    }
}
