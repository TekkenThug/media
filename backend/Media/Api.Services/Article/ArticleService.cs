using System.Text;
using Api.Data;
using Api.Data.Article;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Article;

public class ArticleService  : DbServiceEntityBase<ArticleOrm, ArticleDbContext>, IArticleService
{
    public ArticleService(MediaDbContext context) : base(context)
    {
    }

    protected override ArticleDbContext CreateDbContext()
    {
        return new ArticleDbContext(this.Context);
    }

    public async Task<GetArticleListItemsResponse> GetArticleListItems()
    {
        var result = new GetArticleListItemsResponse();

        ArticleDbContext dbContext = CreateDbContext();
        
        result.Articles = await dbContext.GetModels().ConvertToListItems().ToListAsync();

        return result;
    }
}

public static class ArticleExtension
{
    public static IQueryable<ArticleListItem> ConvertToListItems(this IQueryable<ArticleOrm> articles)
    {
        return articles.Where(x => x.Status == ArticleStatus.Published).Select(x => new ArticleListItem
        {
            Id = x.Id,
            AuthorFirstName = x.Author.FirstName,
            AuthorLastName = x.Author.LastName,
            Title = x.Title,
            PublicationDateTime = x.PublicationDateTime,
            Category = x.Category,
            LastModifiedDateTime = x.LastModifiedDateTime,
            JsonBody = Encoding.UTF8.GetString(x.Body)
        });
    }
}