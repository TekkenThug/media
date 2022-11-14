using FluentMigrator;

namespace Api.Data.Migrations;

public abstract class NonReversibleMigration : Migration
{
    /// <inheritdoc />
    public sealed override void Down() => throw new NotSupportedException("Downgrade of migrations is not supported.");
}