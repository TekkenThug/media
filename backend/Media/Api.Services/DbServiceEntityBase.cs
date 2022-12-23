using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Services;

public abstract class DbServiceEntityBase<TOrmModel, TDbContext> 
    where TOrmModel : class, IEntityOrm, new() 
    where TDbContext : IEntityDbContext<TOrmModel>
{
    protected readonly MediaDbContext Context;
    
    public DbServiceEntityBase(MediaDbContext context)
    {
        Context = context;
    }

    protected abstract TDbContext CreateDbContext();

    protected async Task InvokeAsyncOperation<TError>(
        Func<ValueTask<EntityEntry<TOrmModel>>> operation,
        OperationResultBase<TError> result) where TError : OperationErrorBase
    {
        try
        {
            await Task.Run(operation);
        }
        catch (Exception exception)
        {
            result.Error.UnexpectedError = exception.Message;
            result.IsSucceeded = false;
        }
    }
}