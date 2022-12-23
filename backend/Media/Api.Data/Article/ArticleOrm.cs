using System.ComponentModel.DataAnnotations;
using Api.Data.Shared;
using Api.Data.User;
using Api.Data.Employee;

namespace Api.Data.Article;

public class ArticleOrm : IEntityOrm
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор новости.
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает автора новости.
    /// </summary>
    public virtual EmployeeOrm Author { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает редактора новости.
    /// </summary>
    public virtual EmployeeOrm Editor { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает загаловок новости.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает содержимое новости.
    /// </summary>
    public byte[] Body { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает статус новости.
    /// </summary>
    public ArticleStatus Status { get; set; }
        
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
    public ArticleCategory Category { get; set; }
}