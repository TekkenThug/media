namespace Api.Data.Article.Operations.AddArticleToReview;

public class AddArticleToReviewRequest
{
    public int ArticleId { get; set; }
    
    public int EditorId { get; set; }
}