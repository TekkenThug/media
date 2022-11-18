using FluentMigrator;
 
namespace Api.Data.Migrations.Migrations;

[Migration(version: 1)]
public class M001_Employees : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("Employees")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("PositionId").AsInt64().NotNullable().ForeignKey("EmployeePositions", "Id")
            .WithColumn("Login").AsString().NotNullable()
            .WithColumn("Password").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("Surname").AsString().Nullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Phone").AsString().NotNullable()
            .WithColumn("Status").AsInt32().NotNullable()
            .WithColumn("ProfileImageUrl").AsString().Nullable();
    }
}