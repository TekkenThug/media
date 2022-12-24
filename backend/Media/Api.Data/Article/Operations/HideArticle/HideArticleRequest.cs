namespace Api.Data.Article.Operations.HideArticle;

public class HideArticleRequest
{
    public int ArticleId { get; set; }
    
    public int EditorId { get; set; }

    public string HiddenReason { get; set; }
}