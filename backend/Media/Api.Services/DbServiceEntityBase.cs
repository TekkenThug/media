using Api.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TOrmModel> GetModel(int id)
    {
        TDbContext dbContext = CreateDbContext();

        return await dbContext.GetModel(id);
    }

    public async Task<List<TOrmModel>> GetModels()
    {
        TDbContext dbContext = CreateDbContext();

        return await dbContext.GetModels().ToListAsync();
    }
    
    public async Task Update(TOrmModel model)
    {
        this.Context.Update(model);

        await this.Context.SaveChangesAsync();
    }

    protected async Task InvokeAsyncOperation<TError>(OperationResultBase<TError> result, Func<Task> operation)
        where TError : OperationErrorBase
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
    
    protected async Task InvokeAsyncOperation(OperationResultBase result, Func<Task> operation)
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