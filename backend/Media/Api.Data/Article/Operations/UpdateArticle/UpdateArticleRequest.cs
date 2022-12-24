using Api.Data.Shared;

namespace Api.Data.Article.Operations.UpdateArticle;

public class UpdateArticleRequest
{
    public int ArticleId { get; set; }
    
    public string Title { get; set; }
    
    public string JsonBody { get; set; }

    public ArticleCategory Category { get; set; }
}