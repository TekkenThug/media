using Api.Data;

namespace Api.Services;

public interface IServiceBase<TOrmModel> where TOrmModel : IEntityOrm
{
    Task<TOrmModel> GetModel(int id);
    
    Task<List<TOrmModel>> GetModels();

    public Task Update(TOrmModel model);
}