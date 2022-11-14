using System.Reflection;
using FluentMigrator.Expressions;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Migrations;

public class Migrator
{
    private class ForeignKeyConvention : IForeignKeyConvention
    {
        /// <inheritdoc />
        public IForeignKeyExpression Apply(IForeignKeyExpression expression)
        {
            expression.ForeignKey.Name =
                $"FK_{expression.ForeignKey.ForeignTable}_{string.Join("_", expression.ForeignKey.ForeignColumns)}";

            return expression;
        }
    }
    
    private class ConventionSet : IConventionSet
    {
        /// <inheritdoc />
        public IRootPathConvention RootPathConvention { get; }

        /// <inheritdoc />
        public DefaultSchemaConvention SchemaConvention { get; }

        /// <inheritdoc />
        public IList<IColumnsConvention> ColumnsConventions { get; }

        /// <inheritdoc />
        public IList<IConstraintConvention> ConstraintConventions { get; }

        /// <inheritdoc />
        public IList<IForeignKeyConvention> ForeignKeyConventions { get; }

        /// <inheritdoc />
        public IList<IIndexConvention> IndexConventions { get; }

        /// <inheritdoc />
        public IList<ISequenceConvention> SequenceConventions { get; }

        /// <inheritdoc />
        public IList<IAutoNameConvention> AutoNameConventions { get; }

        public ConventionSet()
        {
            var defaultConventionSet = new DefaultConventionSet();

            this.ForeignKeyConventions = new List<IForeignKeyConvention>
            {
                new ForeignKeyConvention(),
                defaultConventionSet.SchemaConvention
            };

            this.RootPathConvention = defaultConventionSet.RootPathConvention;
            this.SchemaConvention = defaultConventionSet.SchemaConvention;
            this.ColumnsConventions = defaultConventionSet.ColumnsConventions;
            this.ConstraintConventions = defaultConventionSet.ConstraintConventions;
            this.IndexConventions = defaultConventionSet.IndexConventions;
            this.SequenceConventions = defaultConventionSet.SequenceConventions;
            this.AutoNameConventions = defaultConventionSet.AutoNameConventions;
        }
    }

    private readonly IServiceProvider _serviceProvider;

    public Migrator(string connectionString, Assembly migrationsAssembly)
    {
        _serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .AddSingleton<IConventionSet>(new ConventionSet())
            .Configure<RunnerOptions>(
                x =>
                {
                    x.Task = "migrate";
                    x.Version = 0;
                    x.Steps = 1;
                    x.Profile = "";
                }
            )
            .Configure<ProcessorOptions>(
                x =>
                {
                    x.PreviewOnly = false;
                    x.Timeout = TimeSpan.FromHours(value: 2);
                }
            )
            .ConfigureRunner(
                rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .WithGlobalCommandTimeout(TimeSpan.FromHours(value: 2))
                    .ScanIn(migrationsAssembly)
                    .For.Migrations()
            )
            .BuildServiceProvider(validateScopes: false);
    }
    
    public void MigrateUp()
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        
        var migrationRunner = (MigrationRunner)scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        migrationRunner.MigrateUp();
    }
}