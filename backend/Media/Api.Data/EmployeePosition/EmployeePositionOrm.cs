using Api.Data.Shared;

namespace Api.Data.EmployeePosition;

public class EmployeePositionOrm : IEntityOrm
{    
    /// <summary>
    /// Возвращает или устанавливает идентификатор должности.
    /// </summary>
    public int Id { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает название должности.
    /// </summary>
    public string Name { get; set; }
        
    /// <summary>
    /// Возвращает или устанавливает уровень прав должности.
    /// </summary>
    public EmployeePositionPermissionLevel PermissionLevel { get; set; }
}