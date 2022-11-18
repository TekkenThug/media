using FluentMigrator;

namespace Api.Data.Migrations.Migrations;

[Migration(version: 2)]
public class M002_Appointments : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("Appointments")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("AdminId").AsInt64().NotNullable().ForeignKey("Employees", "Id")
            .WithColumn("EmployeeId").AsInt64().NotNullable().ForeignKey("Employees", "Id")
            .WithColumn("EmployeePositionId").AsInt64().NotNullable().ForeignKey("EmployeePositions", "Id")
            .WithColumn("Reason").AsString().NotNullable()
            .WithColumn("AppointmentDateTime").AsDateTimeOffset().NotNullable();
    }
}