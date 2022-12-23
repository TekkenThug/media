namespace Api.Data.Article.Operations.AddArticle;

public class AddArticleRequest
{
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает загаловок новости.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает содержимое новости.
    /// </summary>
    public byte[] Body { get; set; }

    /// <summary>
    /// Возвращает или устанавливает дату публикации новости.
    /// </summary>
    public DateTimeOffset PublicationDateTime { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает дату сокрытия новости.
    /// </summary>
    public DateTimeOffset HiddenDateTime { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает причину скрытия новости.
    /// </summary>
    public string HiddenReason { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает причину отказа публикации новости.
    /// </summary>
    public string RefuseReason { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает дату и время последнего изменения новости.
    /// </summary>
    public DateTimeOffset LastModifiedDateTime { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает категорию новости.
    /// </summary>
    //public ArticleCategory Category { get; set; }
}