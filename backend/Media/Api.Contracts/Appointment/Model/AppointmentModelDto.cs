using Api.Contracts.Employee.Model;
using Api.Contracts.EmployeePosition.Model;

namespace Api.Contracts.Appointment.Model;

public class AppointmentModelDto
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор назначения должности.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает администратора, который назначил должность
    /// </summary>
    public virtual EmployeeModelDto Admin { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает сотрудника, которому назначили должность
    /// </summary>
    public virtual EmployeeModelDto Employee { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает назначенную должность.
    /// </summary>
    public virtual EmployeePositionModelDto EmployeePosition { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает основание назанчения должности. 
    /// </summary>
    public string Reason { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает дату и время назначения должности.
    /// </summary>
    public DateTimeOffset AppointmentDateTime { get; set; }
}