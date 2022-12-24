namespace Api.Data.Article.Operations.RefuseArticle;

public class RefuseArticleRequest
{
    public int ArticleId { get; set; }
    
    public int EditorId { get; set; }
    
    public string RefuseReason { get; set; }
}