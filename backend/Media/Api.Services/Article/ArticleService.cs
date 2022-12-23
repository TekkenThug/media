﻿using System.Text;
using Api.Data;
using Api.Data.Article;
using Api.Data.Article.Operations.AddArticle;
using Api.Data.Article.Operations.GetArticleListItems;
using Api.Data.Article.Operations.PublishArticle;
using Api.Data.Shared;
using Api.Services.Employee;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Article;

public class ArticleService  : DbServiceEntityBase<ArticleOrm, ArticleDbContext>, IArticleService
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

    public Task<AddArticleResponse> AddArticle(AddArticleRequest request)
    {
        throw new NotImplementedException();
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