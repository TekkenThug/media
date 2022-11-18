using FluentMigrator;

namespace Api.Data.Migrations.Migrations;

[Migration(version: 0)]
public class M000_EmployeePositions : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("EmployeePositions")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("PermissionLevel").AsInt32().NotNullable();
    }
}