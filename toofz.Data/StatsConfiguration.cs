using System.Data.Entity.ModelConfiguration;
using toofz.NecroDancer.Data;

namespace toofz.Data
{
    internal sealed class StatsConfiguration : ComplexTypeConfiguration<Stats>
    {
        public StatsConfiguration()
        {
            this.Ignore(s => s.Priority);
        }
    }
}
