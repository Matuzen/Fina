using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Core.Handlers;

public interface ICategoryHandler 
{
    Task<Response<Category?>>CreateAsync(CreateCategoryRequest request);
    // CreateAsync é o método para criar uma nova categoria
    // Esse método recebe a CreateCategoryRequest chamada de request
    // Async para não bloquear uma thread
    // Response é o retorno do CreateCategoryRequest
    // Category é o tipo do Response

    Task<Response<Category?>>DeleteAsync(DeleteCategoryRequest request);
    Task<Response<Category?>>UpdateAsync(UpdateCategoryRequest request);
    Task<Response<List<Category>?>>GetAllAsync(GetAllCategoriesRequest request);
    Task<PagedResponse<Category?>>GetByIdAsync(GetCategoryByIdRequest request); 
}
