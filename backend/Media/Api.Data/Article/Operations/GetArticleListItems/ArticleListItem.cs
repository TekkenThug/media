using Api.Data.Shared;

namespace Api.Data.Article.Operations.GetArticleListItems;

public class ArticleListItem
{
    public int Id { get; set; }
    
    public string AuthorFirstName { get; set; }
    
    public string AuthorLastName { get; set; }

    public string Title { get; set; }

    public string JsonBody { get; set; }

    public DateTimeOffset PublicationDateTime { get; set; }

    public DateTimeOffset LastModifiedDateTime { get; set; }

    public ArticleCategory Category { get; set; }
}