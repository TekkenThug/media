using System;
using System.ComponentModel.DataAnnotations;
using Api.Data.Article;
using Api.Data.Shared;
using Api.Data.User;
using Api.Data.Employee;

namespace Api.Data.Comment;

public class CommentOrm : IEntityOrm
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор комментария.
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает модератора, который скрыл комментарий.
    /// </summary>
    public virtual EmployeeOrm Moderator { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает автора комментария.
    /// </summary>
    public virtual UserOrm Author { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает новость к который был написан комментарий.
    /// </summary>
    public virtual ArticleOrm Article { get; set; }
    
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