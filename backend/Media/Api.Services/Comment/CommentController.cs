namespace Api.Services.Comment;

public class CommentController : MediaControllerBase<ICommentService>, ICommentService
{
    public CommentController(ICommentService service) : base(service)
    {
    }
}