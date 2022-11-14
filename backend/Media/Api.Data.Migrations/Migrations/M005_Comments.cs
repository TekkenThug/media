using FluentMigrator;

namespace Api.Data.Migrations.Migrations;

[Migration(version: 5)]
public class M005_Comments : NonReversibleMigration
{
    public override void Up()
    {
        this.Create.Table("Comments")
            .WithColumn("Id").AsInt64().PrimaryKey()
            .WithColumn("ModeratorId").AsInt64().Nullable().ForeignKey("Employees", "Id")
            .WithColumn("AuthorId").AsInt64().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("ArticleId").AsInt64().NotNullable().ForeignKey("Articles", "Id")
            .WithColumn("Text").AsString().NotNullable()
            .WithColumn("IsHidden").AsBoolean().Nullable()
            .WithColumn("HiddenReason").AsInt32().Nullable()
            .WithColumn("HiddenDateTime").AsDateTimeOffset().Nullable();
    }
}