using System.Text;
using Api.Data;
using Api.Data.Article;
using Api.Data.Article.Operations.AddArticle;
using Api.Data.Article.Operations.AddArticleToReview;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.HideArticle;
using Api.Data.Article.Operations.PublishArticle;
using Api.Data.Article.Operations.RefuseArticle;
using Api.Data.Article.Operations.UpdateArticle;
using Api.Data.Shared;
using Api.Services.Employee;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Article;

public class ArticleService : DbServiceEntityBase<ArticleOrm, ArticleDbContext>, IArticleService
{
    private readonly IEmployeeService _employeeService;
    
    public ArticleService(MediaDbContext context, IEmployeeService employeeService) : base(context)
    {
        _employeeService = employeeService;
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

    public async Task<PublishArticleResponse> PublishArticle(PublishArticleRequest request)
    {
        var result = new PublishArticleResponse();

        ArticleOrm article = await GetModel(request.ArticleId);

        article.Status = ArticleStatus.Published;
        article.PublicationDateTime = DateTimeOffset.Now;
        article.Editor = await _employeeService.GetModel(request.EditorId);

        await InvokeAsyncOperation(result, async () => await Update(article));

        return result;
    }

    public async Task<AddArticleResponse> AddArticle(AddArticleRequest request)
    {
        var result = new AddArticleResponse();
        
        var article = new ArticleOrm
        {
            Author = await _employeeService.GetModel(request.AuthorId),
            Title = request.Title,
            Body = Encoding.UTF8.GetBytes(request.JsomBody),
            Category = request.Category,
            Status = ArticleStatus.InProgress,
            LastModifiedDateTime = DateTimeOffset.Now
        };
        
        await InvokeAsyncOperation(result, async () => await Add(article));

        return result;
    }

    public async Task<RefuseArticleResponse> RefuseArticle(RefuseArticleRequest request)
    {
        var result = new RefuseArticleResponse();
        
        var article = await GetModel(request.ArticleId);

        if (article.Status != ArticleStatus.Review)
        {
            result.Error.ArticleNotReviewed = true;

            return result;
        }

        article.Status = ArticleStatus.InProgress;
        article.Editor = await _employeeService.GetModel(request.EditorId);
        article.RefuseReason = request.RefuseReason;
        
        await InvokeAsyncOperation(result, async () => await Update(article));

        return result;
    }

    public async Task<AddArticleToReviewResponse> AddArticleToReview(AddArticleToReviewRequest request)
    {
        var result = new AddArticleToReviewResponse();
        
        var article = await GetModel(request.ArticleId);

        article.Status = ArticleStatus.Review;
        article.Editor = await _employeeService.GetModel(request.EditorId);

        await InvokeAsyncOperation(result, async () => await Update(article));

        return result;
    }

    public async Task<HideArticleResponse> HideArticle(HideArticleRequest request)
    {
        var result = new HideArticleResponse();
        
        var article = await GetModel(request.ArticleId);

        article.Status = ArticleStatus.Hidden;
        article.HiddenDateTime = DateTimeOffset.Now;
        article.HiddenReason = request.HiddenReason;
        article.Editor = await _employeeService.GetModel(request.EditorId);

        await InvokeAsyncOperation(result, async () => await Update(article));

        return result;
    }

    public async Task<UpdateArticleResponse> UpdateArticle(UpdateArticleRequest request)
    {
        var result = new UpdateArticleResponse();
        
        var article = await GetModel(request.ArticleId);

        if (article.Status != ArticleStatus.InProgress)
        {
            result.Error.ArticleCannotBeEdited = true;

            return result;
        }

        article.Title = request.Title;
        article.Body = Encoding.UTF8.GetBytes(request.JsonBody);
        article.LastModifiedDateTime = DateTimeOffset.Now;
        article.Category = request.Category;

        await InvokeAsyncOperation(result, async () => await Update(article));

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