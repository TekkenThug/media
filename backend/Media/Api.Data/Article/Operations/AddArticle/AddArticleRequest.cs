using Api.Data.Shared;

namespace Api.Data.Article.Operations.AddArticle;

public class AddArticleRequest
{
    public int AuthorId { get; set; }
    
    public string Title { get; set; }
    
    public string JsomBody { get; set; }

    public ArticleCategory Category { get; set; }
}