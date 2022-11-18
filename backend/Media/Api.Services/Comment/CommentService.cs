using Api.Data;
using Api.Data.Comment;

namespace Api.Services.Comment;

public class CommentService  : DbServiceEntityBase<CommentOrm, CommentDbContext>, ICommentService
{
    public CommentService(MediaDbContext context) : base(context)
    {
    }

    protected override CommentDbContext CreateDbContext()
    {
        return new CommentDbContext(this.Context);
    }
}