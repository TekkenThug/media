using Api.Db;

namespace Api.Services.Comment;

public class CommentService : MediaServiceBase, ICommentService
{
    public CommentService(ApplicationContext context) : base(context)
    {
    }
}