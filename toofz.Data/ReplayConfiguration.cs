using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace toofz.Data
{
    internal sealed class ReplayConfiguration : EntityTypeConfiguration<Replay>
    {
        public ReplayConfiguration()
        {
            this.HasKey(e => e.ReplayId);
            this.Property(e => e.ReplayId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
