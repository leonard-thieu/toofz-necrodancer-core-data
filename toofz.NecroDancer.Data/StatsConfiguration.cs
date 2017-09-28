using System.Data.Entity.ModelConfiguration;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer
{
    sealed class StatsConfiguration : ComplexTypeConfiguration<Stats>
    {
        public StatsConfiguration()
        {
            this.Ignore(s => s.Priority);
        }
    }
}
