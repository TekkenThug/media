using Api.Contracts.Article.Model;
using Api.Contracts.Employee.Model;
using Api.Contracts.Shared;
using Api.Contracts.User.Model;

namespace Api.Contracts.Comment.Model;

public class CommentModelDto
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор комментария.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает модератора, который скрыл комментарий.
    /// </summary>
    public virtual EmployeeModelDto Moderator { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает автора комментария.
    /// </summary>
    public virtual UserModelDto Author { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает новость к который был написан комментарий.
    /// </summary>
    public virtual ArticleModelDto Article { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает текст комментария.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает флаг, скрыт ли комментарий.
    /// </summary>
    public bool IsHidden { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает причину скрытия комментария.
    /// </summary>
    public CommentHiddenReason HiddenReason { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает дату и время скрытия комментария.
    /// </summary>
    public DateTimeOffset HiddenDateTime { get; set; }
}