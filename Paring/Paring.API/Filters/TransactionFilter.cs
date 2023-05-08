using Microsoft.AspNetCore.Mvc.Filters;
using Paring.Core.Contracts.Repositories;

namespace Paring.API.Filters;

public class TransactionFilter : IAsyncActionFilter
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionFilter(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _unitOfWork.BeginTransaction();
        Console.WriteLine("start transaction");

        var resultContext = await next();

        if (resultContext.Exception == null)
        {
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.CommitTransaction();
            Console.WriteLine("transaction committed");
        }
        else
        {
            _unitOfWork.RollbackTransaction();
            Console.WriteLine("transaction rollback");
        }
    }
}