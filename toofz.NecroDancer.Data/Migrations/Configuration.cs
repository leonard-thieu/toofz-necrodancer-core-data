using System.Data.Entity.Migrations;

namespace toofz.NecroDancer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NecroDancerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "toofz.NecroDancer.Migrations.Configuration";
        }
    }
}
