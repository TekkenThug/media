using Microsoft.EntityFrameworkCore;

namespace Api.Data.Comment;

public readonly struct CommentDbContext : IEntityDbContext<CommentOrm>
{
    public DbSet<CommentOrm> Comments { get; }

    public CommentDbContext(DbContext db)
    {
        this.Comments = db.Set<CommentOrm>();
    }
    
    public CommentOrm GetModel(int modelId)
    {
        return GetModels().FirstOrDefault(x => x.Id == modelId);
    }

    public IQueryable<CommentOrm> GetModels()
    {
        return Comments
            .Include(x => x.Article)
            .Include(x => x.Author)
            .Include(x => x.Author);
    }
}