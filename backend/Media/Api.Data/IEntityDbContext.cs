namespace Api.Data;

public interface IEntityDbContext<TOrmModel>
{
    Task<TOrmModel> GetModel(int modelId);

    IQueryable<TOrmModel> GetModels();
}