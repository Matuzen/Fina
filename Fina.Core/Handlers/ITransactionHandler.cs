using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Core.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction>> CreateAsync (CreateTransactionRequest request);
    Task<Response<Transaction>> UpdateAsync (UpdateTransactionsRequest request);
    Task<Response<Transaction>> DeleteAsync (DeleteTransactionRequest request);
    Task<PagedResponse<List<Transaction>>> GetAllAsync (GetAllCategoriesRequest request);
    Task<Response<Transaction>> GetByPeriodAsync (GetCategoryByIdRequest request);
}
