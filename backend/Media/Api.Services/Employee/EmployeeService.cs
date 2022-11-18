﻿using Api.Data;
using Api.Data.Employee;

namespace Api.Services.Employee;

public class EmployeeService  : DbServiceEntityBase<EmployeeOrm, EmployeeDbContext>, IEmployeeService
{
    public EmployeeService(MediaDbContext context) : base(context)
    {
    }

    protected override EmployeeDbContext CreateDbContext()
    {
        return new EmployeeDbContext(this.Context);
    }
}