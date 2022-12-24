namespace Api.Data.Article.Operations.RefuseArticle;

public class RefuseArticleError : OperationErrorBase
{
    public bool ArticleNotReviewed { get; set; }
}