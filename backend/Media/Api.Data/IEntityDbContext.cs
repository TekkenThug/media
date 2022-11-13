namespace Api.Data;

public interface IEntityDbContext<TOrmModel>
{
    TOrmModel GetModel(int modelId);

    IQueryable<TOrmModel> GetModels();
}