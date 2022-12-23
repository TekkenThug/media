namespace Api.Data.Article.Operations.GetArticleListItems;

public class GetArticleListItemsResponse : OperationResultBase
{
    public List<ArticleListItem> Articles { get; set; } = new();
}