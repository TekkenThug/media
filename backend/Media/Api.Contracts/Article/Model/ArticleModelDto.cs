using Api.Contracts.Employee.Model;
using Api.Contracts.Shared;
using Api.Contracts.User.Model;

namespace Api.Contracts.Article.Model;

public class ArticleModelDto
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор новости.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает автора новости.
    /// </summary>
    public UserModelDto Author { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает редактора новости.
    /// </summary>
    public EmployeeModelDto Editor { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает загаловок новости.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает путь к файлу с новостью.
    /// </summary>
    public string Path { get; set; }
        
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
    public DateTime LastModifiedDateTime { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает категорию новости.
    /// </summary>
    public ArticleCategory Category { get; set; }
}