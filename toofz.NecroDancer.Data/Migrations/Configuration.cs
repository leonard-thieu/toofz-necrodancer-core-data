using System;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Migrations
{
    sealed class Configuration : DbMigrationsConfiguration<NecroDancerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "toofz.NecroDancer.EntityFramework.Migrations.Configuration";
        }

        protected override void Seed(NecroDancerContext context)
        {
            try
            {
                var path = Util.GetEnvVar("NecroDancerPath");
                var data = NecroDancerDataSerializer.Load(path);

                context.Set<Item>().AddOrUpdate(i => i.ElementName, data.Items.ToArray());
                context.Set<Enemy>().AddOrUpdate(e => new { e.ElementName, e.Type }, data.Enemies.ToArray());

                context.SaveChanges();
            }
            catch (UnauthorizedAccessException ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}
