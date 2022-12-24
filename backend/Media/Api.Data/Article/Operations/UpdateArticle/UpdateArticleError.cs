namespace Api.Data.Article.Operations.UpdateArticle;

public class UpdateArticleError : OperationErrorBase
{
    public bool ArticleCannotBeEdited { get; set; }
}