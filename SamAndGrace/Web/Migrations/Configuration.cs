namespace Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.DAL.SamAndGraceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Web.DAL.SamAndGraceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        public static void DropDefaultConstraint(string tableName, string columnName, Action<string> executeSQL)
        {
            string constraintVariableName = string.Format("@constraint_{0}", Guid.NewGuid().ToString("N"));

            string sql = string.Format(@"
            DECLARE {0} nvarchar(128)
            SELECT {0} = name
            FROM sys.default_constraints
            WHERE parent_object_id = object_id(N'{1}')
            AND col_name(parent_object_id, parent_column_id) = '{2}';
            IF {0} IS NOT NULL
                EXECUTE('ALTER TABLE {1} DROP CONSTRAINT ' + {0})",
                constraintVariableName,
                tableName,
                columnName);

            executeSQL(sql);
        }
    }
}
