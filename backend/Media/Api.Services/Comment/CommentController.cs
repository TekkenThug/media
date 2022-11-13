namespace Api.Services.Comment;

public class CommentController : MediaControllerBase<CommentService>, ICommentService
{
    public CommentController(CommentService service) : base(service)
    {
    }
}