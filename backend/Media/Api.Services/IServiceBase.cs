using Api.Data;

namespace Api.Services;

public interface IServiceBase<TEntity> where TEntity : IEntityOrm
{
    Task<TEntity> GetModel(int id);
    
    Task<List<TEntity>> GetModels();
}