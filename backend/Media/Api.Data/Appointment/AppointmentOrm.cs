using Api.Data.EmployeePosition;
using Api.Data.Employee;

namespace Api.Data.Appointment;

public class AppointmentOrm : IEntityOrm
{
    /// <summary>
    /// Возвращает или устанавливает идентификатор назначения должности.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает администратора, который назначил должность
    /// </summary>
    public virtual EmployeeOrm Admin { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает сотрудника, которому назначили должность
    /// </summary>
    public virtual EmployeeOrm Employee { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает назначенную должность.
    /// </summary>
    public virtual EmployeePositionOrm EmployeePosition { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает основание назанчения должности. 
    /// </summary>
    public string Reason { get; set; }
    
    /// <summary>
    /// Возвращает или устанавливает дату и время назначения должности.
    /// </summary>
    public DateTimeOffset AppointmentDateTime { get; set; }
}