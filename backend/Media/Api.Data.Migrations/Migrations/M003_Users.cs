using FluentMigrator;

namespace Api.Data.Migrations.Migrations;

[Migration(version: 3)]
public class M003_Users : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("Users")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("ModeratorId").AsInt64().Nullable().ForeignKey("Employees", "Id")
            .WithColumn("Login").AsString().NotNullable()
            .WithColumn("Password").AsBinary().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("Surname").AsString().Nullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Status").AsInt32().NotNullable()
            .WithColumn("RegistrationDateTime").AsDateTimeOffset().NotNullable()
            .WithColumn("ProfileImageUrl").AsString().Nullable();
    }
}