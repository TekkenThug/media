using FluentMigrator;

namespace Api.Data.Migrations.Migrations;

[Migration(version: 4)]
public class M004_Articles : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("Articles")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("AuthorId").AsInt64().NotNullable().ForeignKey("Employees", "Id")
            .WithColumn("EditorId").AsInt64().NotNullable().ForeignKey("Employees", "Id")
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Body").AsBinary().NotNullable()
            .WithColumn("Status").AsInt32().NotNullable()
            .WithColumn("PublicationDateTime").AsDateTimeOffset().Nullable()
            .WithColumn("HiddenDateTime").AsDateTimeOffset().Nullable()
            .WithColumn("HiddenReason").AsString().Nullable()
            .WithColumn("RefuseReason").AsString().Nullable()
            .WithColumn("LastModifiedDateTime").AsDateTimeOffset().NotNullable()
            .WithColumn("Category").AsInt32().NotNullable();
    }
}